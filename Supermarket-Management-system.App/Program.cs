using Supermarket_Management_system.Core;
using System;

var service = new ProductService();
service.LoadFromDatabase();

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("==Supermarket Management System==");
    Console.WriteLine("1. List all products (sorted by name)");
    Console.WriteLine("2. Find product by barcode");
    Console.WriteLine("3. Find product by name");
    Console.WriteLine("4. Add a product");
    Console.WriteLine("5. Low-stock report");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ListAllProducts();
            break;
        case "2":
            FindByBarcode();
            break;
        case "3":
            FindByName();   
            break;
        case "4":
            AddProduct();
            break;
        case "5":
            // TODO later
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}

Console.WriteLine("Goodbye...");

 void FindByBarcode()
{
    Console.Write("Enter Barcode: ");
    string barcode = Console.ReadLine();

    Product result = service.FindByBarcode(barcode);

    if (result == null)
    {
        Console.WriteLine("No product found with that barcode");
    }
    else
    {
        Console.WriteLine($"Found: {result.Title} - £{result.Price} - barcode {result.Barcode}");
    }
}

void FindByName()
{
    Console.Write("Enter product name: ");
    string name = Console.ReadLine();


    Product result = service.FindByName(name);

    if (result == null)
    {
        Console.WriteLine("no product found with that name");
    }
    else
    {
        Console.WriteLine($"Found: {result.Title} - £{result.Price} - barcode {result.Barcode}");
    }
}

void ListAllProducts()
{
    Console.WriteLine();
    Console.WriteLine("--- All Products ---");
    foreach (var p in service.GetAllSortedByName())
    {
        Console.WriteLine($"{p.Title} — {p.Barcode} — £{p.Price}");
    }
}

void AddProduct()
{
    Console.Write("Title: ");
    string title = Console.ReadLine();

    Console.WriteLine("Barcode(7 characters): ");
    string barcode = Console.ReadLine();

    Console.Write("Price: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        Console.WriteLine("Invalid price - must be a number.");
        return;
    }

    Console.WriteLine("Category ID: ");
    if (!int.TryParse(Console.ReadLine(), out int categoryId))
    {
        Console.WriteLine("Invalid category ID. ");
        return;
    }

    Console.Write("Supllier ID: ");
    if (!int.TryParse(Console.ReadLine(), out int supplierId))
    {
        Console.WriteLine("Invalid supplier ID.");
        return;
    }
    Console.Write("Quantity in stock: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity))
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    Console.Write("Reorder level: ");
    if (!int.TryParse(Console.ReadLine(), out int reorderLevel))
            {
        Console.WriteLine("Invalid reorder level.");
        return;
    }

    var product = new Product
    {
        Title = title,
        Barcode = barcode,
        Price = price,
        CategoryId = categoryId,
        SupplierId = supplierId,
        ExpiryDate = DateTime.Now.AddMonths(6)
    };

    string error = service.AddProduct(product, quantity, reorderLevel);

    if (error == null)
    {
        Console.WriteLine("Product added successfully.");
    }
    else
    {
        Console.WriteLine($"error: {error}");
    }

}