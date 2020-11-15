--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Contract_Del]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pIDEmployee bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM [Contract] WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND IDEmployee =  @pIDEmployee)
	BEGIN
		DELETE FROM [Contract] WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND IDEmployee =  @pIDEmployee
	END
	ELSE
	BEGIN
		SET @vMessage = N'Không tồn tại!'
		GOTO ABORT
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO

--SELECT * FROM Contract
--EXEC Contract_Del 2, 3, 2

--SELECT * fROM Employee

