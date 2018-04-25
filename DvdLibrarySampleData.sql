Use DvdLibrary
GO

INSERT INTO Director([Name]) VALUES ('Stanley Kubrich'), ('Steven Speilberg'), ('Edgar Wright'), ('Wes Anderson'), ('Hideaki Anno'),('Robert Zemeckis');
GO

INSERT INTO RATING (Rating) VALUES('G'), ('PG'),('PG-13'),('R'),('NC-17'),('X'),('Not Rated');
GO

INSERT INTO DVD (Title,ReleaseYear,DirectorID,RatingID,Notes) VALUES ('Doctor StrangeLove', '1964',1,2,'favorite movie'), ('ET', '1982', 2,2,'its okay'),('Hot Fuzz','2007',3, 4, 'pretty good');
GO
