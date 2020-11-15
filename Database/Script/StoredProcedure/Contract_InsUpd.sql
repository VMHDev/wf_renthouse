--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Contract_InsUpd]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pIDEmployee bigint = -1,
	@pStatus char(1) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF NOT EXISTS (SELECT TOP 1 1 FROM [Contract] WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND IDEmployee =  @pIDEmployee)
	BEGIN
		INSERT INTO [dbo].[Contract]([IDCustomer],
									 [IDHouse],
									 [IDEmployee],
									 [ContractDate],
									 [Status])
		 VALUES(@pIDCustomer,
		        @pIDHouse,
				@pIDEmployee,
		        GETDATE(),
		        @pStatus)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Contract]
		SET [Status] = @pStatus
		WHERE [IDCustomer] = @pIDCustomer AND [IDHouse] = @pIDHouse AND [IDEmployee] = @pIDEmployee
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Cập nhật hợp đồng thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO