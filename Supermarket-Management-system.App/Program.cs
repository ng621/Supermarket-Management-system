using Supermarket_Management_system.Core;

var service = new ProductService();
service.LoadFromDatabase();

System.Console.WriteLine("==Products, sorted by name==");
foreach (var p in service.GetAllSortedByName())
{
    System.Console.WriteLine($"{p.Title} — {p.Barcode} — £{p.Price}");
}

System.Console.WriteLine();
System.Console.WriteLine("==Lookup by barcode 5012345678==");
var milk = service.FindByBarcode("5012345678");
System.Console.WriteLine(milk != null ? $"Found: {milk.Title}" : "Not found");