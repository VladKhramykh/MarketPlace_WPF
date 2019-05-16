drop database NewMarketPlace;
create database NewMarketPlace;

use NewMarketPlace;
create table Users
(
	id int primary key identity(1,1),
	firstName nvarchar(30),
	secondName nvarchar(30),
	mail nvarchar(50),
	password nvarchar(100),
	telNumber varchar(20),
	about nvarchar(1000),
	image varbinary(MAX),
	privilege nvarchar(5) default 'user'
);

create table Regions
(
	id int primary key identity(0,1),
	region nvarchar(50)
);

create table TmpAnnouncements
(
	id int primary key identity(1,1),
	name nvarchar(50),
	seller int foreign key references Users(id),
	idRegion int foreign key references Regions(id),
	category nvarchar(50),
	about nvarchar(1000),
	cost money
);


create table Announcements
(
	id int primary key identity(1,1),
	name nvarchar(50),
	seller int foreign key references Users(id),
	idRegion int foreign key references Regions(id),
	category nvarchar(50),
	about nvarchar(1000),
	cost money
);

insert into Regions (region) values('Все');
insert into Regions (region) values('Брестская');
insert into Regions (region) values('Витебская');
insert into Regions (region) values('Гомельская');
insert into Regions (region) values('Гродненская');
insert into Regions (region) values('Минская');
insert into Regions (region) values('Могилёвская');
insert into Regions (region) values('Минск');