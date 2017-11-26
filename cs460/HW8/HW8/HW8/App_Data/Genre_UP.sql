CREATE TABLE dbo.Genre
(
	GenreName NVARCHAR(40) NOT NULL,
	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED (GenreName ASC)
);
GO

INSERT INTO dbo.Genre
(
    GenreName
)
VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');
GO