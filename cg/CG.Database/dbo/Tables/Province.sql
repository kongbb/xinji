CREATE TABLE [dbo].[Province]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CountryId] BIGINT NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Province_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id])
)
