--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchOffice_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BranchOffice_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BranchOffice_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pPhone varchar(15) = '',
	@pFax varchar(20) = '',
	@pIDLocation bigint
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[BranchOffice]( [Name],
										  [Phone],
										  [Fax],
										  [IDLocation],
										  [IsActive])
		 VALUES(@pName,
		       @pPhone,
		       @pFax,
		       @pIDLocation,
		       1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[BranchOffice]
		SET [Name] = @pName,
			[Phone] = @pPhone,
			[Fax] = @pFax,
			[IDLocation] = @pIDLocation
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm chi nhánh thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO

--EXEC BranchOffice_InsUpd '', 'A', 'B', 'C', 0
--SELECT * FROM BranchOffice