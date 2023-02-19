﻿CREATE TABLE Baskets (ID INT,
	CONSTRAINT PK_BasketID PRIMARY KEY(ID)
);

CREATE TABLE BasketItems (BasketID INT, ItemID INT, Quantity INT,
	CONSTRAINT FK_BasketID FOREIGN KEY(BasketID) REFERENCES Baskets(ID)
);

INSERT INTO Baskets (ID) VALUES (1);
INSERT INTO BasketItems (BasketID, ItemsID, Quantity) VALUES (1, 1, 5);