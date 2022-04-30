/*
Create a table – Logs. Add a trigger to the Accounts table that enters a new entry into the Logs table every 
time the sum on an account change 
*/
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
);

CREATE TRIGGER tr_OnAccountChangeAddLogRecord
ON Accounts FOR UPDATE
AS
	INSERT Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance FROM inserted i 
	JOIN deleted d ON d.Id = i.Id
GO

/*
Create table – NotificationEmails. Add a trigger to logs table and create 
new email whenever new record is inserted in logs table
*/
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL REFERENCES Accounts(Id),
	[Subject] VARCHAR(50),
	Body VARCHAR(MAX)
);

CREATE TRIGGER tr_CreateEmailOnNewRecordAdded
ON Logs FOR INSERT
AS
	INSERT NotificationEmails (Recipient, [Subject], Body)
	SELECT AccountId,
		   'Balance change for account: ' + CONVERT(VARCHAR(50), AccountId) AS [Subject], 
		   'On ' + CONVERT(VARCHAR(50), GETDATE(), 103) + ' your balance was changed from ' + 
		   CONVERT(VARCHAR(50), OldSum) + ' to ' + CONVERT(VARCHAR(50), NewSum) AS Body
		 FROM inserted
GO

/*
Create stored procedure for depositing money
*/
CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
	BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Money amount cannot be a negative number', 1
	END
	
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId);

	IF (@account IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid AccountId', 1
	END

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
	COMMIT
GO

/*
Create stored procedure from withdrawing money
*/
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
	BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF(@account IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Invalid AccountId', 1
	END

	IF(@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Money amount cannot be a negative number', 1
	END

	IF((SELECT Balance FROM Accounts WHERE Id = @AccountId) < @MoneyAmount)
	BEGIN
		ROLLBACK;
		THROW 50003, 'Insufficient funds', 1
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
	COMMIT
GO

/*
Create stored procedure that transfers money from one account to another
*/
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
AS
	BEGIN TRANSACTION
	IF((SELECT Id FROM Accounts WHERE Id = @SenderId) IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'SenderId is invalid', 1
	END
	ELSE IF((SELECT Id FROM Accounts WHERE Id = @ReceiverId) IS NULL)
	BEGIN
		ROLLBACK;
		THROW 50001, 'ReceiverId is invalid', 1
	END

	IF(@Amount < 0)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Amount cannot be a negative number', 1
	END

	IF((SELECT Balance FROM Accounts WHERE Id = @SenderId) < @Amount)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Insufficient funds', 1
	END

	EXEC usp_WithdrawMoney @SenderId, @Amount;
	EXEC usp_DepositMoney @ReceiverId, @Amount;
	COMMIT
GO