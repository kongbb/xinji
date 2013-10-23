CREATE TABLE [dbo].[Terminal]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [RestaurantId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Terminal_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id])
)
