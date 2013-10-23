CREATE TABLE [dbo].[User]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [LoginName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(200) NOT NULL, 
    [RestaurantId] BIGINT NOT NULL, 
    [UserTypeId] BIGINT NOT NULL, 
    CONSTRAINT [FK_User_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id]), 
    CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [UserType]([Id])
)
