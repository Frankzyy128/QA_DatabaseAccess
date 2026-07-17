Scaffold-DbContext
-provider Microsoft.EntityFrameworkCore.SqlServer
-connection "Data Source=(local);Initial Catalog=Northwind;Trusted_Connection=True;Encrypt=False"
-OutputDir Models
-Project EF1



using (NorthwindContext con = new NorthwindContext()) 
{ 
    var customers = con.Customers; 
    foreach (var customer in customers) 
    { 
        Console.WriteLine($"Company Name: {customer.CompanyName}, Contact 
Name: {customer.ContactName}, Phone: {customer.Phone}"); 
    } 
} 
