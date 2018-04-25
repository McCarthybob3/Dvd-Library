
if exists (select * from sysdatabases where name='DvdLibrary')
		drop database DvdLibrary
go

Create database DvdLibrary

CREATE TABLE Director(
DirectorID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
   [Name] CHAR(40) NOT NULL
)
GO

CREATE TABLE Rating(
RatingID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Rating CHAR(10) NOT NULL
)
GO

CREATE TABLE DVD(
DvdID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Title CHAR(200)NOT NULL,
ReleaseYear char(4) NOT NULL,
DirectorID INT NOT NULL,
RatingID INT NOT NULL, 
Notes CHAR(200) NULL

	CONSTRAINT FK_DvdLibrary_Rating
		FOREIGN KEY (RatingID) 
		REFERENCES Rating(RatingID),

		CONSTRAINT FK_DvdLibrary_Director
		FOREIGN KEY (DirectorID) 
		REFERENCES Director(DirectorID),

)