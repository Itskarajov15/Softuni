CREATE TABLE People
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height NUMERIC(9, 2),
	[Weight] NUMERIC(9, 2),
	Gender VARCHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People (Id, Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
(1, 'Maria', 'https://avatars.githubusercontent.com/u/89154014?v=4', 1.64, 65.77, 'f', '1985/01/17', 'Marias Bio'),
(2, 'Peter', 'https://avatars.githubusercontent.com/u/89154014?v=4', 1.88, 87.00, 'm', '1980/06/11', 'Peters Bio'),
(3, 'Ida', 'https://avatars.githubusercontent.com/u/89154014?v=4', 1.64, 65.77, 'f', '1985/05/03', 'Idas Bio'),
(4, 'Nia', 'https://avatars.githubusercontent.com/u/89154014?v=4', 1.70, 60.52, 'f', '1975/06/06', 'Nias Bio'),
(5, 'Tom', 'https://avatars.githubusercontent.com/u/89154014?v=4', 1.90, 85.7, 'm', '1995/08/08', 'Toms Bio')