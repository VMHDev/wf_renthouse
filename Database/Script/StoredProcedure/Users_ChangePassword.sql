--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_ChangePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_ChangePassword]
GO
CREATE PROCEDURE [dbo].[Users_ChangePassword]
	@pUserName nvarchar(255) = '',
	@pOldPass varchar(255) = '',
	@pNewPass varchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF EXISTS (SELECT TOP 1 1  FROM [Users] WHERE [UserName] = @pUserName AND [Password] = @pOldPass)
	BEGIN
		UPDATE [dbo].[Users]
		SET [Password] = @pNewPass
		WHERE [UserName] = @pUserName
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		SET @vMessage = N'Tên đăng nhập, Mật khẩu cũ không hợp lệ!'
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage != '')
	BEGIN
			SET @vMessage = N'Đổi mật khẩu thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO