CREATE DATABASE WMS

USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
);

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(255) NOT NULL
);

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL,
	[Status] NVARCHAR(11) NOT NULL DEFAULT 'Pending',
	ClientId INT NOT NULL,
	MechanicId INT,
	IssueDate DATE NOT NULL,
	FinishDate DATE,

	CHECK ([Status] IN ('Pending', 'In Progress','Finished')),
	FOREIGN KEY (ModelId) REFERENCES Models(ModelId),
	FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
	FOREIGN KEY (MechanicId) REFERENCES Mechanics(MechanicId)
);

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL,
	IssueDate DATE,
	Delivered BIT NOT NULL DEFAULT 1,

	FOREIGN KEY (JobId) REFERENCES Jobs(JobId)
);

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber NVARCHAR(50) NOT NULL UNIQUE,
	[Description] NVARCHAR(255),
	Price DECIMAL(15, 3) NOT NULL,
	VendorId INT NOT NULL,
	StockQty INT NOT NULL DEFAULT 0,

	CHECK (Price > 0),
	CHECK (StockQty >= 0),
	FOREIGN KEY (VendorId) REFERENCES Vendors(VendorId)
);

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL,
	PartId INT NOT NULL,
	Quantity INT NOT NULL DEFAULT 1,

	CHECK (Quantity > 0),
	CONSTRAINT PK_OrderId_PartId PRIMARY KEY (OrderId, PartId),
	FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
	FOREIGN KEY (PartId) REFERENCES Parts(PartId)
);

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL,
	PartId INT NOT NULL,
	Quantity INT NOT NULL,

	CHECK (Quantity > 0),
	CONSTRAINT PK_JobId_PartId PRIMARY KEY (JobId, PartId),
	FOREIGN KEY (JobId) REFERENCES Jobs(JobId),
	FOREIGN KEY (PartId) REFERENCES Parts(PartId)
);

--
INSERT INTO Clients (FirstName, LastName, Phone)
VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke	', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId)
VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE MechanicId IS NULL

--
DELETE FROM OrderParts
	WHERE OrderId = 19

DELETE FROM Orders
	WHERE OrderId = 19

--
SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
       j.Status,
	   j.IssueDate
	FROM Mechanics m
	JOIN Jobs j ON j.MechanicId = m.MechanicId
	ORDER BY m.MechanicId, j.IssueDate, j.JobId

--
SELECT c.FirstName + ' ' + c.LastName AS Client,
       DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	   j.[Status]
	FROM Clients c
	JOIN Jobs j ON j.ClientId = c.ClientId
	WHERE Status != 'Finished'
	ORDER BY [Days going] DESC, c.ClientId ASC

--
SELECT m.FirstName + ' ' + m.LastName AS Mechanic,
	   AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	FROM Mechanics m
	JOIN Jobs j ON j.MechanicId = m.MechanicId
	GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName)
	ORDER BY m.MechanicId

--
SELECT m.FirstName + ' ' + m.LastName AS Available 
	FROM Mechanics m
	LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(JobId) 
										FROM Jobs
										WHERE Status <> 'Finished' AND MechanicId = m.MechanicId
										GROUP BY MechanicId, Status) IS NULL
	GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName)
	ORDER BY m.MechanicId

--
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
	FROM Jobs j
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	LEFT JOIN Parts p ON p.PartId = op.PartId
	WHERE j.Status = 'Finished'
	GROUP BY j.JobId
	ORDER BY Total DESC, j.JobId ASC

--
SELECT p.PartId,
       p.Description,
	   pn.Quantity AS Required,
	   p.StockQty AS [In Stock],
	   IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
	FROM Parts p
	LEFT JOIN PartsNeeded pn ON pn.PartId = p.PartId
	LEFT JOIN OrderParts op ON op.PartId = p.PartId
	LEFT JOIN Jobs j ON j.JobId = pn.JobId
	LEFT JOIN Orders o ON o.JobId = j.JobId 
	WHERE j.Status != 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0)< pn.Quantity
	ORDER BY p.PartId ASC