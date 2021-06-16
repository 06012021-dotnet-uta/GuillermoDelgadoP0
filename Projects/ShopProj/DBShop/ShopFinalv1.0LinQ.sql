create database Shop;

--select * from Users;
--select * from StoreLocation;


CREATE TABLE Users(
	UserID int PRIMARY KEY IDENTITY(1000,10) NOT NULL,
	UserFirstName nvarchar(20) NOT NULL,
	UserLastName nvarchar(20) NOT NULL,
	Password nvarchar(20) NOT NULL,
	UserAddress nvarchar (40) NULL,
	UserCity nvarchar(10) NULL,
	UserState varchar(2) NULL,

);

CREATE TABLE Orders(
	OrderId int PRIMARY KEY IDENTITY(1000,10) NOT NULL,
	UserID int NOT NULL,
	Total_Purches decimal(38, 2)DEFAULT(0) NULL,
	TimeDate DATETIME DEFAULT(Getdate()),
	FOREIGN KEY(UserID) REFERENCES Users(UserID)
);

CREATE TABLE StoreLocation(
	LocationID int PRIMARY KEY IDENTITY(1000,1) NOT NULL,
	StoreName nvarchar(20) NOT NULL,
	StoreCity nvarchar(15) NULL,
	StoreState nvarchar(2) NULL,
    
);

CREATE TABLE Products(
	
	ProductID int PRIMARY KEY IDENTITY(1000,10) NOT NULL,
	ProductName nvarchar(20) NOT NULL,
	ProductDescription nvarchar(50) NULL,
	ProductPrice decimal(38, 2) NOT NULL,
	Stock int NULL,
	LocationID int NOT NULL,
	FOREIGN KEY(LocationID) REFERENCES StoreLocation(LocationID),
	CONSTRAINT TooMany CHECK(Stock < 500 AND Stock > 0)
);


CREATE TABLE OrderItem(
	PRIMARY KEY (OrderId,ProductID),
	OrderId int NOT NULL,
	ProductID int NOT NULL,
	ObtainQty int DEFAULT(0) NULL,
	TotalQtyPrice decimal(38, 2) DEFAULT(0) NULL,
	FOREIGN KEY(OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);


INSERT INTO Users(UserFirstName,UserLastName,Password,UserAddress,UserCity,UserState) 
VALUES ('Maria','Delgado','1234','St N23','Denver','CO'),
		('Roger','Smith','1234','St 343','Austin','TX'),
		('Jim','Ido','1234','Urb 23','Humacao','PR'),
		('Karla','Flecha','1234','Po 673','Tampa','FL'),
		('Kevin','Cool','1234','Po 34','Austin','TX'),
		('Chuck','Noriss','1234','S3 Sub','San Diego','Ca');


INSERT INTO StoreLocation(StoreName,StoreCity,StoreState) 
VALUES ('Target','Denver','CO'),
		('HomeDepot','Baltimore','MD'),
		('Walmart','Richmont','VA'),
		('MicroCenter','Orlando','FL'),
		('BestBuy','Denver','CO'),
		('Target','San 0Diego','CA');




--ADD Target
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, Stock, LocationID) 
VALUES ('Addida TShirt','White L',10.00,12,1000),
	   ('Hanse TShirt','Black S',13.00,10,1000),
	   ('Levis Jeans','Light Jeans 34',15.00,25,1000),
	   ('Nikes Shoes','White,Orange 9.5 Running',45.00,7,1000),
	   ('Hanse Socks','Grey 9-11',5.00,35,1000),
	   ('SamsungTV','32" 1080p',150.00,9,1000),
	   ('Addida Shorts','M Size',15.00,15,1000),
	   ('NormaBook','NoteBook',2.50,45,1000),
	   ('Stands Pencile','Mechanical Pencil',4.50,32,1000),
	   ('MegaBoom','Speakers Water Proof',250.00,35,1000),
	   ('Ps5','Gaming Console',500.50,6,1000);


--ADD HomeDepot
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, Stock, LocationID) 
VALUES ('Husky Hammer','Iron',15.00,32,1001),
		('Wood 4x4','8 Feet',20.00,45,1001),
		('Wood 2x6','10 Feet',16.00,67,1001),
		('Whirpool Saw','Battery Charge',245.00,12,1001),
		('Leviton Switch','AC Quiet Light Switch',15.90,129,1001),
		('Philips Light','Wireless Light Bulb',11.97,18,1001),
		('Bali Blinds','2 in. Faux Wood Blinds ',49.00,19,1001),
		('Husky Wrench','Adjustable Wrench',13.76,6,1001),
		('RIDGID Wrench','One Stop Wrench',21.48,2,1001),
		('Urrea',' Hydraulic Pipe Bende',1863.00,5,1001),
		('ARazor-Back','Fiberglass Handle Post Hole Digger',54.00,12,1001);

