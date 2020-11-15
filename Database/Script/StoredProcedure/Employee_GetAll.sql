--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_GetAll]
GO
CREATE PROCEDURE [dbo].[Employee_GetAll]
AS
	SELECT	EMP.[ID],
			EMP.[Name],
			EMP.[Address],
			EMP.[Phone],
			EMP.[Gender],
			CONVERT(varchar(10), EMP.[Birthday], 103) AS Birthday,
			EMP.[Salary],
			EMP.[IDBranchOffice],
			BRO.[Name] AS BranchOfficeName,
			EMP.[IsActive]
	FROM Employee EMP
		 LEFT JOIN BranchOffice BRO ON BRO.ID = EMP.IDBranchOffice
	WHERE EMP.[IsActive] = 1
GO