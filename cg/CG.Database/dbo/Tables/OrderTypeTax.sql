CREATE TABLE [dbo].[OrderTypeTax]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [OrderTypeId] BIGINT NOT NULL, 
    [TaxId] BIGINT NOT NULL, 
    CONSTRAINT [FK_OrderTypeTax_OrderTypeId] FOREIGN KEY ([OrderTypeId]) REFERENCES [OrderType]([Id]), 
    CONSTRAINT [FK_OrderTypeTax_Tax] FOREIGN KEY ([TaxId]) REFERENCES [Tax]([Id])
)