--ADD Walmart
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, Stock, LocationID) 
VALUES ('Lenovo IdeaPad','Gaming 15"Intel Corei7',899.00,3,1002),
	   ('Lodge ',' Iron Grill Pan Assist Handle',19.90,19,1002),
	   ('Philips Norelco','Wet & Dry Shaver',44.90,13,1002),
	   ('onn.TV',' 32"Roku Smart LED TV',178.00,9,1002),
	   ('George Men','Short Sleeve Shirt',9.98,15,1002),
	   ('Ninja 12 Cup ','Programmable Coffee Brewer',69.00,65,1002),
	   ('HART 6-Tool','Impact Driver',78.00,5,1002),
	   ('Coway Airmega','Mighty Air Purifier',181.00,21,1002),
	   ('Cuisinart','3 Piece Stainless Steel Barbecue Tool Set',19.97,5,1002),
	   ('Pit Boss Competition','Blend BBQ Pellets 40 lb',40.00,6,1002);

--ADD MicroCenter
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, Stock, LocationID) 
VALUES ('AOC Monitor','27"Full HD 75Hz VGA',149.00,5,1003),
		('Dell Monitor','23.6" Full HD 75Hz HDMI',139.00,10,1003),
		('Logitech Keyboard','MK550 Wireless Wave',49.00,15,1003),
		('Razer BlackWidow','Mechanical Gaming Keyboard',139.00,8,1003),
		('SteelSeries Apex 5','Gaming Keyboard',99.00,3,1003),
		('Creality Ender','V2 3D Printer',259.00,7,1003),
		('Brother MFC','Compact Laser All-in-One Printer',209.00,16,1003),
		('HP ENVY','All-in-One Printer',134.00,23,1003),
		('ASUS X570 ROG','ATX Motherboard',449.00,8,1003),
		('Logitech MX Master','Advanced Wireless Mouse Black',99.00,34,1003);

--ADD BestBuy
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, Stock, LocationID) 
VALUES  ('Nikon Z6','4K Video Camera',1999.00,4,1004),
		('JOBY','SMART Kit Tripod',79.00,10,1004),
		('SanDisk',' 32GB microSDHC',13.90,45,1004),
		('Ryze Tech','Quadcopter White',148.00,6,1004),
		('Lowepro','Camera Backpack',49.99,10,1004),
		('Nixplay','Smart Photo Frame',159.00,13,1004),
		('Aluratek','LCD Digital Photo Frame',79.00,15,1004),
		('PlayStation 5','Console',499.00,7,1004),
		('SamsungTV','70” 4K UHD SmartTizen TV',699.00,7,1004),
		('Insignia','40" TVLED Full HD',179.00,5,1004),
		('Hamilton Beach','Classic Drink Mixer',49.00,32,1004);

--ADD Target
INSERT INTO Products(ProductName, ProductDescription, ProductPrice, Stock, LocationID) 
VALUES ('Addida TShirt','White L',10.00,52,1005),
	   ('Hanse TShirt','Black S',13.00,23,1005),
	   ('Levis Jeans','Light Jeans 34',15.00,65,1005),
	   ('Nikes Shoes','White,Orange 9.5 Running',45.00,7,1005),
	   ('Hanse Socks','Grey 9-11',5.00,35,1005),
	   ('SamsungTV','32" 1080p',150.00,23,1005),
	   ('Moore','POLYWOOD Adirondack Chair',200.00,15,1005),
	   ('NormaBook','NoteBook',2.50,45,1005),
	   ('Batman','Figure ',19.50,30,1005),
	   ('MegaBoom','Speakers Water Proof',250.00,35,1005),
	   ('Ps5','Gaming Console',500.50,12,1005);


--ADD Orders
INSERT INTO Orders(UserID) 
VALUES (1000),
		(1010),
		(1020),
		(1030),
		(1040),
		(1010),
		(1060);

--ADD OrderItem
INSERT INTO OrderItem(OrderId,ProductID) 
VALUES (1200,1010),
		(1200,1030),
		(1200,1060),
		(1200,1090),
		(1210,1120),
		(1210,1140),
		(1210,1130),
		(1220,1230),
		(1220,1260),
		(1220,1280),
		(1220,1310),
		(1230,1350),
		(1230,1400),
		(1240,1480),
		(1240,1490),
		(1250,1600),
		(1250,1620),
		(1260,1030);


Select * from Products;
Select * from Orders;
Select * from StoreLocation;

Select * from Users;
Select * from OrderItem;
Select OrderId,ProductID from OrderItem
where OrderId = 1200;