--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_InsUpd]
	@pID bigint = -1,	
	@pName nvarchar(255) = '',
	@pAddress nvarchar(255) = '',
	@pPhone varchar(15) = '',
	@pGender bit = 1,
	@pBirthday datetime = NULL,
	@pSalary bigint = 0,
	@pIDBranchOffice bigint = NULL,
	@pPassword varchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Employee]( [Name],
									  [Address],
									  [Phone],
									  [Gender],
									  [Birthday],
									  [Salary],
									  [IDBranchOffice],
									  [IsActive])
		 VALUES(@pName,
		        @pAddress,
		        @pPhone,
		        @pGender,
				CONVERT(date, @pBirthday),
				@pSalary,
				@pIDBranchOffice,
		        1)
		IF @@Error <> 0 GOTO ABORT

		INSERT INTO [dbo].[Users]([UserName],
								  [Password],
								  [IsAdmin], 
								  [IsActive])
		VALUES(IDENT_CURRENT('Employee'),
		        @pPassword,
		        0,
		        1)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Employee]
		SET [Name] = @pName,
			[Address] = @pAddress,
			[Phone] = @pPhone,
			[Gender] = @pGender,
			[Birthday] = @pBirthday,
			[Salary] = @pSalary,
			[IDBranchOffice] = @pIDBranchOffice
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm nhân viên thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO

--SELECT CONVERT(datetime, '01/01/1990', 103)
--DECLARE @date datetime
--SET  @date =  CONVERT(datetime, '01/01/1990', 103)

--EXEC Employee_InsUpd 1, N'Nguyễn Văn A', 'B', 'C', 1, @date, 100, 0, 1
--SELECT * FROM Employee
--SELECT IDENT_CURRENT('Employee')
