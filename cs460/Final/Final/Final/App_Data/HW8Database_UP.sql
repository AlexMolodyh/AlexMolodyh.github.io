/*
 * Author: Alexander Molodyh
 * Date: 11/28/2017
 * Class: CS460
 * Assignment: Final
 *
 */

/*Artist table*/
CREATE TABLE [Buyer]
(
	[BuyerName] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.BuyerID] PRIMARY KEY CLUSTERED ([BuyerName] ASC)
);


/*ArtWork table*/
CREATE TABLE [Item]
(
	[ItemID] INT IDENTITY (1,1) NOT NULL,
	[ItemName] NVARCHAR(100) NOT NULL,
	[ItemDescription] NVARCHAR(300) NOT NULL,
	[SellerName] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.ItemID] PRIMARY KEY CLUSTERED ([ItemID]),
	CONSTRAINT [ItemSeller] FOREIGN KEY (SellerName) REFERENCES dbo.Seller(SellerName)
);


/*Genre table*/
CREATE TABLE [Seller]
(
	[SellerName] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.SellerID] PRIMARY KEY CLUSTERED ([SellerName] ASC)
);


/*Classification table*/
CREATE TABLE [Bid]
(
	[ItemID] INT NOT NULL,
	[BuyerName] NVARCHAR(50) NOT NULL,
	[Price] MONEY NOT NULL,
	[TimeStamp] DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.BidID] PRIMARY KEY CLUSTERED ([ItemID], [BuyerName]),
	CONSTRAINT [BuyerBids] FOREIGN KEY ([BuyerName]) REFERENCES [Buyer] ([BuyerName]),
	CONSTRAINT [ItemBiders] FOREIGN KEY ([ItemID]) REFERENCES [Item] ([ItemID])
);



/*Artist sample data*/
INSERT INTO [Buyer]
(
    BuyerName
)
VALUES
    ('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall');


/*Genre sample data*/
INSERT INTO [Seller]
(
    SellerName
)
VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene');


/*ArtWork sample data*/
INSERT INTO [Item]
(
    ItemName,
	ItemDescription,
	SellerName
)
VALUES
	('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 'Pearl Geene'),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 'Gayle Hardy'),
	('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 'Lyle Banks');


/*Classification sample data*/
INSERT INTO [Bid]
(
	ItemID,
	BuyerName,
	Price,
	[TimeStamp]
)
VALUES
	(1001, 'Otto Vanderwall', 250000,'12/04/2017 09:04:22'),
	(1003, 'Jane Stone', 95000 ,'12/04/2017 08:44:03');
GO