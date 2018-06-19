CREATE TABLE [dbo].[Link_Product_Category] (
    [CategoryID]       INT NOT NULL,
    [ProductID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryID]),
    CONSTRAINT [FK_Link_Product_ToProduct] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Link_Category_ToCategory] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([Id])
);

