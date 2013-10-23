CREATE TABLE [dbo].[ShiftType]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [RestaurantId] BIGINT NOT NULL, 
    [StartTime] DATETIME2 NULL, 
    [EndTime] DATETIME2 NULL, 
    CONSTRAINT [FK_ShiftType_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id])
)
