CREATE TABLE [dbo].[Tax]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Rate] DECIMAL(18, 3) NOT NULL, 
    [RestaurantId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Tax_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id])
)
