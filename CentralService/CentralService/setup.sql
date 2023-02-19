CREATE TABLE Product (Id INT PRIMARY KEY, Name VARCHAR(100), Description VARCHAR(256));
INSERT INTO Product (Id, Name, Description) VALUES (1, 'Apple', 'A fresh, whole apple.');
INSERT INTO Product (Id, Name, Description) VALUES (2, 'Banana', 'A ripe banana.');
INSERT INTO Product (Id, Name, Description) VALUES (3, 'Orange', 'A sweet, tangy orange.');

CREATE TABLE Inventory (ProductId INT, Quantity INT, CONSTRAINT FK_ProductId FOREIGN KEY(ProductID) REFERENCES Product(ID));
INSERT INTO Inventory (ProductId, Quantity) VALUES (1, 12);
INSERT INTO Inventory (ProductId, Quantity) VALUES (2, 4);
INSERT INTO Inventory (ProductId, Quantity) VALUES (3, 10);

CREATE TABLE Users (Id INT PRIMARY KEY, Name VARCHAR(100));
INSERT INTO Users (Id, Name) VALUES (1, 'Oliver Nicholls');

CREATE TABLE Basket (UserID INT, ProductId INT, Quantity INT,
	CONSTRAINT FK_UserId FOREIGN KEY(UserID) REFERENCES Users(ID),
	CONSTRAINT FK_ProductId FOREIGN KEY(ProductID) REFERENCES Product(ID)
);
INSERT INTO Basket (UserId, ProductId, Quantity) VALUES (1, 1, 5);
INSERT INTO Basket (UserId, ProductId, Quantity) VALUES (1, 2, 1);
