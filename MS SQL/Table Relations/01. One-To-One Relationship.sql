CREATE DATABASE Practice

USE Practice

CREATE TABLE Passports(
	[PassportID] INT PRIMARY KEY NOT NULL,
	[PassportNumber] NVARCHAR(30) NOT NULL
)

CREATE TABLE Persons(
	[PersonID] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[Salary] DECIMAL(7,2),
	[PassportID] INT FOREIGN KEY REFERENCES Passports([PassportID]) UNIQUE
)

INSERT INTO Passports
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)