use master
go

drop database if exists GameStoreDb
go
create database GameStoreDb
go

use GameStoreDb
go

create table Games(
	GameID int not null identity primary key,
	GameName varchar(40) null,
	GameStock int null,
	GamePrice money null
)

create table customer(
	CustomerID int not null identity primary key,
	CustomerFName varchar(40) null,
	CustomerLName varchar(40) null,
	CustomerAddress varchar(50) null,
	CustomerEmail varchar(20) null,
	CustomerNumber char(11) null
)

create table orders(
	OrderID int not null identity primary key,
	OrderDate date null,
	OrderArrivalStatus bit null,
	CustomerID int null references customer(CustomerID),
	GameID int null references Games(GameID)
)

insert into games values('Overwatch', 50, £20);
insert into games values('Untitled Goose Game', 30, £20);
insert into games values('DOOM', 10, £40);
insert into games values('Forza Horizons 4', 50, £50);

insert into customer values('Big', 'Boss', 'Outer Heaven',  'venomsnake@dd.org', '12345678901');
insert into customer values('Big', 'Boss', 'Outer Heaven',  'venomsnake@dd.org', '12345678901');
insert into customer values('Big', 'Boss', 'Outer Heaven',  'venomsnake@dd.org', '12345678901');

insert into orders values(GETDATE(), 0, 1, 2)

update customer
set CustomerFName = 'Solid', CustomerLName = 'Snake'
where CustomerID = 2;

select * from Games;
select * from customer;
select OrderID, OrderDate, OrderArrivalStatus, customer.CustomerFName + ' ' + customer.CustomerLName as Customer, customer.CustomerAddress as CustomerAddress, Games.GameName as GameName from orders
inner join customer on orders.CustomerID = customer.CustomerID
inner join Games on orders.GameID = Games.GameID;
