--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Preview_Del]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pPreviewDate varchar(10) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM Preview WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND (CONVERT(varchar(10), PreviewDate, 103) = @pPreviewDate))
	BEGIN
		DELETE FROM Preview WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND (CONVERT(varchar(10), PreviewDate, 103) = @pPreviewDate)
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

--SELECT * FROM Preview WHERE CONVERT(varchar(10), PreviewDate, 103) = '01/10/2019'

--SELECT * FROM Preview WHERE PreviewDate = CONVERT(datetime, '01/10/2019', 103)

