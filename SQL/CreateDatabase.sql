use RabbitDb
go

CREATE TABLE Rabbits(
	RabbitId INT NOT Null IDENTITY PRIMARY KEY,
	Age INT,
	Name VARCHAR(50) NULL 
);

select 'here is comment'

Update Rabbits Set Name = 'Greg' Where RabbitId = 1

Insert into Rabbits values (2, 'Thomas')

SET IDENTITY_INSERT Rabbits ON

delete from Rabbits where RabbitId=2

select * from Rabbits

