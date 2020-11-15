IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_XoaMotNha]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_XoaMotNha]
GO
CREATE PROCEDURE [dbo].[sp_XoaMotNha]
	@pID int
AS
BEGIN
    BEGIN TRAN
    IF NOT EXISTS (SELECT * FROM House WHERE [ID] = @pID)
    BEGIN
        RAISERROR(N'Nhà không tồn tại', 10, 1)
        RETURN
    END 
    
    DELETE FROM [HOUSE] 
	WHERE [ID] = @pID

    IF @@error <> 0
    BEGIN
        RAISERROR(N'Có lỗi xảy ra, phải rollback', 10, 1)
        ROLLBACK TRAN
        RETURN
    END
    COMMIT TRAN
END
GO