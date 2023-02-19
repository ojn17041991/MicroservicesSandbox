CREATE TABLE Users (ID INT, Name VARCHAR(100),
	CONSTRAINT PK_UserID PRIMARY KEY(ID)
);
INSERT INTO Users (ID, Name) VALUES (1, 'Oliver Nicholls');

CREATE TABLE Baskets (ID INT,
	CONSTRAINT PK_BasketID PRIMARY KEY(ID)
);
INSERT INTO Baskets (ID) VALUES (1);

CREATE TABLE UserBasket(UserID INT, BasketID INT,
	CONSTRAINT FK_UserID FOREIGN KEY(UserID) REFERENCES Users(ID),
	CONSTRAINT FK_BasketID FOREIGN KEY(BasketID) REFERENCES Baskets(ID)
);
INSERT INTO UserBasket (UserID, BasketID) VALUES (1, 1);

CREATE TABLE Items (ID INT, Name VARCHAR(100), Description VARCHAR(256)
	CONSTRAINT PK_ItemID PRIMARY KEY(ID)
);
INSERT INTO Items (ID, Name, Description) VALUES (1, 'Apple', 'A fresh, whole apple.');
INSERT INTO Items (ID, Name, Description) VALUES (2, 'Banana', 'A ripe banana.');
INSERT INTO Items (ID, Name, Description) VALUES (3, 'Orange', 'A sweet, tangy orange.');

CREATE TABLE BasketItems (BasketID INT, ItemID INT, Quantity INT,
	CONSTRAINT FK_BasketID FOREIGN KEY(BasketID) REFERENCES Baskets(ID),
	CONSTRAINT FK_ItemID FOREIGN KEY(ItemID) REFERENCES Items(ID)
);
INSERT INTO BasketItems (BasketID, ItemsID, Quantity) VALUES (1, 1, 5);