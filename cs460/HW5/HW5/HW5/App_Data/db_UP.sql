CREATE TABLE dbo.Customers
(
	ID INT IDENTITY (1, 1) NOT NULL,
	CustomerNumber INT NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	MiddleName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	DOB DATETIME NOT NULL,
	NewAddress NVARCHAR(300) NOT NULL,
	NewCity NVARCHAR(80) NOT NULL,
	NewState NVARCHAR(80) NOT NULL,
	NewZip INT NOT NULL,
	NewCounty NVARCHAR(50) NOT NULL,
	ChangeDate DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED (ID ASC)
);

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
VALUES  ( 0 , 'Homer' , 'J' , 'Simpson' , '1958' , '12345 New Springfield St' , 'New Springfield' , 'Oregon' , 97403 , 'Lane County' , GETDATE()),
		( 0 , 'Marge' , 'J' , 'Simpson' , '1960' , '12345 New Springfield St' , 'New Springfield' , 'Oregon' , 97403 , 'Lane County' , GETDATE()),
		( 0 , 'Bart' , 'J' , 'Simpson' , '1980' , '12345 New Springfield St' , 'New Springfield' , 'Oregon' , 97403 , 'Lane County' , GETDATE()),
		( 0 , 'Lisa' , 'J' , 'Simpson' , '1982' , '12345 New Springfield St' , 'New Springfield' , 'Oregon' , 97403 , 'Lane County' , GETDATE()),
		( 0 , 'Maggie' , 'J' , 'Simpson' , '1989' , '12345 New Springfield St' , 'New Springfield' , 'Oregon' , 97403 , 'Lane County' , GETDATE());
