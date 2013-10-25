/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Restaurant
insert into Restaurant values(1, '蜀香村', '海淀大街3号，海淀区', '北京',null, '100021', null, '', null, null, null)

-- UserType
insert into UserType values (1, 'Admin')
insert into UserType values (2, 'Waiter')

-- User
insert into [User] values (1, 'Admin', null, null, 'password', 1, 1)
insert into [User] values (2, 'Waiter', null, null, 'password', 1, 2)