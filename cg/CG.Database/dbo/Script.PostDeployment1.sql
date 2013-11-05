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

-- Country
INSERT INTO [dbo].Country VALUES(1,'China','PRC','CN')
INSERT INTO [dbo].Country VALUES(2,'United States','USA','US')

-- Province
INSERT INTO [dbo].Province VALUES(1,'北京',1,'BJ')
INSERT INTO [dbo].Province VALUES(2,'上海',1,'SH')
INSERT INTO [dbo].Province VALUES(3,'广东',1,'GD')
INSERT INTO [dbo].Province VALUES(4,'California',2,'CA')
INSERT INTO [dbo].Province VALUES(5,'Washionton',2,'WA')
INSERT INTO [dbo].Province VALUES(6,'Illinois',2,'IL')

-- Restaurant
INSERT INTO [dbo].Restaurant values(1, '蜀香村', '海淀大街3号，海淀区', '北京',null, '100021', null, 'HE', 1, null, null)

-- UserType
INSERT INTO [dbo].[UserType] values (1, 'Admin')
INSERT INTO [dbo].[UserType] values (2, 'Waiter')

-- User
INSERT INTO [dbo].[User] values (1, 'admin', 'John', 'Clavin', 'password', 1, 1)
INSERT INTO [dbo].[User] values (2, 'waiter', 'BALIE', 'Laurent', 'password', 1, 2)

-- Menu Category
INSERT INTO [dbo].[MenuItemCategory] values (1,'Wine',1)
INSERT INTO [dbo].[MenuItemCategory] values (2,'Chicken',1)
INSERT INTO [dbo].[MenuItemCategory] values (3,'Beef',1)
INSERT INTO [dbo].[MenuItemCategory] values (4,'Fish',1)
INSERT INTO [dbo].[MenuItemCategory] values (5,'Pork',1)
INSERT INTO [dbo].[MenuItemCategory] values (6,'Vegetables',1)
INSERT INTO [dbo].[MenuItemCategory] values (7,'Pizza',1)


-- Menu Item
INSERT INTO [dbo].[MenuItem] values (1,'Bordeuax Red wine 1999',19.9,1,'2013-10-24 15:30',1,1)
INSERT INTO [dbo].[MenuItem] values (2,'Cabernet 2007',28,1,'2013-10-24 15:31',1,1)
INSERT INTO [dbo].[MenuItem] values (3,'Cabernet 2013',15,1,'2013-10-24 15:31',1,1)
INSERT INTO [dbo].[MenuItem] values (4,'Wine Italy 2009',20,1,'2013-10-24 15:31',1,1)
INSERT INTO [dbo].[MenuItem] values (5,'Wine Australia 2013',20,1,'2013-10-24 15:31',1,1)
INSERT INTO [dbo].[MenuItem] values (6,'White wine',20,1,'2013-10-24 15:31',1,1)
INSERT INTO [dbo].[MenuItem] values (7,'Chateux de Rone 2013',20,1,'2013-10-24 15:31',1,1)

INSERT INTO [dbo].[MenuItem] values (8,'Spicy Chicken wins ',19.9,1,'2013-10-25 15:33',1,2)
INSERT INTO [dbo].[MenuItem] values (9,'Chicken Casol',28,1,'2013-10-25 15:33',1,2)
INSERT INTO [dbo].[MenuItem] values (10,'Bourbon Chicken ',15,1,'2013-10-25 15:33',1,2)
INSERT INTO [dbo].[MenuItem] values (11,'Chicken noodle',20,1,'2013-10-25 15:33',1,2)
INSERT INTO [dbo].[MenuItem] values (12,'Chicken Pasta',20,1,'2013-10-25 15:33',1,2)

