--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_Login]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[Users_Login]
	@pUserName nvarchar(20) = NULL,
	@pPassword varchar(50) = NULL	
AS
	DECLARE @sResult varchar(20)
	DECLARE @sUserID varchar(15)
	DECLARE @sActive char(1)
	DECLARE @sErrorDesc nvarchar(1000)

	IF EXISTS(SELECT TOP 1 1 FROM Users WHERE UserName = @pUserName AND [Password] = @pPassword AND IsActive = 1)
	BEGIN
		SELECT	1 AS Result,
				USR.UserName,
				USR.IsActive
		FROM Users USR
		WHERE UserName = @pUserName 
	END
	ELSE
	BEGIN
		SELECT	0 AS Result,
				'' AS UserName,
				'' AS IsActive	
	END
GO


