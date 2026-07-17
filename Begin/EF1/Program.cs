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









































// This lets us use basic C# features such as Console.WriteLine.
using System;

// This lets us use collections such as List.
using System.Collections.Generic;

// This lets us use LINQ methods such as Average.
using System.Linq;

// A namespace groups related classes together.
// It also helps stop classes from having conflicting names.
namespace DelegatesAndLambdas
{
    // This class represents a book.
    // Each Book object will store a title, price and publication year.
    public class Book
    {
        // This property stores the title of the book.
        // get means we can read the title.
        // set means we can change the title.
        public string Title { get; set; }

        // This property stores the price of the book.
        // decimal is useful for money because it is more accurate than double.
        public decimal Price { get; set; }

        // This property stores the year when the book was published.
        public int YearPublished { get; set; }

        // This is the constructor for the Book class.
        // The constructor runs whenever a new Book object is created.
        public Book(string title, decimal price, int yearPublished)
        {
            // This saves the title given to the constructor
            // inside the Title property of this Book object.
            Title = title;

            // This saves the price given to the constructor
            // inside the Price property of this Book object.
            Price = price;

            // This saves the year given to the constructor
            // inside the YearPublished property of this Book object.
            YearPublished = yearPublished;
        }
    }

    // This class contains the normal methods that we will connect to delegates.
    public class DelegateExamples
    {
        // This method accepts two integers and returns an integer.
        // It is an instance method because it does not use the static keyword.
        // This means we need to create a DelegateExamples object before using it.
        public int Add(int x, int y)
        {
            // Add x and y together and return the answer.
            return x + y;
        }

        // This method displays a greeting.
        // It accepts one string called name.
        // It returns nothing because its return type is void.
        // It is static, so it belongs to the class itself.
        public static void DisplayGreeting(string name)
        {
            // Display a greeting containing the name.
            Console.WriteLine($"Hello {name}!");
        }

        // This method also displays a greeting.
        // It is an instance method because it is not static.
        public void DisplayGreetingInstance(string name)
        {
            // Display a welcome message containing the name.
            Console.WriteLine($"Welcome {name}!");
        }

        // This method searches through a list of books.
        //
        // It receives two things:
        // 1. A list of Book objects.
        // 2. A Func delegate called condition.
        //
        // Func<Book, bool> means:
        // The method receives one Book object.
        // The method returns either true or false.
        //
        // The condition decides whether each book should be added
        // to the list of matching books.
        public static List<Book> FindBooks(
            List<Book> books,
            Func<Book, bool> condition)
        {
            // Create a new empty list.
            // This will hold every book that passes the condition.
            List<Book> matchingBooks = new List<Book>();

            // Go through each Book object inside the books list.
            foreach (Book book in books)
            {
                // Call the method stored inside the condition delegate.
                // The current book is passed into that method.
                //
                // The condition returns true or false.
                // If it returns true, the code inside the if statement runs.
                if (condition(book))
                {
                    // Add the current book to the matchingBooks list.
                    matchingBooks.Add(book);
                }
            }

            // Return the completed list after every book has been checked.
            return matchingBooks;
        }
    }

