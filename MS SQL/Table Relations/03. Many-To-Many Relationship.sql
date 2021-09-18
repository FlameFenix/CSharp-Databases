CREATE TABLE Students(
	[StudentID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
)

CREATE TABLE Exams(
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] NVARCHAR(20),
)

CREATE TABLE StudentsExams(
	[StudentID] INT FOREIGN KEY REFERENCES Students([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES Exams([ExamID])
	PRIMARY KEY (StudentID, ExamId)
)

INSERT INTO Students
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle11g')

INSERT INTO StudentsExams
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)