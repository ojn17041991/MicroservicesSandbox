CREATE DATABASE ItemDB;

CREATE TABLE Items (ID INT, Name VARCHAR(100), Description VARCHAR(256),
	CONSTRAINT PK_ItemID PRIMARY KEY(ID)
);
INSERT INTO Items (ID, Name, Description) VALUES (1, 'Apple', 'A fresh, whole apple.');
INSERT INTO Items (ID, Name, Description) VALUES (2, 'Banana', 'A ripe banana.');
INSERT INTO Items (ID, Name, Description) VALUES (3, 'Orange', 'A sweet, tangy orange.');