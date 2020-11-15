--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Householder_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Householder_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Householder_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pAddress nvarchar(max) = '',
	@pPhone varchar(15) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Householder]([Name],
										[Address],
										[Phone],
										[IsActive])
		 VALUES(@pName,
		        @pAddress,
		        @pPhone,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Householder]
		SET [Name] = @pName,
			[Address] = @pAddress,
			[Phone] = @pPhone
		WHERE [ID] = @pID
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm chủ nhà thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO

--EXEC Householder_InsUpd '', 'A', 'B', 'C', 1
--SELECT * FROM Householder