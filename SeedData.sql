CREATE TABLE Users(
UserId UNIQUEIDENTIFIER PRIMARY KEY,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
DeliveryAddress NVARCHAR(75) NOT NULl,
Phone NVARCHAR(14) NOT NULL,
Email NVARCHAR(25) NOT NULL,
isAdmin NVARCHAR(3) NOT NULL);

CREATE TABLE Products(
ProductId UNIQUEIDENTIFIER PRIMARY KEY,
BookName NVARCHAR(50) NOT NULL,
Genre NVARCHAR(15) NOT NULL,
Author NVARCHAR(25) NOT NULL,
inStock INT NOT NULL,
Cost MONEY NOT NULL);


CREATE TABLE Orders (
OrderId UNIQUEIDENTIFIER PRIMARY KEY,
ProductName NVARCHAR(50)NOT NULL,
Cost MONEY NOT NULL,
FirstName NVARCHAR(25) NOT NULL,
LastName NVARCHAR(25) NOT NULL,
DeliveryAddress NVARCHAR(75) NOT NULL,
OrderTracker UNIQUEIDENTIFIER NOT NULL,
ConfirmId UNIQUEIDENTIFIER  NOT NULL,);

CREATE TABLE Login (
Email NVARCHAR(25) NOT NULL,
Password NVARCHAR(25) NOT NULL);

CREATE TABLE Cart(
CartId UNIQUEIDENTIFIER NOT NULL,
ProductName NVARCHAR(50) NOT NULL,
Amount MONEY NOT NULL,
isUser BIT NOT NULL,
);

CREATE TABLE Cart(
CartId UNIQUEIDENTIFIER NOT NULL,
ProductName NVARCHAR(50) NOT NULL,
Amount MONEY NOT NULL,
isUser BIT NOT NULL,);

INSERT INTO [dbo].[Cart] (CartId, ProductName, Amount, isUser) VALUES('07af6e9b-79e6-4053-844a-3ddcedaea18e', '1984', 19.99, 0);

INSERT INTO [dbo].[Login] (Email, Password) VALUES('JSmith@myEmail.com', '12345');

INSERT INTO [dbo].[Orders] (OrderId, ProductName, Cost, DeliveryAddress, FirstName, LastName, OrderTracker, ConfirmId) VALUES('0391a76a-b538-40e6-9b90-e34f4881a95a', 'How to Train Your Dragon', 14.99, '123 4th ave New York, NY 10002', 'Jane', 'Smith', '571fe2f0-924f-4853-ad02-e8263d99dffd', '04b7a8f5-655f-4477-a9bf-6792414d45ae');

INSERT INTO [dbo].[UserTable] (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) Values('91a5d36c-5b70-409b-9bbb-6cddccbd6433', 'Jane', 'Smith', '123 4th ave New York, NY 10002', '1-321-123-4567', 'JSmith@myEmail.com', 'No');

INSERT INTO [dbo].[ProductsTable] (ProductId, BookName, Genre, Author, inStock, Cost) VALUES('7150cb24-1d70-4425-a238-50589ec7bb08', 'The Hobbit', 'Fantasy', 'J. R. R. Tolkien', 5, 19.99);