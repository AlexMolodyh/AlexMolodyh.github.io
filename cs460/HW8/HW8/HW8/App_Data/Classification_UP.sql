CREATE TABLE dbo.Classification
(
	ArtWork NVARCHAR(50) NOT NULL,
	Genre NVARCHAR(40) NOT NULL,
	CONSTRAINT [PK_dbo.ArtWork_Genre] PRIMARY KEY CLUSTERED (ArtWork, Genre ASC),
	CONSTRAINT [FK_dbo.ArtWork] FOREIGN KEY (ArtWork) REFERENCES dbo.ArtWork(ArtWorkTitle),
	CONSTRAINT [FK_dbo.Genre] FOREIGN KEY (Genre) REFERENCES dbo.Genre(GenreName)
);
GO

INSERT INTO dbo.Classification
(
    ArtWork,
    Genre
)
VALUES
( 'Circle Limit III', 'Tesselation' ),
( 'Twon Tree', 'Tesselation' ),
( 'Twon Tree', 'Surrealism' ),
( 'Mona Lisa', 'Portrait' ),
( 'Mona Lisa', 'Renaissance' ),
( 'The Vitruvian Man', 'Renaissance' ),
( 'Ebru', 'Tesselation' ),
( 'Honey Is Sweeter Than Blood', 'Surrealism' );
GO