USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='Testing123'
GO

USE DvdLibrary
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON RetreivingAllDvds TO DvdLibraryApp
GRANT EXECUTE ON RetreiveDvdByTitle TO DvdLibraryApp
GRANT EXECUTE ON RetreiveDvdByID TO DvdLibraryApp
GRANT EXECUTE ON CreateNewDvd TO DvdLibraryApp
GRANT EXECUTE ON UpdateDvd TO DvdLibraryApp
GRANT EXECUTE ON DeleteDvd TO DvdLibraryApp
GRANT EXECUTE ON RetreiveDvdByReleaseYear TO DvdLibraryApp
GRANT EXECUTE ON RetreiveDvdByRating TO DvdLibraryApp
GRANT EXECUTE ON RetreiveDvdByDirectorName TO DvdLibraryApp
GO