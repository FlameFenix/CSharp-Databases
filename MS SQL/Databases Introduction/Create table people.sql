CREATE TABLE People(
[Id] INT IDENTITY PRIMARY KEY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY (MAX)
	CHECK (DATALENGTH(Picture) <= 2048*1024),
[Height] FLOAT(2),
[Weight] FLOAT(2),
[Gender] CHAR NOT NULL,
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX)
);

INSERT INTO People([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
	   ('Stoqn', NULL,1.65, 60.50 ,'m','1991/01/01','asdfdfasd'),
	   ('Petur',NULL,1.80,60.50 ,'m','1992/02/02','sadfasfasdf'),
	   ('Mitko',NULL, 1.55,60.50 ,'m','1993/03/03','dfgdsgsdfg'),
	   ('Gogicha',NULL,1.93,60.50 ,'m','1994/04/04','dfgdf'),
	   ('Viktor',NULL,1.33,60.50 ,'m','1995/05/05','gsdfgsdg');