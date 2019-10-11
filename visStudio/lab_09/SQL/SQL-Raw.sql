--1.1	Write a query that lists all Customers in either Paris or London. 
--      Include Customer ID, Company Name and all address fields.
select CustomerID, CompanyName, Address, City, PostalCode from Customers 
where City='Paris' or City = 'London'


-- 1.2	List all products stored in bottle.
select * from Products
inner join Suppliers on Products.SupplierID = Suppliers.SupplierID
where QuantityPerUnit like '%bottle%';

-- 1.3	Repeat question above, but add in the Supplier Name and Country.
select Suppliers.CompanyName, Suppliers.Country, * from Products
inner join Suppliers on Products.SupplierID = Suppliers.SupplierID
where QuantityPerUnit like '%bottle%';

--1.4	Write an SQL Statement that shows how many products there are in each category. 
--      Include Category Name in result set and list the highest number first.
select Categories.CategoryName as CategoryName, count(Products.CategoryID) as 'Number of products in Categories' from Products
inner join Categories on Products.CategoryID = Categories.CategoryID
GROUP by Categories.CategoryName
order by 'Number of products in Categories' desc;

--1.5	List all UK employees using concatenation to join their title of courtesy, first name and last name together. 
--      Also include their city of residence.
select CONCAT(Employees.FirstName, ' ', Employees.LastName) as 'Title of Coutesy', City from Employees

--1.6	List Sales Totals for all Sales Regions (via the Territories table using 4 joins) 
--      with a Sales Total greater than 1,000,000. 
--      Use rounding or FORMAT to present the numbers. 
SELECT RegionDescription, ROUND((SUM((Quantity*UnitPrice)*1-Discount)), 2) as 'Sales Total By Region'
FROM Region
INNER JOIN Territories on Territories.RegionID = Region.RegionID
INNER JOIN EmployeeTerritories on Territories.TerritoryID = EmployeeTerritories.TerritoryID
INNER JOIN Orders on EmployeeTerritories.EmployeeID = Orders.EmployeeID
INNER JOIN [Order Details] on [Order Details].OrderID = Orders.OrderID
GROUP BY RegionDescription
HAVING (SUM((Quantity*UnitPrice)*1-Discount) > 1000000); 
    
--1.7
--Count how many Orders have a Freight amount greater
--than 100.00 and either USA or UK as Ship Country.
select * from Orders
where ShipCountry IN ('USA', 'UK') and Freight > 100 
order by Freight asc
--1.8 Write an SQL Statement to identify the 
--Order Number of the Order
--with the highest amount 
--of discount applied to that order.
select top 1 OrderID, 
sum(UnitPrice * Quantity * Discount) as 'Discount Given'
from [Order Details]
Group by OrderID
order by sum(UnitPrice * Quantity * Discount) desc

--2.1
create table Spartans(
    SpartanID int not null identity primary key,
    SpartanFName varchar(20) null,
    SpartanLName varchar(20) null,
    SpartanUni varchar(40) null,
    Course varchar(30) null,
    Mark int null
)

<<<<<<< Updated upstream
select * from Spartans

-- 3.1
Select Employees.EmployeeID, Employees.FirstName, Employees.LastName, concat(Managers.FirstName, ' ', Managers.LastName) as ReportsTo from Employees
join Employees as Managers on Employees.ReportsTo = Managers.EmployeeID;

--3.2

select * from [Order Details]

select distinct * from Products where UnitsInStock > 100

select distinct Products.CategoryID from Products where UnitsInStock > 100

select 

select Freight from 
=======
--1.8	Write an SQL Statement to identify the Order Number of the Order with the highest amount of discount applied to that order.
-- (AMOUNT OF DISCOUNT APPLIED)
SELECT top 1 *
from [Order Details]
--where MAX(Discount) 
>>>>>>> Stashed changes
