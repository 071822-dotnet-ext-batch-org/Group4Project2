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

CREATE TABLE Login (
Email NVARCHAR(25) PRIMARY KEY NOT NULL,
Password NVARCHAR(25) NOT NULL);

CREATE TABLE Cart(
CartId UNIQUEIDENTIFIER NOT NULL,
BookName NVARCHAR(50) NOT NULL,
Amount MONEY NOT NULL,
isUser BIT NOT NULL,
);

CREATE TABLE Cart(
CartId UNIQUEIDENTIFIER NOT NULL,
BookName NVARCHAR(50) NOT NULL,
Amount MONEY NOT NULL,
isUser BIT NOT NULL,);

INSERT INTO [dbo].[Cart] (CartId, ProductName, Amount, isUser) VALUES('07af6e9b-79e6-4053-844a-3ddcedaea18e', '1984', 19.99, 0);



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

INSERT INTO [dbo].[Orders] (OrderId, ProductName, Cost, DeliveryAddress, FirstName, LastName, OrderTracker, ConfirmId) VALUES('0391a76a-b538-40e6-9b90-e34f4881a95a', 'How to Train Your Dragon', 14.99, '123 4th ave New York, NY 10002', 'Jane', 'Smith', '571fe2f0-924f-4853-ad02-e8263d99dffd', '04b7a8f5-655f-4477-a9bf-6792414d45ae');

INSERT INTO [dbo].[UserTable] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) Values('91a5d36c-5b70-409b-9bbb-6cddccbd6433', 'Jane', 'Smith', '123 4th ave New York, NY 10002', '1-321-123-4567', 'JSmith@myEmail.com', 'No');

INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0547928227', 'The Hobbit', 300, 'Fantasy', 'J. R. R. Tolkien', 5, 19.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0316347006', 'How to Train Your Dragon Box Set', 3328, 'Fantasy', 'Cressida Cowell', 2, 39.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1783127856', 'The Ultimate Dinosaur Encyclpedia', 160, 'Non-fiction', 'Chris Baker', 9, 14.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0914098911', 'Calcus, 4th Edition', 680, 'Education', 'Michael Spivak', 99, 99.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0984782857', 'Cracking the Coding Interview', 687, 'Business', 'Gayle Laakmann McDowell', 17, 33.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1571989260', 'The 2023 Frarmers Almanac', 288, 'Reference', 'Old Farmers Almanac', 4, 4.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1913484101', 'Guinness World Records 2022', 256, 'Reference', 'Guiness World Records', 3, 19.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-3319188712', 'A Guide to Hubble Space Telescope Objects', 262, 'Education', 'James Chen and Adam Chen', 6, 21.99);
INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0345535528', 'Game of Thrones box set', 5216, 'Fantasy', 'George R. R. Martin', 11, 36.99);