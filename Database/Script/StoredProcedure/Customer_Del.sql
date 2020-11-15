--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_Del]
GO
CREATE PROCEDURE [dbo].[Customer_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  Customer WHERE ID = @pID)
	BEGIN
		UPDATE Customer SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
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