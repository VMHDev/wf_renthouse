--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[House_InsUpd]
	@pID bigint = -1,
	@pRoomNumber int = 1,
	@pFeeMonth bigint = 1,
	@pIDHouseholder bigint = NULL,
	@pIDEmployee bigint = NULL,
	@pIDHouseType bigint = NULL,
	@pIDLocation bigint = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[House](	[RoomNumber],
									[FeeMonth],
									[IDHouseholder],
									[IDEmployee],
									[IDHouseType],
									[IDLocation],
									[IsActive])
		 VALUES(@pRoomNumber,
		        @pFeeMonth,
		        @pIDHouseholder,
		        @pIDEmployee,
				@pIDHouseType,
				@pIDLocation,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		IF NOT EXISTS (SELECT * FROM House WHERE [ID] = @pID)
		BEGIN
			SET @vMessage = N'Nhà không tồn tại'
			GOTO ABORT
		END 

		UPDATE [dbo].[House]
		SET [RoomNumber] = @pRoomNumber,
			[FeeMonth] = @pFeeMonth,
			[IDHouseholder] = @pIDHouseholder,
			[IDEmployee] = @pIDEmployee,
			[IDHouseType] = @pIDHouseType,
			[IDLocation] = @pIDLocation
		WHERE [ID] = @pID
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage = '')
	BEGIN
		SET @vMessage = 'Cập nhật nhà thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO