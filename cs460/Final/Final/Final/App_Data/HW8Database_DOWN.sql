--/*
-- * Author: Alexander Molodyh
-- * Date: 11/28/2017
-- * Class: CS460
-- * Assignment: HW8
-- *
-- */


--/*Drop Classification Constraints*/
--ALTER TABLE dbo.Classification DROP CONSTRAINT [PK_dbo.ArtWork_Genre], [FK_dbo.ArtWork], [FK_dbo.Genre];
--GO

--/*Drop Classification table*/
--DROP TABLE dbo.Classification;
--GO



--/*Drop ArtWork table constraints*/
--ALTER TABLE dbo.ArtWork DROP CONSTRAINT [PK_dbo.ArtWorkTitle], [FK_dbo.Artist];
--GO

--/*Drop ArtWork table*/
--DROP TABLE dbo.ArtWork;
--GO



--/*Drop Artist constraints*/
--ALTER TABLE dbo.Artist DROP CONSTRAINT [PK_dbo.ArtistName];
--GO

--/*Drop Artist table*/
--DROP TABLE dbo.Artist;
--GO



--/*Drop Genre constraints*/
--ALTER TABLE dbo.Genre DROP CONSTRAINT [PK_dbo.Genre];
--GO

--/*Drop Genre table*/
--DROP TABLE dbo.Genre;
--GO