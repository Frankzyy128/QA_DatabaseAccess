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
*/
