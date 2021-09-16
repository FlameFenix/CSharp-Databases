CREATE DATABASE CarRental

USE CarRental

--	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(3,1) NOT NULL,
	[WeeklyRate] DECIMAL(3,1) NOT NULL,
	[MonthlyRate] DECIMAL(3,1) NOT NULL,
	[WeekendRate] DECIMAL(3,1) NOT NULL,
)
--	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(20) NOT NULL,
	[Manufacturer] NVARCHAR(20) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] DATE,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]),
	[Doors] INT,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(20),
	[Available] BIT NOT NULL,
)
--	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(15) NOT NULL,
	[LastName] NVARCHAR(15) NOT NULL,
	[Title] NVARCHAR(15) NOT NULL,
	[Notes] NVARCHAR(100)
)
--	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] NVARCHAR(20) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(100)
)
--	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE RentalOrders(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES Customers([Id]),
	[CarId] INT FOREIGN KEY REFERENCES Cars([Id]),
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] AS [KilometrageStart] - [KilometrageEnd],
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL,
	[TotalDays] AS DATEDIFF(Day, [StartDate], [EndDate]),
	[RateApplied] DECIMAL(3,1) NOT NULL,
	[TaxRate] DECIMAL(6,2) NOT NULL,
	[OrderStatus] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(100)
)

--	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
INSERT INTO Categories([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
('Hatchbag', 3.50, 8.50, 30.50, 20.66),
('Sedan', 5.50, 10.50, 40.50, 18.26),
('Coupe', 6.50, 11.50, 35.50, 23.56)

--	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)

INSERT INTO Cars([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES
('CT2030PB', 'Audi', 'A6', '2007', 2, 4, NULL, 'USED', 0),
('B4004PP', 'Audi', 'A3', '2007', 3, 2, NULL, 'USED', 1),
('A2121AP', 'Mercedes', 'C220', '2021', 2, 4, NULL, 'NEW', 0)

--	Employees (Id, FirstName, LastName, Title, Notes)

INSERT INTO Employees([FirstName],[LastName],[Title],[Notes])
VALUES
('Yordan', 'Dimitrov', 'Administrator', NULL),
('Georgi', 'Ivanov', 'Àccountant', NULL),
('Petur', 'Petrov', 'Seller', NULL)

--	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)

INSERT INTO Customers([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES
('555555555', 'Stoqn Ivanov', 'Zagore 13', 'Stara Zagora' , 5566 , NULL),
('777777777', 'Dimitur Petrov', 'Hr. Botev 33', 'Plovdiv', 1332, NULL),
('999999999', 'Ivan Stoqnov', 'Stoletov 26', 'Burgas' , 2222 , NULL)
--	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

INSERT INTO RentalOrders([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
		(1,1,1,20,20,40,'2019-03-12','2019-03-18',
		50.00,50.00,'COMPLETE', NULL),
		(2,2,2,15,40,65,'2021-02-02','2021-02-04',
		55.00,55.00,'COMPLETE', NULL),
		(3,3,3,5,40,80,'2020-08-08','2020-08-18',
		80.00,80.00,'COMPLETE', NULL)

