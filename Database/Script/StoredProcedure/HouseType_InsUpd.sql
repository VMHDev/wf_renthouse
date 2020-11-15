--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HouseType_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HouseType_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HouseType_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = NULL,
	@pDescription nvarchar(max) = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[HouseType]( [Name],
									   [Description],
									   [IsActive])
		 VALUES(@pName,
		        @pDescription,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[HouseType]
		SET [Name] = @pName,
			[Description] = @pDescription
		WHERE [ID] = @pID
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm địa điểm thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO

--EXEC HouseType_InsUpd '', 'A', 'B', 1
--SELECT * FROM HouseType