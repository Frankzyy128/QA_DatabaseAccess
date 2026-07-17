using EF1.Models;

//////////////////////////////////////////////////////
// TASK 5 - Display all customers
//////////////////////////////////////////////////////

/*
using (NorthwindContext con = new NorthwindContext())
{
    var customers = con.Customers;

    foreach (var customer in customers)
    {
        Console.WriteLine($"Company Name: {customer.CompanyName}, Contact Name: {customer.ContactName}, Phone: {customer.Phone}");
    }
}
*/

//////////////////////////////////////////////////////
// TASK 6 - Display customers whose company starts with A
//////////////////////////////////////////////////////

/*
using (NorthwindContext con = new NorthwindContext())
{
    var customers =
        con.Customers.Where(c => c.CompanyName.StartsWith("A"));

    foreach (var customer in customers)
    {
        Console.WriteLine($"Company Name: {customer.CompanyName}, Contact Name: {customer.ContactName}, Phone: {customer.Phone}");
    }
}
*/

//////////////////////////////////////////////////////
// TASK 7 - Insert a new customer
//////////////////////////////////////////////////////

/*
using (NorthwindContext con = new NorthwindContext())
{
    Customer cust = new Customer()
    {
        CustomerId = "AARDV",
        CompanyName = "Aardvarks R Us",
        ContactName = "Mr Aardvark",
        Phone = "0123 456789"
    };

    con.Customers.Add(cust);
    con.SaveChanges();
}
*/

//////////////////////////////////////////////////////
// TASKS 8, 9 & 10 - Insert then verify it exists
//////////////////////////////////////////////////////

/*
using (NorthwindContext con = new NorthwindContext())
{
    Customer cust = new Customer()
    {
        CustomerId = "AARDV",
        CompanyName = "Aardvarks R Us",
        ContactName = "Mr Aardvark",
        Phone = "0123 456789"
    };

    con.Customers.Add(cust);
    con.SaveChanges();
}

Console.WriteLine("************************");

using (NorthwindContext con = new NorthwindContext())
{
    var customers =
        con.Customers.Where(c => c.CompanyName.StartsWith("Aa"));

    foreach (var customer in customers)
    {
        Console.WriteLine($"Company Name: {customer.CompanyName}, Contact Name: {customer.ContactName}, Phone: {customer.Phone}");
    }
}
*/

//////////////////////////////////////////////////////
// TASK 12 - Delete Aardvarks R Us
//////////////////////////////////////////////////////

/*
using (NorthwindContext con = new NorthwindContext())
{
    var customer = con.Customers
                      .SingleOrDefault(c => c.CustomerId == "AARDV");

    if (customer != null)
    {
        con.Customers.Remove(customer);
        con.SaveChanges();

        Console.WriteLine("Customer deleted.");
    }
}
*/

//////////////////////////////////////////////////////
// TASK 13 - Update the contact name
//////////////////////////////////////////////////////

/*
using (NorthwindContext con = new NorthwindContext())
{
    var customer = con.Customers
                      .SingleOrDefault(c => c.CustomerId == "AARDV");

    if (customer != null)
    {
        customer.ContactName = "Ms Abigail Aardvark";

        con.SaveChanges();

        Console.WriteLine("Customer updated.");
    }
}
*/#























using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndLambdas
{
    public class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int YearPublished { get; set; }

        public Book(string title, decimal price, int yearPublished)
        {
            Title = title;
            Price = price;
            YearPublished = yearPublished;
        }
    }

    public class DelegateExamples
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public static void DisplayGreeting(string name)
        {
            Console.WriteLine($"Hello {name}!");
        }

        public void DisplayGreetingInstance(string name)
        {
            Console.WriteLine($"Welcome {name}!");
        }

        public static List<Book> FindBooks(
            List<Book> books,
            Func<Book, bool> condition)
        {
            List<Book> matchingBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (condition(book))
                {
                    matchingBooks.Add(book);
                }
            }

            return matchingBooks;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DelegateExamples examples = new DelegateExamples();

            Func<int, int, int> addDelegate = examples.Add;

            int result = addDelegate(20, 30);

            Console.WriteLine($"Named method result: {result}");

            Func<int, int, int> addLambda = (x, y) => x + y;

            int lambdaResult = addLambda(40, 50);

            Console.WriteLine($"Lambda result: {lambdaResult}");

            Action<string> staticGreeting =
                DelegateExamples.DisplayGreeting;

            staticGreeting("Kabir");

            Action<string> instanceGreeting =
                examples.DisplayGreetingInstance;

            instanceGreeting("Yosha");

            Action<string> greetingLambda =
                name => Console.WriteLine($"Good morning {name}!");

            greetingLambda("Melanie");

            Action<string, int> displayAge =
                (name, age) =>
                {
                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Age: {age}");
                };

            displayAge("Alex", 25);

            List<Book> books = new List<Book>
            {
                new Book("Clean Code", 29.99m, 2008),
                new Book("C# in Depth", 39.99m, 2019),
                new Book("The Pragmatic Programmer", 34.99m, 1999),
                new Book("Head First C#", 24.99m, 2021),
                new Book("Beginning C#", 19.99m, 2014)
            };

            Func<Book, bool> isRecent =
                book => book.YearPublished >= 2015;

            List<Book> recentBooks =
                DelegateExamples.FindBooks(books, isRecent);

            Console.WriteLine("\nBooks published from 2015 onwards:");

            foreach (Book book in recentBooks)
            {
                Console.WriteLine(
                    $"{book.Title}, {book.YearPublished}, £{book.Price}");
            }

            List<Book> cheapBooks =
                DelegateExamples.FindBooks(
                    books,
                    book => book.Price < 30);

            Console.WriteLine("\nBooks costing less than £30:");

            foreach (Book book in cheapBooks)
            {
                Console.WriteLine($"{book.Title}: £{book.Price}");
            }

            Predicate<int> isOldEnough =
                age => age >= 21;

            Console.WriteLine($"\nIs 22 old enough? {isOldEnough(22)}");
            Console.WriteLine($"Is 17 old enough? {isOldEnough(17)}");

            Book recentBook =
                books.Find(book => book.YearPublished >= 2015);

            if (recentBook != null)
            {
                Console.WriteLine(
                    $"\nFirst recent book: {recentBook.Title}");
            }

            List<Book> booksStartingWithC =
                books.FindAll(book => book.Title.StartsWith("C"));

            Console.WriteLine("\nBooks beginning with C:");

            booksStartingWithC.ForEach(
                book => Console.WriteLine(book.Title));

            decimal averagePrice =
                books.Average(book => book.Price);

            Console.WriteLine(
                $"\nAverage price: £{averagePrice:F2}");
        }
    }
}
