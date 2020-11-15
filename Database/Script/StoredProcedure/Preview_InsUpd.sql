--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Preview_InsUpd]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pComment nvarchar(max) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF NOT EXISTS (SELECT TOP 1 1 FROM Preview WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND CONVERT(date, PreviewDate) = CONVERT(date, GETDATE()))
	BEGIN
		INSERT INTO [dbo].[Preview]([IDCustomer],
									[IDHouse],
									[PreviewDate],
									[Comment])
		 VALUES(@pIDCustomer,
		        @pIDHouse,
		        CONVERT(date, GETDATE()),
		        @pComment)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Preview]
		SET [Comment] = @pComment
		WHERE [IDCustomer] = @pIDCustomer AND [IDHouse] = @pIDHouse AND CONVERT(date, [PreviewDate]) = CONVERT(date, GETDATE())
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Cập nhật giao dịch xem nhà thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO