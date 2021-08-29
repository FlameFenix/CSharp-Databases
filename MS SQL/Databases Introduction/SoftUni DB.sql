CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(20)
)

CREATE TABLE Addresses(
Id INT IDENTITY PRIMARY KEY NOT NULL,
[AddressText] NVARCHAR(100) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT IDENTITY PRIMARY KEY NOT NULL,
[Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
MiddleName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
JobTitle NVARCHAR(20) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATETIME2,
Salary DECIMAL(10,2),
AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
)

INSERT INTO Towns([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan', 'Ivanov','Ivanov', '.NET Developer', 4, '02.01.2013', 3500.00),
('Petar', 'Petrov','Petrov', 'Senior Engineer', 1, '03.02.2004', 4000.00),
('Maria', 'Petrova','Ivanova', 'Intern', 5, '08.28.2016', 525.25),
('Georgi', 'Terziev','Ivanov', 'CEO', 2, '10.09.2007', 3000.00),
('Peter', 'Pan','Pan', 'Intern', 3, '08.28.2016', 599.88)

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

SELECT * FROM Towns
	ORDER BY [Name] ASC

SELECT * FROM Departments
	ORDER BY [Name] ASC

SELECT * FROM Employees
	ORDER BY Salary DESC

SELECT [Name] FROM Towns
	ORDER BY [Name] ASC

SELECT [Name] FROM Departments
	ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
	ORDER BY Salary DESC

UPDATE Employees
	SET Salary *= 1.10

SELECT Salary FROM Employees