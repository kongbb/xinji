CREATE TABLE [dbo].[MenuItemShift]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [MenuItemId] BIGINT NOT NULL, 
    [ShiftId] BIGINT NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_MenuItemShift_MenuItem] FOREIGN KEY ([MenuItemId]) REFERENCES [MenuItem]([Id]), 
    CONSTRAINT [FK_MenuItemShift_Shift] FOREIGN KEY ([ShiftId]) REFERENCES [Shift]([Id])
)
