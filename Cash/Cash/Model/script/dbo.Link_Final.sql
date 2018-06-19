CREATE TABLE [dbo].[Link_Final] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [PersonID]          INT            NOT NULL,
    [ProductID]         INT            NOT NULL,
    [Date]              DATETIME       NOT NULL,
    [Money]             MONEY          NOT NULL,
    [Specification]     NVARCHAR (MAX) NULL,
    [Type _of_purchase] BIT            NOT NULL,
    CONSTRAINT [PK_Link_Product_Category] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Link_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Link__ToTable] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[People] ([Id])
);

