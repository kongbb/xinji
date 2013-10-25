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
<<<<<<< HEAD
-- Country
INSERT INTO [rcloud].[dbo].Country VALUES(1,'China','PRC','CN')
INSERT INTO [rcloud].[dbo].Country VALUES(2,'United States','USA','US')

-- Province
INSERT INTO [rcloud].[dbo].Province VALUES(1,'北京',1,'BJ')
INSERT INTO [rcloud].[dbo].Province VALUES(2,'上海',1,'SH')
INSERT INTO [rcloud].[dbo].Province VALUES(3,'广东',1,'GD')
INSERT INTO [rcloud].[dbo].Province VALUES(4,'California',2,'CA')
INSERT INTO [rcloud].[dbo].Province VALUES(5,'Washionton',2,'WA')
INSERT INTO [rcloud].[dbo].Province VALUES(6,'Illinois',2,'IL')

-- Restaurant
INSERT INTO [rcloud].[dbo].Restaurant values(1, '蜀香村', '海淀大街3号，海淀区', '北京',null, '100021', null, 'HE', 1, null, null)

-- UserType
INSERT INTO [rcloud].[dbo].[UserType] values (1, 'Admin')
INSERT INTO [rcloud].[dbo].[UserType] values (2, 'Waiter')

-- User
INSERT INTO [rcloud].[dbo].[User] values (1, 'admin', 'John', 'Clavin', 'password', 1, 1)
INSERT INTO [rcloud].[dbo].[User] values (2, 'waiter', 'BALIE', 'Laurent', 'password', 1, 2)

-- Menu Category
INSERT INTO [rcloud].[dbo].[MenuItemCategory] values (1,'Wine',1)
INSERT INTO [rcloud].[dbo].[MenuItemCategory] values (2,'Chicken',1)
INSERT INTO [rcloud].[dbo].[MenuItemCategory] values (3,'Beef',1)


-- Menu Item
INSERT INTO [rcloud].[dbo].[MenuItem] values (1,'Bordeuax Red wine 1999',19.9,1,'2013-10-24 15:30',1,1)
INSERT INTO [rcloud].[dbo].[MenuItem] values (2,'Cabernet 2007',28,1,'2013-10-24 15:31',1,1)
INSERT INTO [rcloud].[dbo].[MenuItem] values (3,'Cabernet 2013',15,1,'2013-10-24 15:31',1,1)
INSERT INTO [rcloud].[dbo].[MenuItem] values (4,'Wine Italy 2009',20,1,'2013-10-24 15:31',1,1)
INSERT INTO [rcloud].[dbo].[MenuItem] values (5,'Wine Australia 2013',20,1,'2013-10-24 15:31',1,1)
INSERT INTO [rcloud].[dbo].[MenuItem] values (6,'White wine',20,1,'2013-10-24 15:31',1,1)
INSERT INTO [rcloud].[dbo].[MenuItem] values (7,'Chateux de Rone 2013',20,1,'2013-10-24 15:31',1,1)

INSERT INTO [rcloud].[dbo].[MenuItem] values (8,'Spicy Chicken wins ',19.9,1,'2013-10-25 15:33',1,2)
INSERT INTO [rcloud].[dbo].[MenuItem] values (9,'Chicken Casol',28,1,'2013-10-25 15:33',1,2)
INSERT INTO [rcloud].[dbo].[MenuItem] values (10,'Bourbon Chicken ',15,1,'2013-10-25 15:33',1,2)
INSERT INTO [rcloud].[dbo].[MenuItem] values (11,'Chicken noodle',20,1,'2013-10-25 15:33',1,2)
INSERT INTO [rcloud].[dbo].[MenuItem] values (12,'Chicken Pasta',20,1,'2013-10-25 15:33',1,2)

