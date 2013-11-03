CREATE TABLE [dbo].[TableMeal]
(
	[Id] BIGINT identity(1,1) PRIMARY KEY, 
    [TableId] BIGINT NOT NULL, 
    [TableMealStatusId] BIGINT NOT NULL, 
    [StartedTime] DATETIME2 NULL, 
    [EndedTime] DATETIME2 NULL, 
    [NumberOfPeople] INT NULL, 
    [UpdatedBy] BIGINT NOT NULL, 
    [UpdatedDateTime] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_TableMeal_Table] FOREIGN KEY ([TableId]) REFERENCES [Table]([Id]), 
    CONSTRAINT [FK_TableMeal_TableMealStatus] FOREIGN KEY ([TableMealStatusId]) REFERENCES [TableMealStatus]([Id]), 
    CONSTRAINT [FK_TableMeal_User] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([Id])
)
