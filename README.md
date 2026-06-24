# Supermarket Management System

A console-based supermarket management system for small shops, built in C# (.NET) 
with Entity Framework Core and SQL Server. Products are indexed in two custom 
data structures — a hash table (O(1) barcode lookup) and a binary search tree 
(O(log n) name search with sorted traversal), both implemented from scratch.

## Features
- Add products with validation (unique barcode, positive price, valid quantity)
- Find products by barcode (hash table) and by name (BST, case-insensitive)
- List all products in alphabetical order
- Record sales with automatic stock decrement
- Low stock report flagging items at or below their reorder level

## Requirements
- .NET SDK 10.0 or later
- SQL Server LocalDB (included with Visual Studio 2022)
- Visual Studio 2022  

## Project structure
- `Supermarket-Management-System.Core` — domain models, custom data structures, EF Core context, services
- `Supermarket-Management-System.App` — console user interface (entry point)
- `Supermarket-Management-System.Tests` — xUnit test project (11 unit tests)

## Database setup
The connection string targets LocalDB and is configured in 
`Supermarket-Management-System.Core/SupermarketContext.cs`:


Server=(localdb)\MSSQLLocalDB;Database=SupermarketDb;Trusted_Connection=True;

- Create the database from the included EF Core migration. In Visual Studio's 
Package Manager Console (with `Supermarket-Managemetn-System.Core` as the default project):

Then load the sample data by running `SeedData.sql` against the `SupermarketDb` 
database (via SQL Server Object Explorer → right-click database → New Query).

## Building and running
From the solution folder: 
dotnet build
dotnet run --project Supermarket.App


Or open `Supermarket-Management-System.sln` in Visual Studio and press F5.

## Running Tests
dotnet test

## Usage
## Usage
On launch, the system loads all products from the database into the in-memory 
structures, then presents a numbered menu

Enter the number for the operation you want and follow the prompts. For example, 
to record a sale, choose 6, enter the product's barcode and the quantity sold,  
the system validates stock availability and minuses it on success.

## Author
Nigel Gambiza — M00951628