CREATE TABLE Users(
UserId UNIQUEIDENTIFIER PRIMARY KEY,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
DeliveryAddress NVARCHAR(75) NOT NULl,
Phone NVARCHAR(14) NOT NULL,
Email NVARCHAR(25) NOT NULL,
isAdmin NVARCHAR(3) NOT NULL);


CREATE TABLE Products(
ISBN NVARCHAR(15) PRIMARY KEY,
BookName NVARCHAR(50) NOT NULL,
NumberPages INT NOT NULL,
Genre NVARCHAR(15) NOT NULL,
Author NVARCHAR(25) NOT NULL,
inStock INT NOT NULL,
Cost MONEY NOT NULL);


CREATE TABLE Orders (
OrderId UNIQUEIDENTIFIER PRIMARY KEY,
BookName NVARCHAR(50)NOT NULL,
Cost MONEY NOT NULL,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
DeliveryAddress NVARCHAR(75) NOT NULL,
OrderTracker UNIQUEIDENTIFIER NOT NULL);

CREATE TABLE Card(
UserId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
CardNumber BIGINT NOT NULL,
CVV INT NOT NULL,
ValidThru NVARCHAR(5) NOT NULL);

ALTER TABLE [dbo].[Card]
ADD CVV INT;

ALTER TABLE [dbo].[Card]
ADD ValidThru NVARCHAR(5);

CREATE TABLE Login (
Email NVARCHAR(25) PRIMARY KEY,
Password NVARCHAR(25) NOT NULL);

CREATE TABLE Cart(
CartId UNIQUEIDENTIFIER NOT NULL,
BookName NVARCHAR(50) NOT NULL,
Amount MONEY NOT NULL,
isUser BIT NOT NULL,
);

INSERT INTO [dbo].[Cart] (CartId, BookName, Amount, isUser) VALUES('07af6e9b-79e6-4053-844a-3ddcedaea18e', '1984', 19.99, 0);


INSERT INTO Login (Email, Password) VALUES('JSmith@myEmail.com', '12345');
INSERT INTO Login (Email, Password) VALUES('EWilliams@myEmail.com', '23456');
INSERT INTO Login (Email, Password) VALUES('BCook@myEmail.com', '34567');
INSERT INTO Login (Email, Password) VALUES('AWhite@myEmail.com', '45678');
INSERT INTO Login (Email, Password) VALUES('RDouglass@myEmail.com', '56789');
INSERT INTO Login (Email, Password) VALUES('SThomas@myEmail.com', '67890');
INSERT INTO Login (Email, Password) VALUES('JJames@myEmail.com', '78901');
INSERT INTO Login (Email, Password) VALUES('NGross@myEmail.com', '89012');
INSERT INTO Login (Email, Password) VALUES('MYipp@myEmail.com', '90123');
INSERT INTO Login (Email, Password) VALUES('JJohnson@myEmail.com', '01234');

INSERT INTO [dbo].[Orders] (OrderId, BookName, Cost, DeliveryAddress, FirstName, LastName, OrderTracker) VALUES('0391a76a-b538-40e6-9b90-e34f4881a95a', 'How to Train Your Dragon', 14.99, '123 4th ave New York, NY 10002', 'Jane', 'Smith', '571fe2f0-924f-4853-ad02-e8263d99dffd');

INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('bfb9bec7-89ce-4ede-aa39-176890422c76', 'Erica', 'Williams', '4 Right ln Houston, TX 177493', '1-214-778-4227', 'EWilliams@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('763b4a10-ce81-48f9-8cce-2734fcc15fb2', 'Beth', 'Cook', '3 1st ave Los Angelos, CA 90002', '1-225-884-9876', 'BCook@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('236eb847-dfa7-483b-a644-28a8fce355f7', 'Adam', 'White', '2 Back rd Chicago, IL 60186', '1-708-664-4297', 'AWhite@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('4ddda874-8952-45ff-80f7-36eb0c7a4e7c', 'Richard', 'Douglass', '7 Meadow ln Seattle, WA 98104' , '1-360-123-4777', 'RDouglass@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('36b0483f-c7d4-4311-9220-4657dfc863f7', 'Sara', 'Thomas', '8 Washington cr Georgia, GA 30063', '1-404-122-4127', 'SThomas@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('91a5d36c-5b70-409b-9bbb-6cddccbd6433', 'Jane', 'Smith', '123 4th ave New York, NY 10002', '1-321-123-4567', 'JSmith@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('24975d52-c43f-4b81-a98e-8504ccae5c28', 'Jay', 'James', '9 Lincoln ave Boston, MA 14025', '1-508-666-4237', 'JJames@myEmail.com', 'Yes');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('7b77358d-2599-4df3-a4b4-9f7fe3a86708', 'Nick', 'Gross', '5 Left rd Miami, FL 33109', '1-786-567-2255', 'NGross@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('f2708f61-a505-43c0-9a14-a111c76cc8a1', 'Matt', 'Yipp', '6 9th ave Fairbanks, AK 99775', '1-907-445-4127', 'MYipp@myEmail.com', 'No');
INSERT INTO [dbo].[Users] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES('1e837b9a-0458-4043-875a-c5f74919b1fa', 'John', 'Johnson', '1 Main st New York, NY 10002', '1-322-123-4567', 'JJohnson@myEmail.com', 'No');

INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0547928227', 'The Hobbit', 300, 'Fantasy', 'J. R. R. Tolkien', 5, 19.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0316347006', 'How to Train Your Dragon Box Set', 3328, 'Fantasy', 'Cressida Cowell', 2, 39.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1783127856', 'The Ultimate Dinosaur Encyclpedia', 160, 'Non-fiction', 'Chris Baker', 9, 14.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0914098911', 'Calcus, 4th Edition', 680, 'Education', 'Michael Spivak', 99, 99.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0984782857', 'Cracking the Coding Interview', 687, 'Business', 'Gayle Laakmann McDowell', 17, 33.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1571989260', 'The 2023 Frarmers Almanac', 288, 'Reference', 'Old Farmers Almanac', 0, 4.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1913484101', 'Guinness World Records 2022', 256, 'Reference', 'Guiness World Records', 3, 19.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-3319188712', 'A Guide to Hubble Space Telescope Objects', 262, 'Education', 'James Chen and Adam Chen', 6, 21.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0345535528', 'Game of Thrones box set', 5216, 'Fantasy', 'George R. R. Martin', 11, 36.99);

INSERT INTO MasterTable (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, Password, isUser, isAdmin, CardNumber, ValidThru, CVV, CartId, Amount, OrderId, Cost, OrderTracker, ISBN, BookName, NumberPages, Genre, Author, inStock) VALUES('24975d52-c43f-4b81-a98e-8504ccae5c28', 'Jay', 'James', '9 Lincoln ave Boston, MA 14025', '1-508-666-4237', 'JJames@myEmail.com', 
'78901', 'Yes', 'Yes', 7890123456789012, '01/23', 456, '07af6e9b-79e6-4053-844a-3ddcedaea18e', 99.99, '07af6e9b-79e6-4053-844a-3ddcedaea18e', 99.99, '28bc9a12-ea48-4593-8e42-c355bd0079eb', '978-0914098911', 'Calcus, 4th Edition', 680, 'Education', 'Michael Spivak', 99);
INSERT INTO [dbo].[MasterTable] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, Password, isUser, isAdmin, CardNumber, ValidThru, CVV, CartId, Amount, OrderId, Cost, OrderTracker, ISBN, BookName, NumberPages, Genre, Author, inStock) VALUES('91a5d36c-5b70-409b-9bbb-6cddccbd6433', 'Jane', 'Smith', '123 4th ave New York, NY 10002', '1-321-123-4567', 'JSmith@myEmail.com',
'12345', 'Yes', 'No', 6789012345678901, '3/24', 123, '0391a76a-b538-40e6-9b90-e34f4881a95a', 36.99, '0391a76a-b538-40e6-9b90-e34f4881a95a', 36.99, 'd9493ca9-232a-4711-ace0-05fb2a972bd0' , '978-0345535528', 'Game of Thrones box set', 5216, 'Fantasy', 'George R. R. Martin', 11);
INSERT INTO [dbo].[MasterTable] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, Password, isUser, isAdmin, CardNumber, ValidThru, CVV, CartId, Amount, OrderId, Cost, OrderTracker, ISBN, BookName, NumberPages, Genre, Author, inStock) VALUES('bfb9bec7-89ce-4ede-aa39-176890422c76', 'Erica', 'Williams', '4 Right ln Houston, TX 177493', '1-214-778-4227', 'EWilliams@myEmail.com',
'12345', 'no', 'no', 4567890123456789, '04/25', 876, '1e837b9a-0458-4043-875a-c5f74919b1fa', 19.99, '1e837b9a-0458-4043-875a-c5f74919b1fa', 19.99, '763b4a10-ce81-48f9-8cce-2734fcc15fb2','978-0547928227', 'The Hobbit', 300, 'Fantasy', 'J. R. R. Tolkien', 1);

CREATE TABLE MasterTable (
UserId UNIQUEIDENTIFIER Primary Key NOT NULL,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
DeliveryAddress NVARCHAR(75),
Phone NVARCHAR(15) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Password NVARCHAR(25) NOT NULL,
isUser NVARCHAR(3) NOT NULL,
isAdmin NVARCHAR(3) NOT NULL,
CardNumber BIGINT NOT NULL,
ValidThru NVARCHAR(5) NOT NULL,
CVV INT NOT NULL,
CartId UNIQUEIDENTIFIER NOT NULL,
Amount Money NOT NULL,
OrderId UNIQUEIDENTIFIER NOT NULL,
Cost Money NOT NULL,
OrderTracker UNIQUEIDENTIFIER NOT NULL,
ISBN NVARCHAR(15) NOT NULL,
BookName NVARCHAR(75) NOT NULL,
NumberPages INT NOT NULL,
Genre NVARCHAR(75) NOT NULL,
Author NVARCHAR(50) NOT NULL,
inStock int NOT NULL);