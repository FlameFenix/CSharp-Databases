CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200),
	)

CREATE TABLE Genres(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200),
	)

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200),
	)

CREATE TABLE Movies(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES Directors([Id]),
	[CopyrightYear] DATE NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES Genres([Id]),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]),
	[Rating] DECIMAL (3,1) NOT NULL,
	[Notes] NVARCHAR(200)
	)

INSERT INTO Directors
VALUES
('Stefan', NULL),
('Stoqn', NULL),
('Mitko', NULL),
('Pencho', NULL),
('Gosho', NULL)

INSERT INTO Genres
VALUES
('Action', NULL),
('Crime and mystery', NULL),
('Romance', NULL),
('Adventure', NULL),
('Fantasy', NULL)

INSERT INTO Categories
VALUES
('Top rated', NULL),
('Lowest rated', NULL),
('Sort by name', NULL),
('Sort by date', NULL),
('Sort by downloads', NULL)

INSERT INTO Movies
VALUES
('The Fast and the Furious', 1, '2001', '1:45', 1, 1, 6.8 , NULL),
('Spider-Man', 2, '2005', '1:30', 2, 5, 5.5 , NULL),
('Harry Potter', 3, '2006', '2:15', 4, 5, 7.7 , NULL),
('The Punisher', 4, '2004', '1:33', 3, 1, 5.5 , NULL),
('John Wick', 5, '2013', '1:40', 5, 1, 6.7 , NULL)