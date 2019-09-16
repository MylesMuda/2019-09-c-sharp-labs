use master
go

drop database if exists RabbitDb
go

create database RabbitDb
go

use RabbitDb
go

create table Categories(
	CategoryID int NOT NULL identity primary key,
	CategoryName varchar(50) null
);

create table Rabbit(
	RabbitID int NOT NULL Identity primary key,
	Name NVARCHAR(30) NULL,
	Age Int null,
	CategoryID int null foreign key (CategoryID) references Categories(CategoryID)
);

insert into Categories values ('White');
insert into Categories values ('Black');
insert into Categories values ('Pink');
insert into Rabbit values ('Bongo', 10, 1);
insert into Rabbit values ('Bingo', 2, 2);

update Rabbit set CategoryID = 2 where RabbitID = 2;

select * from Rabbit

select * from Categories