INSERT INTO [rcloud].[dbo].[MenuItem] values (13,'Steak Stone',25,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (14,'Steak Mexican',28.1,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (15,'French Steak',15,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (16,'Encote Steak',23,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (17,'Steak spicy',32,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (18,'Beef rosted',13,'2013-10-21 11:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (19,'Beef vegitables',32,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (20,'Beef 5 start',16,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (21,'Beef frites',28,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (22,'Beef cu',11,1,'2013-10-21 15:33',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (23,'Beef soute',5,1,'2013-10-21 15:34',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (24,'Beef rice',9,1,'2013-10-21 15:34',1,3)
INSERT INTO [rcloud].[dbo].[MenuItem] values (25,'Beef brioche',3,1,'2013-10-21 15:34',1,3)


-- Shift Type
INSERT INTO [rcloud].[dbo].[ShiftType] values (1,'Midi',1,'2013-10-21 11:00','2013-10-21 14:00')
INSERT INTO [rcloud].[dbo].[ShiftType] values (2,'evening',1,'2013-10-21 17:00','2013-10-21 23:00')

-- Shift
INSERT INTO [rcloud].[dbo].[Shift] values(1,1)
INSERT INTO [rcloud].[dbo].[Shift] values(2,2)

-- Menu Item Shift
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (1,1,1, 18)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (2,13,2, 30)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (3,14,2, 30)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (4,15,2, 30)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (5,16,2, 30)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (6,17,2, 30)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (7,2,1, 15)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (8,3,1, 15)
INSERT INTO [rcloud].[dbo].[MenuItemShift] values (9,4,1, 15)

-- Payment Method
INSERT INTO [rcloud].[dbo].[PaymentType] values (1, 'Cash')
INSERT INTO [rcloud].[dbo].[PaymentType] values (2, 'Credit Card')
INSERT INTO [rcloud].[dbo].[PaymentType] values (3, 'Gift Ticket')

-- Tax
INSERT INTO [rcloud].[dbo].[Tax] values (1, 'Chinese Services Tax',0.19,1)
INSERT INTO [rcloud].[dbo].[Tax] values (2, 'Chinese Avt',0.11,1)

-- Terminal
INSERT INTO [rcloud].[dbo].[Terminal] values (1, 'Cash box',1)
INSERT INTO [rcloud].[dbo].[Terminal] values (2, 'Caisse termial',1)

-- Table
INSERT INTO [rcloud].[dbo].[Table] values (1, 't1',3,5,1)
INSERT INTO [rcloud].[dbo].[Table] values (2, 't2',0,6,1)
INSERT INTO [rcloud].[dbo].[Table] values (3, 't3',0,6,1)
INSERT INTO [rcloud].[dbo].[Table] values (4, 't4',0,6,1)
INSERT INTO [rcloud].[dbo].[Table] values (5, 't5',0,6,0)
INSERT INTO [rcloud].[dbo].[Table] values (6, 't6',0,6,1)
INSERT INTO [rcloud].[dbo].[Table] values (7, 't7',1,4,0)
INSERT INTO [rcloud].[dbo].[Table] values (8, 't8',1,4,1)
INSERT INTO [rcloud].[dbo].[Table] values (9, 't9',2,4,1)
INSERT INTO [rcloud].[dbo].[Table] values (10, 't10',2,10,0)
INSERT INTO [rcloud].[dbo].[Table] values (11, 't11',2,10,1)
INSERT INTO [rcloud].[dbo].[Table] values (12, 't12',2,10,1)
INSERT INTO [rcloud].[dbo].[Table] values (13, 't13',3,10,1)
INSERT INTO [rcloud].[dbo].[Table] values (14, 't14',3,8,1)
INSERT INTO [rcloud].[dbo].[Table] values (15, 't15',3,8,1)
INSERT INTO [rcloud].[dbo].[Table] values (16, 't16',3,12,1

-- Table Status
INSERT INTO [rcloud].[dbo].[TableStatus] values (1,'ordering')
INSERT INTO [rcloud].[dbo].[TableStatus] values (2,'ordering')
INSERT INTO [rcloud].[dbo].[TableStatus] values (3,'ordering')
INSERT INTO [rcloud].[dbo].[TableStatus] values (4,'Spare')
INSERT INTO [rcloud].[dbo].[TableStatus] values (5,'Spare')




=======

-- Restaurant
insert into Restaurant values(1, '蜀香村', '海淀大街3号，海淀区', '北京',null, '100021', null, '', null, null, null)

-- UserType
insert into UserType values (1, 'Admin')
insert into UserType values (2, 'Waiter')

-- User
insert into [User] values (1, 'Admin', null, null, 'password', 1, 1)
insert into [User] values (2, 'Waiter', null, null, 'password', 1, 2)
>>>>>>> b40eb11eb06d16ca1242826e35ac6a9f362e1aa5
