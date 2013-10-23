CREATE TABLE [dbo].[Shift]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ShiftTypeId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Shift_ShiftType] FOREIGN KEY ([ShiftTypeId]) REFERENCES [ShiftType]([Id]) 
)
