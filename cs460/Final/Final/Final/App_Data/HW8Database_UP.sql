--/*
-- * Author: Alexander Molodyh
-- * Date: 11/28/2017
-- * Class: CS460
-- * Assignment: HW8
-- *
-- */

--/*Artist table*/
--CREATE TABLE dbo.Artist
--(
--	ArtistName NVARCHAR(50) NOT NULL,
--	DOB DATETIME2 NOT NULL,
--	BirthCity NCHAR(100) NOT NULL,
--	CONSTRAINT [PK_dbo.ArtistName] PRIMARY KEY CLUSTERED (ArtistName ASC)
--);


--/*ArtWork table*/
--CREATE TABLE dbo.ArtWork 
--(
--	ArtWorkTitle NVARCHAR(50) NOT NULL,
--	Artist NVARCHAR(50) NOT NULL
--	CONSTRAINT [PK_dbo.ArtWorkTitle] PRIMARY KEY CLUSTERED (ArtWorkTitle ASC),
--	CONSTRAINT [FK_dbo.Artist] FOREIGN KEY (Artist) REFERENCES dbo.Artist(ArtistName)
--);


--/*Genre table*/
--CREATE TABLE dbo.Genre
--(
--	GenreName NVARCHAR(40) NOT NULL,
--	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED (GenreName ASC)
--);


--/*Classification table*/
--CREATE TABLE dbo.Classification
--(
--	ArtWork NVARCHAR(50) NOT NULL,
--	Genre NVARCHAR(40) NOT NULL,
--	CONSTRAINT [PK_dbo.ArtWork_Genre] PRIMARY KEY CLUSTERED (ArtWork, Genre ASC),
--	CONSTRAINT [FK_dbo.ArtWork] FOREIGN KEY (ArtWork) REFERENCES dbo.ArtWork(ArtWorkTitle),
--	CONSTRAINT [FK_dbo.Genre] FOREIGN KEY (Genre) REFERENCES dbo.Genre(GenreName)
--);


--/*Artist sample data*/
--INSERT INTO dbo.Artist
--(
--    ArtistName,
--    DOB,
--    BirthCity
--)
--VALUES
--    ('MC Escher', DATETIME2FROMPARTS(1898,6,17,1,1,1,5,1), 'Leeuwarden, Netherlands'),
--	('Leonardo Da Vinci', DATETIME2FROMPARTS(1519, 5, 2,1,1,1,5,1), 'Vinci, Italy'),
--	('Hatip Mehmed Efendi', DATETIME2FROMPARTS(1680, 11, 18,1,1,1,5,1), 'Unknown'),
--	('Salvador Dali', DATETIME2FROMPARTS(1904, 5, 11,1,1,1,5,1), 'Figueres, Spain');


--/*Genre sample data*/
--INSERT INTO dbo.Genre
--(
--    GenreName
--)
--VALUES
--('Tesselation'),
--('Surrealism'),
--('Portrait'),
--('Renaissance');


--/*ArtWork sample data*/
--INSERT INTO dbo.ArtWork
--(
--    ArtWorkTitle,
--    Artist
--)
--VALUES
--(   'Circle Limit III', 'MC Escher' ),
--(   'Twon Tree', 'MC Escher' ),
--(   'Mona Lisa', 'Leonardo Da Vinci' ),
--(   'The Vitruvian Man', 'Leonardo Da Vinci' ),
--(   'Ebru', 'Hatip Mehmed Efendi' ),
--(   'Honey Is Sweeter Than Blood', 'Salvador Dali' );


--/*Classification sample data*/
--INSERT INTO dbo.Classification
--(
--    ArtWork,
--    Genre
--)
--VALUES
--( 'Circle Limit III', 'Tesselation' ),
--( 'Twon Tree', 'Tesselation' ),
--( 'Twon Tree', 'Surrealism' ),
--( 'Mona Lisa', 'Portrait' ),
--( 'Mona Lisa', 'Renaissance' ),
--( 'The Vitruvian Man', 'Renaissance' ),
--( 'Ebru', 'Tesselation' ),
--( 'Honey Is Sweeter Than Blood', 'Surrealism' );
--GO