CREATE TABLE [dbo].[Link_Product_Category]
(
	[ProductID] INT NULL, 
    [CateroryID] INT NOT NULL, 
    PRIMARY KEY ([CateroryID]), 
    CONSTRAINT [FK_Link_Product_ToProduct] FOREIGN KEY ([ProductID]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_Link_Category_ToCategory] FOREIGN KEY ([CateroryID]) REFERENCES [Category]([Id])
)
