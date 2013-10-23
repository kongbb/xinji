CREATE TABLE [dbo].[OrderItem]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [OrderId] BIGINT NOT NULL, 
    [MenuItemId] BIGINT NOT NULL, 
    [Count] INT NOT NULL, 
    CONSTRAINT [FK_OrderItem_MenuItem] FOREIGN KEY ([MenuItemId]) REFERENCES [MenuItem]([Id]), 
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
)