    // This class contains the Main method.
    // The program starts running from Main.
    internal class Program
    {
        // Main is the starting point of the program.
        static void Main(string[] args)
        {
            // Create an object from the DelegateExamples class.
            // We need this object to access its instance methods.
            DelegateExamples examples = new DelegateExamples();

            // Create a Func delegate called addDelegate.
            //
            // Func<int, int, int> means:
            // The first int is the type of the first input.
            // The second int is the type of the second input.
            // The final int is the return type.
            //
            // We store the Add method inside the delegate.
            // We do not use brackets after Add because we are not calling it yet.
            Func<int, int, int> addDelegate = examples.Add;

            // Call the method stored inside addDelegate.
            // This is really calling examples.Add(20, 30).
            // The returned answer is saved inside result.
            int result = addDelegate(20, 30);

            // Display the answer returned by the delegate.
            Console.WriteLine($"Named method result: {result}");

            // Create another Func delegate.
            //
            // This time, we use a lambda instead of a named method.
            //
            // x and y are the two input parameters.
            // The arrow means "goes to" or "does this".
            // x + y is the value returned by the lambda.
            //
            // This lambda is basically a short unnamed Add method.
            Func<int, int, int> addLambda = (x, y) => x + y;

            // Call the lambda through the addLambda delegate.
            // 40 becomes x and 50 becomes y.
            // The answer is saved inside lambdaResult.
            int lambdaResult = addLambda(40, 50);

            // Display the result returned by the lambda.
            Console.WriteLine($"Lambda result: {lambdaResult}");

            // Create an Action delegate called staticGreeting.
            //
            // Action<string> means:
            // It accepts one string parameter.
            // It does not return a value.
            //
            // We store the static DisplayGreeting method inside it.
            Action<string> staticGreeting =
                DelegateExamples.DisplayGreeting;

            // Call the method stored inside staticGreeting.
            // "Kabir" is passed into its name parameter.
            staticGreeting("Kabir");

            // Create another Action delegate.
            //
            // This stores an instance method, so we access the method
            // through the examples object.
            Action<string> instanceGreeting =
                examples.DisplayGreetingInstance;

            // Call the method stored inside instanceGreeting.
            instanceGreeting("Yosha");

            // Create an Action delegate using a lambda.
            //
            // The lambda accepts one parameter called name.
            // It then displays a message using that name.
            //
            // We use Action because the lambda displays something
            // but does not return a value.
            Action<string> greetingLambda =
                name => Console.WriteLine($"Good morning {name}!");

            // Run the greeting lambda and pass "Melanie" into it.
            greetingLambda("Melanie");

            // Create an Action delegate that accepts two parameters.
            //
            // The first parameter is a string.
            // The second parameter is an integer.
            // It does not return anything.
            Action<string, int> displayAge =
                (name, age) =>
                {
                    // Display the name passed into the lambda.
                    Console.WriteLine($"Name: {name}");

                    // Display the age passed into the lambda.
                    Console.WriteLine($"Age: {age}");
                };

            // Call the displayAge lambda.
            // "Alex" becomes name and 25 becomes age.
            displayAge("Alex", 25);

            // Create a list that can only store Book objects.
            List<Book> books = new List<Book>
            {
                // Create a Book object and add it to the list.
                // The m after the price tells C# that it is a decimal.
                new Book("Clean Code", 29.99m, 2008),

                // Create and add another Book object.
                new Book("C# in Depth", 39.99m, 2019),

                // Create and add another Book object.
                new Book("The Pragmatic Programmer", 34.99m, 1999),

                // Create and add another Book object.
                new Book("Head First C#", 24.99m, 2021),

                // Create and add the final Book object.
                new Book("Beginning C#", 19.99m, 2014)
            };

            // Create a Func delegate called isRecent.
            //
            // It accepts one Book object and returns a bool.
            // A bool is either true or false.
            //
            // The lambda checks whether the publication year
            // is greater than or equal to 2015.
            Func<Book, bool> isRecent =
                book => book.YearPublished >= 2015;

            // Call the FindBooks method.
            //
            // We pass in:
            // 1. The full list of books.
            // 2. The isRecent delegate.
            //
            // FindBooks uses the isRecent condition on every book.
            // Books that return true are placed into recentBooks.
            List<Book> recentBooks =
                DelegateExamples.FindBooks(books, isRecent);

            // Start a new line and display a heading.
            // \n creates a blank line before the text.
            Console.WriteLine("\nBooks published from 2015 onwards:");

            // Go through every Book object inside recentBooks.
            foreach (Book book in recentBooks)
            {
                // Display the title, year and price of the current book.
                Console.WriteLine(
                    $"{book.Title}, {book.YearPublished}, £{book.Price}");
            }

            // Search for books costing less than £30.
            //
            // Instead of making a separate delegate variable first,
            // we pass the lambda directly into FindBooks.
            //
            // For each book, the lambda checks if its price is below 30.
            List<Book> cheapBooks =
                DelegateExamples.FindBooks(
                    books,
                    book => book.Price < 30);

            // Display a heading for the cheap books.
            Console.WriteLine("\nBooks costing less than £30:");

            // Go through every book in the cheapBooks list.
            foreach (Book book in cheapBooks)
            {
                // Display the title and price of the current book.
                Console.WriteLine($"{book.Title}: £{book.Price}");
            }

            // Create a Predicate delegate called isOldEnough.
            //
            // Predicate<int> always:
            // Accepts one integer.
            // Returns a bool.
            //
            // This lambda returns true when the age is at least 21.
            Predicate<int> isOldEnough =
                age => age >= 21;

            // Call the predicate with the number 22.
            // Since 22 is at least 21, this displays true.
            Console.WriteLine($"\nIs 22 old enough? {isOldEnough(22)}");

            // Call the predicate with the number 17.
            // Since 17 is below 21, this displays false.
            Console.WriteLine($"Is 17 old enough? {isOldEnough(17)}");

            // Use the Find method on the books list.
            //
            // Find checks each book using the lambda.
            // It returns the first book published in or after 2015.
            //
            // Find only returns one Book object, not a full list.
            Book recentBook =
                books.Find(book => book.YearPublished >= 2015);

            // Check that Find actually found a book.
            //
            // null means that there is no object.
            // If no matching book was found, recentBook would be null.
            if (recentBook != null)
            {
                // Display the title of the first recent book found.
                Console.WriteLine(
                    $"\nFirst recent book: {recentBook.Title}");
            }

            // Use FindAll to find every book whose title starts with C.
            //
            // StartsWith returns true when the title begins
            // with the text placed inside its brackets.
            //
            // Unlike Find, FindAll returns a list of all matches.
            List<Book> booksStartingWithC =
                books.FindAll(book => book.Title.StartsWith("C"));

            // Display a heading.
            Console.WriteLine("\nBooks beginning with C:");

            // ForEach runs an action once for every book in the list.
            //
            // The lambda accepts the current book and displays its title.
            booksStartingWithC.ForEach(
                book => Console.WriteLine(book.Title));

            // Use the LINQ Average method to calculate the average price.
            //
            // The lambda tells Average which value it should take
            // from each Book object.
            //
            // In this case, it takes the Price property from each book.
            decimal averagePrice =
                books.Average(book => book.Price);

            // Display the average price.
            //
            // F2 means display the decimal number using two decimal places.
            Console.WriteLine(
                $"\nAverage price: £{averagePrice:F2}");
        }
    }
}
