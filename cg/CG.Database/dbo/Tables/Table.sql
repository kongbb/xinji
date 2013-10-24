CREATE TABLE [dbo].[Table]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Code] NVARCHAR(50) NOT NULL, 
    [Seats] INT NOT NULL, 
    [MaxSeats] INT NOT NULL, 
    [IsAvailable] BIT NOT NULL
)
