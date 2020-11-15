--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Users_InsUpd]
	@pUserName nvarchar(255) = NULL,
	@pPassword varchar(255) = NULL,
	@pIsAdmin bit = NULL,
	@pIsActive bit = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''
	
	IF NOT EXISTS (SELECT TOP 1 1  FROM [Users] WHERE [UserName] = @pUserName)
	BEGIN
		INSERT INTO [dbo].[Users]([UserName],
								  [Password],
								  [IsAdmin], 
								  [IsActive])
		 VALUES(@pUserName,
		        @pPassword,
		        @pIsAdmin,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Users]
		SET [Password] = @pPassword,
			[IsAdmin] =  @pIsAdmin
		WHERE [UserName] = @pUserName
	END

COMMIT TRANSACTION
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm người dùng thất bại!'
	SELECT -1 AS Result, @vMessage ErrorDesc
	RETURN -1
END
GO

--EXEC Users_InsUpd 'A', 'B', 1, 1
--SELECT * FROM Users