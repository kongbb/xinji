CREATE TABLE [dbo].[MenuItemCategory]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [RestaurantId] BIGINT NOT NULL, 
    CONSTRAINT [FK_MenuItemCategory_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id])
)
