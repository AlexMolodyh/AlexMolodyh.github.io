CREATE TABLE dbo.Customers
(
	ID INT IDENTITY (1, 1) NOT NULL,
	CustomerNumber INT NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	MiddleName NVARCHAR(100) NULL,
	LastName NVARCHAR(100) NOT NULL,
	DOB DATETIME NOT NULL,
	NewAddress NVARCHAR(300) NOT NULL,
	NewCity NVARCHAR(80) NOT NULL,
	NewState NVARCHAR(2) NOT NULL,
	NewZip INT NOT NULL,
	NewCounty NVARCHAR(50) NOT NULL,
	ChangeDate DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED (ID ASC)
);
GO

INSERT INTO dbo.Customers
        ( CustomerNumber ,
          FirstName ,
          MiddleName ,
          LastName ,
          DOB ,
          NewAddress ,
          NewCity ,
          NewState ,
          NewZip ,
          NewCounty ,
          ChangeDate
        )
VALUES  ( 1563259 , 'Homer' , 'J' , 'Simpson' , '1958' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 1763259 , 'Marge' , '' , 'Simpson' , '1960' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 1504259 , 'Bart' , '' , 'Simpson' , '1980' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 9463259 , 'Lisa' , '' , 'Simpson' , '1982' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 9487259 , 'Maggie' , '' , 'Simpson' , '1989' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE());

GO