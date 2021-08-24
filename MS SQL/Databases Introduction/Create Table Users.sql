CREATE TABLE Users(
[Id] INT IDENTITY PRIMARY KEY NOT NULL,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX)
CHECK (DATALENGTH(ProfilePicture)  <= 900*1024),
[LastLoginTime] DATETIME,
[IsDeleted] BIT NOT NULL
);

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
	   ('Stoqn', '123456', NULL, '1991/01/01', 0),
	   ('Petur','123456', NULL, '1992/02/02', 0),
	   ('Mitko','123456', NULL, '1993/03/03', 0),
	   ('Gogicha','123456', NULL, '1994/04/04', 0),
	   ('Viktor','123456', NULL, '1995/05/05', 1);
