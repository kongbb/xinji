CREATE TABLE [dbo].[Restaurant]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [AddressLine1] NVARCHAR(50) NULL, 
    [AddressLine2] NVARCHAR(50) NULL, 
    [AddressLine3] NVARCHAR(50) NULL, 
    [ZipCode] NVARCHAR(10) NULL, 
    [Fax] NVARCHAR(50) NULL, 
    [ContactPerson] NVARCHAR(50) NULL, 
    [ProvinceId] BIGINT NULL, 
    [LandLineNumber] NVARCHAR(50) NULL, 
    [Mobile] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Restaurant_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [Province]([Id])
)
