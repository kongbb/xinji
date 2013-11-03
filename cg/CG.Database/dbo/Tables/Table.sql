CREATE TABLE [dbo].[Table]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Code] NVARCHAR(50) NOT NULL, 
	[TableStatusId] BIGINT NOT NULL,
    [Seats] INT NOT NULL, 
    [MaxSeats] INT NOT NULL, 
    [IsAvailable] BIT NOT NULL, 
    [RestaurantId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Table_TableStatus] FOREIGN KEY ([TableStatusId]) REFERENCES [TableStatus]([Id]), 
    CONSTRAINT [FK_Table_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id])
)
