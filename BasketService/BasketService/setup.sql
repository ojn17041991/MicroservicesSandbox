CREATE TABLE Basket (UserID INT, ProductId INT, Quantity INT,
	CONSTRAINT FK_UserId FOREIGN KEY(UserID) REFERENCES Users(ID),
	CONSTRAINT FK_ProductId FOREIGN KEY(ProductID) REFERENCES Product(ID)
);
INSERT INTO Basket (UserId, ProductId, Quantity) VALUES (1, 1, 5);
INSERT INTO Basket (UserId, ProductId, Quantity) VALUES (1, 2, 1);