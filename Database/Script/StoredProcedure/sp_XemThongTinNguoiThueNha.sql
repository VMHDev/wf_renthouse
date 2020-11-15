--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_XemThongTinNguoiThueNha]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_XemThongTinNguoiThueNha]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XemThongTinNguoiThueNha]
	@pID bigint = -1
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRANSACTION;
    SAVE TRANSACTION showHouseHolder;
    BEGIN TRY
        IF NOT EXISTS (SELECT * FROM [dbo].[HouseHolder] WHERE [ID] = @pID)
        BEGIN
            SELECT N'NGười thuê nhà không tồn tại'
            RETURN
        END 
        
        SELECT * FROM [dbo].[HouseHolder] WHERE [ID] = @pID

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            SELECT N'Có lỗi xảy ra'
            ROLLBACK TRANSACTION showHouseHolder;
        END
    END CATCH
END
GO