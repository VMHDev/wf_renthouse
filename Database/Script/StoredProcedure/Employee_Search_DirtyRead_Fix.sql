--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_Search]
	@pID bigint = '',	
	@pName nvarchar(255) = '',
	@pAddress nvarchar(255) = '',
	@pPhone varchar(15) = '',
	@pGender bit = -1,
	@pBirthday varchar(10) = '',
	@pSalary bigint = -1,
	@pIDBranchOffice bigint = NULL
AS
SET TRAN ISOLATION LEVEL READ COMMITTED		-- Test Dirty read
BEGIN TRANSACTION
	SELECT	EMP.[ID],
			EMP.[Name],
			EMP.[Address],
			EMP.[Phone],
			EMP.[Gender],
			EMP.[Birthday],
			EMP.[Salary],
			EMP.[IDBranchOffice],
			BRO.[Name] AS BranchOfficeName,
			EMP.[IsActive]
	FROM Employee EMP
		 LEFT JOIN BranchOffice BRO ON BRO.ID = EMP.IDBranchOffice
	WHERE EMP.[IsActive] = 1
		  AND (EMP.[ID] = @pID OR @pID IS NULL OR @pID = -1)
		  AND (EMP.[Name] LIKE N'%' + @pName + '%' OR @pName IS NULL OR @pName = '')
		  AND (EMP.[Address] LIKE N'%' + @pAddress + '%' OR @pAddress IS NULL OR @pAddress = '')
		  AND (EMP.[Phone] LIKE N'%' + @pPhone + '%' OR @pPhone IS NULL OR @pPhone = '')
		  AND (EMP.[Gender] = @pGender OR @pGender IS NULL OR @pID = -1)
		  AND (CONVERT(varchar(10), EMP.[Birthday], 103) = @pBirthday OR @pBirthday IS NULL OR @pBirthday = CONVERT(varchar(10), getdate(), 103))
		  AND (EMP.[Salary] = @pSalary OR @pSalary IS NULL OR @pSalary = -1)
		  AND (EMP.[IDBranchOffice] = @pIDBranchOffice OR @pIDBranchOffice IS NULL OR @pIDBranchOffice = -1)
COMMIT TRANSACTION
GO

--DECLARE @pName nvarchar(255) = ''
--SET @pName = 'Võ Văn B'
--PRINT N'''' + @pName + ''''
--PRINT 'N' + @pName
--SELECT * FROM Employee WHERE Name LIKE N'%' + @pName + '%' OR @pName IS NULL OR @pName = ''