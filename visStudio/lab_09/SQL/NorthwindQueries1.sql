select top 5 * from customers order by CustomerID desc;

select * from Products;
select * from Products
where UnitsInStock < 10 and Discontinued = 0
order by UnitsInStock desc;

update Products set UnitsInStock=200 where ProductID=31;
select * from Products
where UnitsInStock < 10 and Discontinued = 0
order by UnitsInStock desc;

select country from customers order by country;
select distinct country from customers order by country;

select * from Products where ProductName like '%chai%'
select * from Products where ProductName like 'cha%'
select * from Products where ProductName not like 'cha%'

select distinct Region from Customers
select * from customers where Region in ('bc','ca','ak')

select * from products where unitprice between 10 and 20 order by UnitPrice desc;

select count(city) from Customers;
select AVG(UnitPrice) as AVGPrice, MIN(UnitPrice) as MINPrice, MAX(UnitPrice) as MAXPrice from Products
select SUM(Unitsinstock) as TotalStock from Products;

select * from [Order Details]

select distinct Products.ProductName, Products.UnitPrice, [Order Details].Discount, Products.UnitPrice - [Order Details].Discount as DiscountedPrice from [Order Details]
inner join Products on [Order Details].ProductID = Products.ProductID
order by DiscountedPrice desc;

--Get total of (quality*unitprice) as 'ordervalue'
SELECT sum(unitprice*quantity) from [Order Details]
--Get total of (1-discount) * 'ordervalue'
select sum(unitprice*quantity*(1-discount)) from [Order Details]

--difference
select
sum(unitprice*quantity) as GrossSales,
sum(unitprice*quantity*(1-discount)) as DiscountedSales,
--sum(unitprice*quantity) - sum(unitprice*quantity*(1-discount)) as 'Discount Given',
(sum(UnitPrice*Quantity*Discount)) as 'Discount Given'
from [Order Details];

--GROUP BY
select 'GROUP BY';
select SupplierID, sum(UnitsOnOrder) as 'Total Units in Order' from products
group by SupplierID
having sum(UnitsOnOrder) = 0
order by 'Total Units in Order' desc;