CREATE TABLE [dbo].[Transaction]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
	[TableMealId] BIGINT NOT NULL,
    [PaymentTypeId] BIGINT NOT NULL, 
    [TransactionTime] DATETIME2 NULL, 
    [AggregateAmountWithoutTax] DECIMAL(18, 2) NULL, 
    [Tax] DECIMAL(18, 2) NULL, 
    [Discount] DECIMAL(18, 2) NULL, 
    [Tip] DECIMAL(18, 2) NULL, 
    [TerminalId] BIGINT NULL, 
    [Note] NVARCHAR(50) NULL, 
    [UpdatedDateTime] DATETIME2 NOT NULL, 
    [UpdatedBy] BIGINT NOT NULL, 
    CONSTRAINT [FK_Transaction_TableMeal] FOREIGN KEY ([TableMealId]) REFERENCES [TableMeal]([Id]), 
	CONSTRAINT [FK_Transaction_PaymentType] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentType]([Id]), 
    CONSTRAINT [FK_Transaction_User] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([Id])
)