INSERT INTO [dbo].[MenuItem] values (13,'Steak Stone',25,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (14,'Steak Mexican',28.1,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (15,'French Steak',15,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (16,'Encote Steak',23,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (17,'Steak spicy',32,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (18,'Beef rosted',13,1,'2013-10-21 11:33',1,3)
INSERT INTO [dbo].[MenuItem] values (19,'Beef vegitables',32,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (20,'Beef 5 start',16,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (21,'Beef frites',28,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (22,'Beef cu',11,1,'2013-10-21 15:33',1,3)
INSERT INTO [dbo].[MenuItem] values (23,'Beef soute',5,1,'2013-10-21 15:34',1,3)
INSERT INTO [dbo].[MenuItem] values (24,'Beef rice',9,1,'2013-10-21 15:34',1,3)
INSERT INTO [dbo].[MenuItem] values (25,'Beef brioche',3,1,'2013-10-21 15:34',1,3)

INSERT INTO [dbo].[MenuItem] values (26,'Big fish',19.9,1,'2013-10-30 15:33',1,4)
INSERT INTO [dbo].[MenuItem] values (27,'Fried fish',28,1,'2013-10-30 15:33',1,4)
INSERT INTO [dbo].[MenuItem] values (28,'Saumon Sandwich',15,1,'2013-10-30 15:33',1,4)
INSERT INTO [dbo].[MenuItem] values (29,'Tuna Salad',20,1,'2013-10-30 15:33',1,4)
INSERT INTO [dbo].[MenuItem] values (30,'Saumon Pasta',20,1,'2013-10-30 15:33',1,4)

INSERT INTO [dbo].[MenuItem] values (31,'Pork roste',10.90,1,'2013-10-30 15:33',1,5)
INSERT INTO [dbo].[MenuItem] values (32,'Sault Pork',12,1,'2013-10-30 15:33',1,5)
INSERT INTO [dbo].[MenuItem] values (33,'roti',19.9,1,'2013-10-30 15:33',1,5)

INSERT INTO [dbo].[MenuItem] values (34,'Tofu Vegetable',10.90,1,'2013-10-30 15:25',1,6)
INSERT INTO [dbo].[MenuItem] values (35,'Salad Napoli',12,1,'2013-10-30 15:40',1,6)
INSERT INTO [dbo].[MenuItem] values (36,'Salad Maroc',25,1,'2013-10-30 15:43',1,6)

INSERT INTO [dbo].[MenuItem] values (37,'Pizza Napoli',11.00,1,'2013-10-30 15:20',1,7)
INSERT INTO [dbo].[MenuItem] values (38,'Pizza Four Season',12.0,1,'2013-10-20 15:40',1,7)
INSERT INTO [dbo].[MenuItem] values (39,'Pizza Toulon',13.9,1,'2013-10-30 15:20',1,7)
INSERT INTO [dbo].[MenuItem] values (40,'Pizza 4 formage',14.9,1,'2013-10-30 15:20',1,7)



-- Shift Type
INSERT INTO [dbo].[ShiftType] values (1,'Midi',1,'2013-10-21 11:00','2013-10-21 14:00')
INSERT INTO [dbo].[ShiftType] values (2,'evening',1,'2013-10-21 17:00','2013-10-21 23:00')

-- Shift
INSERT INTO [dbo].[Shift] values(1,1)
INSERT INTO [dbo].[Shift] values(2,2)

-- Menu Item Shift
INSERT INTO [dbo].[MenuItemShift] values (1,1,1, 18)
INSERT INTO [dbo].[MenuItemShift] values (2,13,2, 30)
INSERT INTO [dbo].[MenuItemShift] values (3,14,2, 30)
INSERT INTO [dbo].[MenuItemShift] values (4,15,2, 30)
INSERT INTO [dbo].[MenuItemShift] values (5,16,2, 30)
INSERT INTO [dbo].[MenuItemShift] values (6,17,2, 30)
INSERT INTO [dbo].[MenuItemShift] values (7,2,1, 15)
INSERT INTO [dbo].[MenuItemShift] values (8,3,1, 15)
INSERT INTO [dbo].[MenuItemShift] values (9,4,1, 15)

-- Payment Method
INSERT INTO [dbo].[PaymentType] values (1, 'Cash')
INSERT INTO [dbo].[PaymentType] values (2, 'Credit Card')
INSERT INTO [dbo].[PaymentType] values (3, 'Gift Ticket')

-- Terminal
INSERT INTO [dbo].[Terminal] values (1, 'Cash box',1)
INSERT INTO [dbo].[Terminal] values (2, 'Caisse termial',1)

-- Table
INSERT INTO [dbo].[Table] values (1, 't1',3,5,1)
INSERT INTO [dbo].[Table] values (2, 't2',2,6,1)
INSERT INTO [dbo].[Table] values (3, 't3',2,6,1)
INSERT INTO [dbo].[Table] values (4, 't4',2,6,1)
INSERT INTO [dbo].[Table] values (5, 't5',2,6,0)
INSERT INTO [dbo].[Table] values (6, 't6',2,6,1)
INSERT INTO [dbo].[Table] values (7, 't7',1,4,0)
INSERT INTO [dbo].[Table] values (8, 't8',1,4,1)
INSERT INTO [dbo].[Table] values (9, 't9',2,4,1)
INSERT INTO [dbo].[Table] values (10, 't10',2,10,0)
INSERT INTO [dbo].[Table] values (11, 't11',2,10,1)
INSERT INTO [dbo].[Table] values (12, 't12',2,10,1)
INSERT INTO [dbo].[Table] values (13, 't13',3,10,1)
INSERT INTO [dbo].[Table] values (14, 't14',3,8,1)
INSERT INTO [dbo].[Table] values (15, 't15',3,8,1)
INSERT INTO [dbo].[Table] values (16, 't16',3,12,1)

-- Table Status
INSERT INTO [dbo].[TableStatus] values (1,'Spare')
INSERT INTO [dbo].[TableStatus] values (2,'Ordering')
INSERT INTO [dbo].[TableStatus] values (3,'NeedWaiter')
INSERT INTO [dbo].[TableStatus] values (4,'Dining')
INSERT INTO [dbo].[TableStatus] values (5,'Billing')
INSERT INTO [dbo].[TableStatus] values (6,'NeedClean')
INSERT INTO [dbo].[TableStatus] values (7,'Paid')

-- Tax
INSERT INTO [dbo].[Tax] values (1, 'Chinese Services Tax',0.19,1)
INSERT INTO [dbo].[Tax] values (2, 'Chinese Avt',0.11,1)

-- Order Type
INSERT INTO [dbo].[OrderType] values (1,'At Reataurant')
INSERT INTO [dbo].[OrderType] values (2,'Take Away')

-- OrderType Tax
INSERT INTO [dbo].[OrderTypeTax] values (1,1,1)
INSERT INTO [dbo].[OrderTypeTax] values (2,2,2)

-- Order Status
INSERT INTO [dbo].[OrderStatus] values (1,'Openning')
INSERT INTO [dbo].[OrderStatus] values (2,'Printed to kitchen')
INSERT INTO [dbo].[OrderStatus] values (3,'Delivered')
INSERT INTO [dbo].[OrderStatus] values (4,'Void')

-- 下面是点2次点菜的数据  
-- Table 1   20:00开台 20:15点菜  21:30结账关闭  4人消费 4个菜 数量各1 服务员ID=2 At Restaurant 消费税19%
INSERT INTO [dbo].[TableMeal] values (1,1,7,'2013-10-31 20:00','2013-10-31 21:30',4)
INSERT INTO [dbo].[Order] values (1,1,3,1,'2013-10-31 20:15',2,'2013-10-31 20:20',2,1)
INSERT INTO [dbo].[TableMealOrder] values (1,1,1)
INSERT INTO [dbo].[OrderItem] values (1,1,1,1)
INSERT INTO [dbo].[OrderItem] values (2,1,2,1)
INSERT INTO [dbo].[OrderItem] values (3,1,3,1)
INSERT INTO [dbo].[OrderItem] values (4,1,4,1) 
INSERT INTO [dbo].[Transaction] values (1,1,1,'2013-10-31 21:30',82.9,15.75,0,0,1,'','2013-10-31 21:31',2)
 

 
 -- Table 2   19:00开台  2人消费 正在用餐  19:00点第一轮菜 2个 上菜完毕  19:30点第二轮菜2个 打印至厨房 等待上菜 服务员ID=2  At Restaurant 消费税19% 
INSERT INTO [dbo].[TableMeal] values (2,2,4,'2013-10-31 19:00','',2)
 --19:00第一轮点菜 19:20上菜完毕 服务员2
INSERT INTO [dbo].[Order] values (2,1,3,2,'2013-10-31 19:00',2,'2013-10-31 19:20',2,1)
INSERT INTO [dbo].[TableMealOrder] values (2,2,2)
INSERT INTO [dbo].[OrderItem] values (5,2,1,1)
INSERT INTO [dbo].[OrderItem] values (6,2,2,1)
--19：30第二轮点菜 服务员2 已打印至厨房 正在等待 test test
INSERT INTO [dbo].[Order] values (3,1,2,2,'2013-10-31 19:30',2,'',2,1)
INSERT INTO [dbo].[TableMealOrder] values (3,2,3)
INSERT INTO [dbo].[OrderItem] values (7,3,10,1)
INSERT INTO [dbo].[OrderItem] values (8,311,1)
 

 












