CREATE TABLE [dbo].[MenuItem]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [UpdatedDateTime] DATETIME2 NOT NULL, 
    [UpdatedBy] BIGINT NOT NULL, 
    [CategoryId] BIGINT NOT NULL, 
    CONSTRAINT [FK_MenuItem_MenuItemCategory] FOREIGN KEY ([CategoryId]) REFERENCES [MenuItemCategory]([Id]), 
    CONSTRAINT [FK_MenuItem_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User]([Id])
)
