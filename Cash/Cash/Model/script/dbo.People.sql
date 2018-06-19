CREATE TABLE [dbo].[People] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [login]      NVARCHAR (50) NOT NULL,
    [password]   NVARCHAR (50) NOT NULL,
    [name]       NVARCHAR (50) NOT NULL,
    [surname]    NVARCHAR (50) NOT NULL,
    [patronymic] NVARCHAR (50) NOT NULL,
    [rights] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [CK_People_Column] CHECK (rights < 3)
);

