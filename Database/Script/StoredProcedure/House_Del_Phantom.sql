--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[House_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''

	IF NOT EXISTS (SELECT * FROM House WHERE [ID] = @pID)
    BEGIN
        SET @vMessage = 'Không tồn tại!'
        GOTO ABORT
    END 
    
    DELETE FROM [HOUSE] 
	WHERE [ID] = @pID
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