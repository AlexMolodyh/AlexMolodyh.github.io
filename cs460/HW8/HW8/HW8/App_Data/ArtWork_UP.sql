CREATE TABLE dbo.ARTWORK 
(
	ArtWorkTitle NVARCHAR(50) NOT NULL,
	Artist NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_dbo.ArtWorkTitle] PRIMARY KEY CLUSTERED (ArtWorkTitle ASC),
	CONSTRAINT [FK_dbo.Artist] FOREIGN KEY (Artist) REFERENCES dbo.ARTIST(ArtistName)
);
GO

INSERT INTO dbo.ARTWORK
(
    ArtWorkTitle,
    Artist
)
VALUES
(   'Circle Limit III', 'M.C. Escher' )