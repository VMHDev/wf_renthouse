--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Location_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Location_InsUpd]
	@pID bigint = -1,
	@pStreetName nvarchar(max) = '',
	@pDistrict nvarchar(255) = '',
	@pCity nvarchar(255) = '',
	@pRegion nvarchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Location]( [StreetName],
									  [District],
									  [City],
									  [Region],
									  [IsActive])
		 VALUES(@pStreetName,
		        @pDistrict,
		        @pCity,
		        @pRegion,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Location]
		SET [StreetName] = @pStreetName, 
			[District] = @pDistrict,
			[City] = @pCity,
			[Region] = @pRegion
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
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

--EXEC Location_InsUpd '', 'A', 'B', 'C', 'D'
--SELECT * FROM Location

--ID,
--StreetName,
--District,
--City,
--Region,
--IsActive,

