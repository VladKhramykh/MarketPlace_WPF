create database MarketPlace;

use MarketPlace;
create table Users
(
	id int primary key identity(1,1),
	firstName nvarchar(30),
	secondName nvarchar(30),
	mail nvarchar(50),
	telNumber varchar(20),
	about nvarchar(1000),
	privilege nvarchar(5) default 'user'
);

create table actualProduct
(
	id int primary key identity(1,1),
	name nvarchar(50),
	seller int foreign key references Users(id),
	category nvarchar(50),
	about nvarchar(1000),
	cost money
);

create table tmpProduct
(
	id int primary key identity(1,1),
	name nvarchar(50),
	seller int foreign key references Users(id),
	category nvarchar(50),
	about nvarchar(1000),
	cost money
);