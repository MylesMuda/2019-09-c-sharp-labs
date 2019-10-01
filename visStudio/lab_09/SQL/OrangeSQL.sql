USE MASTER
go
drop database if exists OrangeDb
go
create database OrangeDb
go
use OrangeDb
go

create table Categories(
	CategoryID int not null identity primary key,
	CategoryName nvarchar(50) null
)

create table Oranges( 
	OrangeID int not null IDENTITY PRIMARY KEY,
	OrangeName NVARCHAR(50) NULL,
	DateHarvested Date null,
	IsLuxuryGrade bit null,
	CategoryID int null foreign key references Categories(CategoryID)
)


create table Batch(
	BatchID int not null identity primary key,
	OrangeID int null foreign key references Oranges(OrangeID),
	Quality int null,
	DispatchDate date null
)

/* POPULATE THE MINOR CATEGORY TABLE FIRST*/

insert into Categories values('clementines');
insert into Categories values('reds');
insert into Categories values('easy peelers');

insert into Oranges values ('Clementine','2019-09-07', 0, 1);
insert into Oranges values ('Blood Orange','2019-09-01',0, 2);
insert into Oranges values ('Tangerine','2019-08-30', 1, 3);
insert into Oranges values ('Clementine','2018-12-25', 0, 1);

insert into Batch values(1, 100, GETDATE());
insert into Batch values(2, 100, GETDATE());
insert into Batch values(3, 100, GETDATE());
insert into Batch values(4, 50, '2019-08-01');

select * from Oranges;
select * from Categories;

--Expiry date = harvested date + 90 days
select OrangeID, OrangeName, CategoryName, DateHarvested, DATEADD(d,90, DateHarvested) as 'ExpiryDate' from Oranges
inner join Categories on Oranges.CategoryID = Categories.CategoryID;

select OrangeName, Oranges.CategoryID as CategoryID from Oranges
inner join Categories on Oranges.CategoryID = Categories.CategoryID;

select *, DATEDIFF(d, Oranges.DateHarvested, getdate()) as 'SinceHarvested',
case
when (DATEDIFF(d, Oranges.DateHarvested, getdate()) > 90) then 'true'
else 'false'
end
as 'IsExpired'
from Batch
inner join Oranges on Oranges.OrangeID = Batch.OrangeID;