CREATE TABLE [dbo].[Order]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [OrderTypeId] BIGINT NOT NULL,
	[OrderStatusId] BIGINT NOT NULL, 
	[TableMealId] BIGINT NOT NULL,
    [CreatedDateTime] DATETIME2 NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [UpdatedDateTime] DATETIME2 NOT NULL, 
    [UpdatedBy] BIGINT NOT NULL, 
    CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY ([OrderStatusId]) REFERENCES [OrderStatus]([Id]), 
    CONSTRAINT [FK_Order_CreatedByUser] FOREIGN KEY ([CreatedBy]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Order_UpdatedByUser] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Order_OrderType] FOREIGN KEY ([OrderTypeId]) REFERENCES [OrderType]([Id]), 
    CONSTRAINT [FK_Order_TableMeal] FOREIGN KEY ([TableMealId]) REFERENCES [TableMeal]([Id])
)
