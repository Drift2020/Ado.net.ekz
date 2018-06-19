CREATE TABLE [dbo].[Link_People_Family]
(
	[PeopleID] INT NULL,
    [FamilyID] INT NULL, 
    CONSTRAINT [FK_Link_To_People] FOREIGN KEY ([PeopleID]) REFERENCES [People](id), 
    CONSTRAINT [FK_Link_To_Family_ToTable] FOREIGN KEY ([FamilyID]) REFERENCES [Family](id) 
)
