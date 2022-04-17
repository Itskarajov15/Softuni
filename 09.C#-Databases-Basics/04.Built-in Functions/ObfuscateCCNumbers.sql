SELECT CustomerID AS ID, 
	FirstName,
	LastName,
	CONCAT(LEFT(PaymentNumber, 6), REPLICATE('*', LEN(PaymentNumber) - 6)) AS [Payment Number]
	FROM Customers