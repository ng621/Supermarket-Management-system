-- Seed data 

INSERT INTO Categories (Name) VALUES
('Dairy'),        
('Bakery'),       
('Beverages');    

INSERT INTO Suppliers (Name, ContactInfo) VALUES
('FreshFarms Ltd', 'orders@freshfarms.mu'), 
('IslandBev Co',   'sales@islandbev.mu')

INSERT INTO Products (Title, Barcode, Price, ExpiryDate, CategoryId, SupplierId) VALUES
('Milk 2L',         '5012345678', 2.50, '2026-08-01', 1, 1), 
('Cheddar 500g',    '5012345685', 4.20, '2026-09-15', 1, 1), 
('White Bread',     '5012345692', 1.10, '2026-07-05', 2, 1), 
('Cola 1.5L',       '6273450912', 1.80, '2027-01-01', 3, 2), 
('Orange Juice 1L', '6273450929', 2.30, '2026-07-10', 3, 2); 

INSERT INTO Stocks (QuantityInStock, ReorderLevel, ProductId) VALUES
(40, 10, 1),   
(8,  10, 2),    
(25, 5,  3),   
(3,  6,  4),   
(15, 5,  5);   

INSERT INTO Sales (SaleDate, TotalAmount) VALUES
('2026-06-20', 6.80);    

INSERT INTO SaleItems (Quantity, UnitPrice, SaleId, ProductId) VALUES
(2, 2.50, 1, 1),    
(1, 1.80, 1, 4);   