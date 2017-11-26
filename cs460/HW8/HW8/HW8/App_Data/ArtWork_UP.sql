CREATE TABLE dbo.ArtWork 
(
	ArtWorkTitle NVARCHAR(50) NOT NULL,
	Artist NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_dbo.ArtWorkTitle] PRIMARY KEY CLUSTERED (ArtWorkTitle ASC),
	CONSTRAINT [FK_dbo.Artist] FOREIGN KEY (Artist) REFERENCES dbo.Artist(ArtistName)
);
GO

INSERT INTO dbo.ArtWork
(
    ArtWorkTitle,
    Artist
)
VALUES
(   'Circle Limit III', 'M.C. Escher' ),
(   'Twon Tree', 'M.C. Escher' ),
(   'Mona Lisa', 'Leonardo Da Vinci' ),
(   'The Vitruvian Man', 'Leonardo Da Vinci' ),
(   'Ebru', 'Hatip Mehmed Efendi' ),
(   'Honey Is Sweeter Than Blood', 'Salvador Dali' );
GO