# ASP.Net MVC 5 Homework 9 Artist Database in Azure

## This demo page is the same as HW8 because I demonstrated HW8 in Azure. The database and web app were all in deployed in Azure already.

### The process that I went through to deploy in Azure.


#### Start new resource group

![New Resource Group](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/start_new_resource_group.PNG?raw=tru)

#### Create the a new empty database, resource group, and server.

![New Database and Server](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/create_new_database_and_server.PNG?raw=tru)


#### Allow IP address in server

![Allow IP Address](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/allow_ip_addresses.PNG?raw=tru)


#### Create new Web App

![New Web App](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/create_new_web_app.PNG?raw=true)


#### Database connection string location

![Connection String](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/copy_connection_string.PNG?raw=tru)


#### Enter connection string in application settings

![Enter Connection String](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/enter_connection_string.PNG?raw=tru)


#### Enter deployment credentials

![Deployment Credentials](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/setup_deployment_credentials.PNG?raw=tru)


#### Set up new connection in ADO

![ADO Connection](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/setup_new_connection_in_ADO.PNG?raw=tru)

#### Publish app

![Publish](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/publish.png?raw=tru)

#### Deploy app

![Deploy](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW9/img/deploy_app.PNG?raw=tru)

## **The Homepage**

#### The homepage has a list of buttons with different genres. Each button will display a list of artworks by their genres. A loading spinner will display while the content is being retrieved so that you knwo it's doing something in the background. Once the artwork has been retrieved, it will be displayed using ajax.

![Homepage Index](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/home_page.PNG?raw=true)


#### After clicking a genre button a spinner pops up so the user knows it is working on the request. 

![Homepage spinner](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/spinner.PNG?raw=true)

#### List of portrait genres.

![Portrait Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/portrait_genre.PNG?raw=true)

#### List of renaissance genres.

![Renaissance Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/renaissance_list.PNG?raw=true)

#### List of surrealism genres.

![Surrealism Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/surrealism_genre.PNG?raw=true)

#### List of tesselation genres.

![Tesselation Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/tesselation_genre.PNG?raw=true)

### **The following is a demonstration of Artist creation and manipulation**

#### Creating an artist.

![Artist List](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_list.PNG?raw=true)


#### Entering invalid data into the name and place of birth.

![Create Artist Bad Name](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/create_new_artist_page_with_wrong_name_and_birth_city.png?raw=tru)


#### Entering invalid date.

![Artist Invalid Date](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/create_new_artist_page_with_future_date.png?raw=true)


#### Entering valid data for a user.

![Artist Good Input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/create_new_artist_page_good_data.png?raw=true)


#### Artist list after creating John Birks.

![Artist John Birks](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_list_new_artists.PNG?raw=true)


#### Artist details page.

![Artist Details](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_details_page.PNG?raw=true)


#### Updating an artist.

![Artist Update](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/update_artist.PNG?raw=true)


#### Delete artist page.

![Artist Delete](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/delete_artist_page.PNG?raw=true)


#### After deleting Alexander Molodyh.

![Artist Deleted](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_deleted.PNG?raw=true)


## A list of ArtWork

![ArtWork List](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artwork_list.PNG?raw=true)


## A list fo Classifications.

![Classification](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/classification.PNG?raw=true)


## These are the database tables with the sample data.

#### Artist table

![Artist Table](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_table.PNG?raw=true)

#### ArtWork table

![ArtWork Table](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artwork_table.PNG?raw=true)

#### Genre table

![Genre Table](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/genre_table.PNG?raw=true)

#### Classification table

![Classification Table](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/classification_table.PNG?raw=true)


#### The database up script

```sql
/*
 * Author: Alexander Molodyh
 * Date: 11/28/2017
 * Class: CS460
 * Assignment: HW8
 *
 */

/*Artist table*/
CREATE TABLE dbo.Artist
(
	ArtistName NVARCHAR(50) NOT NULL,
	DOB DATETIME2 NOT NULL,
	BirthCity NCHAR(100) NOT NULL,
	CONSTRAINT [PK_dbo.ArtistName] PRIMARY KEY CLUSTERED (ArtistName ASC)
);


/*ArtWork table*/
CREATE TABLE dbo.ArtWork 
(
	ArtWorkTitle NVARCHAR(50) NOT NULL,
	Artist NVARCHAR(50) NOT NULL
	CONSTRAINT [PK_dbo.ArtWorkTitle] PRIMARY KEY CLUSTERED (ArtWorkTitle ASC),
	CONSTRAINT [FK_dbo.Artist] FOREIGN KEY (Artist) REFERENCES dbo.Artist(ArtistName)
);


/*Genre table*/
CREATE TABLE dbo.Genre
(
	GenreName NVARCHAR(40) NOT NULL,
	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED (GenreName ASC)
);


/*Classification table*/
CREATE TABLE dbo.Classification
(
	ArtWork NVARCHAR(50) NOT NULL,
	Genre NVARCHAR(40) NOT NULL,
	CONSTRAINT [PK_dbo.ArtWork_Genre] PRIMARY KEY CLUSTERED (ArtWork, Genre ASC),
	CONSTRAINT [FK_dbo.ArtWork] FOREIGN KEY (ArtWork) REFERENCES dbo.ArtWork(ArtWorkTitle),
	CONSTRAINT [FK_dbo.Genre] FOREIGN KEY (Genre) REFERENCES dbo.Genre(GenreName)
);


/*Artist sample data*/
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


/*Genre sample data*/
INSERT INTO dbo.Genre
(
    GenreName
)
VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');


/*ArtWork sample data*/
INSERT INTO dbo.ArtWork
(
    ArtWorkTitle,
    Artist
)
VALUES
(   'Circle Limit III', 'MC Escher' ),
(   'Twon Tree', 'MC Escher' ),
(   'Mona Lisa', 'Leonardo Da Vinci' ),
(   'The Vitruvian Man', 'Leonardo Da Vinci' ),
(   'Ebru', 'Hatip Mehmed Efendi' ),
(   'Honey Is Sweeter Than Blood', 'Salvador Dali' );


/*Classification sample data*/
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
```

##### The database down script

```sql
/*
 * Author: Alexander Molodyh
 * Date: 11/28/2017
 * Class: CS460
 * Assignment: HW8
 *
 */


/*Drop Classification Constraints*/
ALTER TABLE dbo.Classification DROP CONSTRAINT [PK_dbo.ArtWork_Genre], [FK_dbo.ArtWork], [FK_dbo.Genre];
GO

/*Drop Classification table*/
DROP TABLE dbo.Classification;
GO



/*Drop ArtWork table constraints*/
ALTER TABLE dbo.ArtWork DROP CONSTRAINT [PK_dbo.ArtWorkTitle], [FK_dbo.Artist];
GO

/*Drop ArtWork table*/
DROP TABLE dbo.ArtWork;
GO



/*Drop Artist constraints*/
ALTER TABLE dbo.Artist DROP CONSTRAINT [PK_dbo.ArtistName];
GO

/*Drop Artist table*/
DROP TABLE dbo.Artist;
GO



/*Drop Genre constraints*/
ALTER TABLE dbo.Genre DROP CONSTRAINT [PK_dbo.Genre];
GO

/*Drop Genre table*/
DROP TABLE dbo.Genre;
GO
```

