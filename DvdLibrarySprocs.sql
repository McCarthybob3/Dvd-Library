Use DvdLibrary
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RetreiveDvdByID')
BEGIN
   DROP PROCEDURE RetreiveDvdByID
END
GO
 
CREATE PROCEDURE RetreiveDvdByID (
    @DvdID INT 
)
AS
    SELECT D.DvdID, D.Title, D.ReleaseYear,Dir.[Name],R.Rating, D.Notes
    FROM DVD D
        INNER JOIN Rating R ON D.RatingID = R.RatingID
        INNER JOIN Director DIR ON D.DirectorID=DIR.DirectorID
    WHERE D.DvdID = @DvdID
GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RetreivingAllDvds')
BEGIN
   DROP PROCEDURE RetreivingAllDvds
END
GO

 
CREATE PROCEDURE RetreivingAllDvds 
AS
    SELECT D.DvdID, D.Title, D.ReleaseYear,Dir.Name,R.Rating, D.Notes
    FROM DVD D
        INNER JOIN Rating R ON D.RatingID = R.RatingID
        INNER JOIN Director DIR ON D.DirectorID=DIR.DirectorID
    
GO



IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RetreiveDvdByTitle')
BEGIN
   DROP PROCEDURE RetreiveDvdByTitle
END
GO
 
CREATE PROCEDURE RetreiveDvdByTitle (
    @DvdTitle char(200)
)
AS
    SELECT D.DvdID, D.Title, D.ReleaseYear,Dir.[Name],R.Rating, D.Notes
    FROM DVD D
        INNER JOIN Rating R ON D.RatingID = R.RatingID
        INNER JOIN Director DIR ON D.DirectorID=DIR.DirectorID
    WHERE D.Title = @DvdTitle
GO



IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RetreiveDvdByReleaseYear')
BEGIN
   DROP PROCEDURE RetreiveDvdByReleaseYear
END
GO
 
CREATE PROCEDURE RetreiveDvdByReleaseYear (
    @ReleaseYear SmallInt
)
AS
    SELECT D.DvdID, D.Title, D.ReleaseYear,Dir.[Name],R.Rating
    FROM DVD D
        INNER JOIN Rating R ON D.RatingID = R.RatingID
        INNER JOIN Director DIR ON D.DirectorID=DIR.DirectorID
    WHERE D.ReleaseYear = @ReleaseYear
GO



IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RetreiveDvdByDirectorName')
BEGIN
   DROP PROCEDURE RetreiveDvdByDirectorName
END
GO
 
CREATE PROCEDURE RetreiveDvdByDirectorName (
    @DirectorName char(40)
)
AS
    SELECT D.DvdID, D.Title, D.ReleaseYear,Dir.[Name],R.Rating, D.Notes
    FROM DVD D
        INNER JOIN Rating R ON D.RatingID = R.RatingID
        INNER JOIN Director DIR ON D.DirectorID=DIR.DirectorID
    WHERE Dir.Name = @DirectorName
GO




IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RetreiveDvdByRating')
BEGIN
   DROP PROCEDURE RetreiveDvdByRating
END
GO
 
CREATE PROCEDURE RetreiveDvdByRating (
    @Rating char(10)
)
AS
    SELECT D.DvdID, D.Title, D.ReleaseYear,Dir.[Name],R.Rating,D.Notes
    FROM DVD D
        INNER JOIN Rating R ON D.RatingID = R.RatingID
        INNER JOIN Director DIR ON D.DirectorID=DIR.DirectorID
    WHERE R.Rating = @Rating
GO


IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateNewDvd')
BEGIN
   DROP PROCEDURE CreateNewDvd
END
GO
 
CREATE PROCEDURE CreateNewDvd(
@DvdId INT,
   @Title CHAR(200),
   @DirectorName CHAR(40),
   @Rating CHAR(20), 
   @ReleaseYear char(5),
   @Notes CHAR(200),
   @DirectorID INT,
   @RatingID TINYINT
)
AS
   begin
   if NOT EXISTS(
   select*from Director
   where Director.[Name] = @DirectorName
   )begin 
   insert into Director ([Name]) values(@DirectorName)
   SET @DirectorID = SCOPE_IDENTITY() 
   end
   else
   set @DirectorID = (select DirectorID from Director where [Name] = @DirectorName)
   set @RatingID = (select RatingID from Rating where Rating=@Rating)
 
     INSERT INTO DVD(Title,ReleaseYear,DirectorID,RatingID,Notes) VALUES(@Title,@ReleaseYear,@DirectorID,@RatingID, @Notes)
	   set @DvdId = SCOPE_IDENTITY()
 end
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateDvd')
      DROP PROCEDURE UpdateDvd
GO

CREATE PROCEDURE UpdateDvd (
	@DvdId INT,
   @Title CHAR(200),
   @DirectorName CHAR(40),
   @Rating CHAR(20), 
   @ReleaseYear char(5),
   @Notes CHAR(200),
   @DirectorID INT,
   @RatingID TINYINT
)
AS
	  begin
   if exists(
   select*from DVD
   where dvd.DvdID=@DvdId
   )
   begin
   if NOT EXISTS(
   select*from Director
   where Director.[Name] = @DirectorName
   )begin 
   insert into Director (Name) values(@DirectorName)
   SET @DirectorID = SCOPE_IDENTITY() 
   end
   else
   set @DirectorID = (select 1 DirectorID from Director where [Name] = @DirectorName)
   set @RatingID = (select 1 RatingID from Rating where Rating=@Rating)

   update DVD
   set Title=@Title,
   ReleaseYear=@ReleaseYear,
   DirectorID=@DirectorID,
   RatingID=@RatingID,
   Notes=@Notes
   where DvdID=@DvdId
 end
 end
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteDvd')
      DROP PROCEDURE DeleteDvd
GO

CREATE PROCEDURE DeleteDvd (
	@DvdId int
)
AS
	DELETE FROM DVD
	WHERE DvdID = @DvdId
GO
