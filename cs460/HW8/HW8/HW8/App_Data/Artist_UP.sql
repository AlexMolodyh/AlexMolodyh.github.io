CREATE TABLE dbo.Artist
(
	ArtistName NVARCHAR(50) NOT NULL,
	DOB DATETIME2 NOT NULL,
	BirthCity NCHAR(100) NOT NULL,
	CONSTRAINT [PK_dbo.ArtistName] PRIMARY KEY CLUSTERED (ArtistName ASC)
);
GO

INSERT INTO dbo.Artist
(
    ArtistName,
    DOB,
    BirthCity
)
VALUES
    ('MC Escher', DATETIME2FROMPARTS(1898,6,17,1,1,1,5,1), 'Leeuwarden, Netherlands'),
	('Leonardo Da Vinci', DATETIME2FROMPARTS(1519, 5, 2,1,1,1,5,1), 'Vinci, Italy'),
	('Hatip Mehmed Efendi', DATETIME2FROMPARTS(1680, 11, 18,1,1,1,5,1), 'Unknown'),
	('Salvador Dali', DATETIME2FROMPARTS(1904, 5, 11,1,1,1,5,1), 'Figueres, Spain');
GO