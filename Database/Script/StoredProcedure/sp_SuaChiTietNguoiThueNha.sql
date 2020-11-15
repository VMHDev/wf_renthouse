--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SuaChiTietNguoiThueNha]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SuaChiTietNguoiThueNha]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuaChiTietNguoiThueNha]
	@pID bigint,
    @pName nvarchar(255)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
    BEGIN TRANSACTION;
    SAVE TRANSACTION editHouseHolder;
    BEGIN TRY
        IF NOT EXISTS (SELECT * FROM [dbo].[HouseHolder] WHERE [ID] = @pID)
        BEGIN
            SELECT N'Người thuê không tồn tại'
            RETURN
        END 
        
        UPDATE [dbo].[HouseHolder]
        SET [Name] = @pName
        WHERE [ID] = @pID

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            SELECT N'Có lỗi xảy ra'
            ROLLBACK TRANSACTION editHouseHolder;
        END
    END CATCH
END
GO