CREATE TABLE [dbo].[TableMeal]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [TableId] BIGINT NOT NULL, 
    [TableStatusId] BIGINT NOT NULL, 
    [StartedTime] DATETIME2 NULL, 
    [EndedTime] DATETIME2 NULL, 
    [NumberOfPeople] INT NULL, 
    CONSTRAINT [FK_TableMeal_Table] FOREIGN KEY ([TableId]) REFERENCES [Table]([Id]), 
    CONSTRAINT [FK_TableMeal_TableStatus] FOREIGN KEY ([TableStatusId]) REFERENCES [TableStatus]([Id])
)
