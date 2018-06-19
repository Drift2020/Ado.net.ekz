CREATE TABLE [dbo].[Link_Final]
(
	[ID] INT NOT NULL IDENTITY, 
    [PersonID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Money] MONEY NOT NULL, 
    [Specification] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Link_Product_Category] PRIMARY KEY ([ID]), 
    CONSTRAINT [FK_Link_Product] FOREIGN KEY ([ProductID]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_Link__ToTable] FOREIGN KEY ([PersonID]) REFERENCES [People]([Id]), 
  
)
