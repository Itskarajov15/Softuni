CREATE PROC AddToProject(@EmployeeId INT, @ProjectId INT)
AS
	 DECLARE @EmployeesProjects INT = 
		(SELECT COUNT(*) FROM EmployeesProjects
			WHERE EmployeeID = @EmployeeId)

	 IF (@EmployeesProjects >= 3)
		THROW 50001, 'Employee has more than 3 projects', 1

	 INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
		VALUES (@EmployeeId, @ProjectId)

GO