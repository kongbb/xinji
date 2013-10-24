CREATE TABLE [dbo].[TableMealOrder]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [TableMealId] BIGINT NOT NULL, 
    [OrderId] BIGINT NOT NULL, 
    CONSTRAINT [FK_TableOrder_TableMeal] FOREIGN KEY ([TableMealId]) REFERENCES [TableMeal]([Id]), 
    CONSTRAINT [FK_TableOrder_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
)
