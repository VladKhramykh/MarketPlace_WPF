create database MarketPlace;

use MarketPlace;
create table Users
(
	id int primary key identity(1,1),
	firstName nvarchar(30),
	secondName nvarchar(30),
	mail nvarchar(50),
	password nvarchar(100),
	telNumber varchar(20),
	about nvarchar(1000),
	privilege nvarchar(5) default 'user'
);

create table ActualProduct
(
	id int primary key identity(1,1),
	name nvarchar(50),
	seller int foreign key references Users(id),
	category nvarchar(50),
	about nvarchar(1000),
	cost money
);

create table TmpProduct
(
	id int primary key identity(1,1),
	name nvarchar(50),
	seller int foreign key references Users(id),
	category nvarchar(50),
	about nvarchar(1000),
	cost money
);

