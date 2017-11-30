# ASP.Net MVC 5 Artist Database

## I'll be demonstrating the artist database web app here. I'll cover what the pages are and how to use the artist management pages.

### The following are links to github for the code used in the artist database web app.

[ArtWorks Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/ArtWorksController.cs)

[Artist Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/ArtistsController.cs)

[Classification Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/ClassificationsController.cs)

[Home Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/HomeController.cs)

[ArtDBContext](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/DAL/ArtDBContext.cs)

[ArtList Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/ArtList.cs)

[Artist Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/Artist.cs)

[ArtWork Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/ArtWork.cs)

[Genre Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/Genre.cs)

[DateValidation Custom Attribute](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/DateValidationAtt.cs)

[JS Cutom Script](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Scripts/asyncWorker.js)

[CSS File](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Content/myStyle.css)

[Database Up Script](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/App_Data/HW8Database_UP.sql)

[Database Down Script](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/App_Data/HW8Database_DOWN.sql)

[Connection Config File](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/connections.config)

[Home Index View](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Views/Home/Index.cshtml)

[Artist Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Artists)

[ArtWork Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/ArtWorks)

[Classification Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Classifications)

[Genre Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Genres)

[Shared Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Shared)


## **The Database ER Diagram**

#### I used Toad Data Modeler to create the ER Diagram.

![Database ER Diagram](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/HW8_ER_Diagram.PNG?raw=true)

## **The Homepage**

#### The homepage has a list of buttons with different genres. Each button will display a list of artworks by their genres. A loading spinner will display while the content is being retrieved so that you knwo it's doing something in the background. Once the artwork has been retrieved, it will be displayed using ajax.

![Homepage Index](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/home_page.PNG?raw=true)


## **The following will display the genre button functions**

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


#### Code used to create the genre buttons.

```csharp
<div class="home-page-genre-list">
    @foreach (string genre in genres)
    {
        @*Must use input to pass button instance as "this" not bootstrap button*@
        <input type="button" class="btn btn-default" onclick="getArtWorkByGenre(this)" value="@($"{genre}")" />
    }
</div>

<br />
```


#### This is the code used to populate the tables of genre artworks.
```javascript
function getArtWorkByGenre(btnObj) {
    console.log("Button clicked is: " + btnObj.value);
    var table = $("#genre-table");
    table.empty();

    document.tSpinner = setTimeout("showSpinner()", 300);

    $.ajax({
        type: "get",
        datatype: "json",
        url: "/Home/GenreArtWork",
        data: { genre: btnObj.value},
        success: function (data) {
            clearTimeout(document.tSpinner);
            populateTable(data);
        },
        error: function () {
            alert("didn't work!");
        }
    });
}


function populateTable(genreList) {
    hideSpinner();
    var table = $("#genre-table");
    table.empty();

    var tr = $("<tr></tr>");
    var th1 = $("<th>ArtWork</th>");
    var th2 = $("<th>Genre</th>");
    tr.append(th1);
    tr.append(th2);

    //Builds the rest of the table.
    table.append(tr);
    for (var i = 0; i < genreList.Size; i++) {
        var tr1 = $("<tr></tr>");
        var tdArtWork = $("<td>" + genreList.ArtList[i] + "</td>");
        var tdGenre = $("<td>" + genreList.GenreName + "</td>");

        tr1.append(tdArtWork);
        tr1.append(tdGenre);
        table.append(tr1);
    }
}

/**
 * Section opening and closing the spinner when the page loads
 */
//$(".navLink").click(function () {
//    console.log("Artist clicked");
//    showSpinner();
//});

$(window).on("beforeunload", function () {
    showSpinner();
});

$(window).on("unload", function () {
    console.log("hello");
    hideSpinner();
});

$(window).load(hideSpinner());


function showSpinner() {
    $(".overlay").show();
    $(".loader").show();
}

function hideSpinner() {
    $(".overlay").hide();
    $(".loader").hide();
}
```

## **The following is a demonstration of the Artist creation and manipulation**

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

#### I used a connection string in a separate file outside of the repository. When deploying the app to azure I would take out the connection string from web.config because I have set a connection string in azure for the database. I need the connection string in web.config only when debugging the app on my local machine.

```xml
<connectionStrings>
  <add name="ArtDBContext" connectionString="data source=hw9server.database.windows.net;initial catalog=HW8Database;user id=Almania;password=Fenyacam@20;multipleactiveresultsets=True;application name=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>

<!--I reference the file with the following code in web.config inside the <configuration></configuration> brackets-->
<connectionStrings configSource="connections.config" />
```

#### I made a custom attribute for checking if the date for an artist date of birth is in the future.
```csharp
public class DateValidationAtt : ValidationAttribute
    {

        /*Validates the date entered so that it's not in the future*/
        public override bool IsValid(object value)
        {
            DateTime dt = Convert.ToDateTime(value);
            return dt < DateTime.Now;
        }
    }
```


#### This is my css that I used.

```css
/*table style*/

.myTable {
    border-collapse: collapse;
    width: 100%;
}

th,
td {
    padding: 12px;
    text-align: left;
}

th {
    background-color: #3949AB;
    color: white;
}

tr:nth-child(even) {
    background-color: #f2f2f2
}

.form-control {
    border: solid 2px;
    border-color: #b9b4b4;
    border-radius: 0px;
    background-color: #fffef7;
}

.btn.btn-default {
    background-color: #4054c1;
    border-radius: 0px;
    color: white;
    font-size: 16px;
    padding-left: 35px;
    padding-right: 35px;
}

#main-page-title {
    margin-top: 40px;
}

.home-page-genre-list {
    margin-top: 20px;
    margin-bottom: 20px;
    margin-left: 25%;
}

.control-label {
    color: #515151;
}

.title-h2 {
    color: #515151;
    text-align: center;
}

a {
    color: #4054c1;
}

#genre-table {
    min-width: 100%;
}

/*Main page loading spinner*/
.loader {
    position: fixed;
    border-top: 10px solid #4054c1;
    border-right: 10px solid #aef0ff;
    border-bottom: 10px solid #4054c1;
    border-left: 10px solid #aef0ff;
    border-radius: 50%;
    width: 130px;
    height: 130px;
    animation: spin 2s linear infinite;
    background-position: center;
    /*Center the spinner in center of screen*/
    left: 50%;
    top: 50%;
    margin-left: -65px;
    margin-top: -65px;
}

@keyframes spin {
    0% {
        transform: rotate(0deg);
    }

    80% {
        transform: rotate(360deg);
    }
}

.overlay {
    background: #e9e9e9; 
    display: none;
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    opacity: 0.5;
}
```