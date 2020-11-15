--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_SuaChiTietNha]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_SuaChiTietNha]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuaChiTietNha]
	@pID bigint = -1,
    @pRoomNumber int  = -1
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
    SAVE TRANSACTION editHouse;
    BEGIN TRANSACTION;
    BEGIN TRY
        IF NOT EXISTS (SELECT * FROM [dbo].[House] WHERE [ID] = @pID)
        BEGIN
            SELECT N'Nhà không tồn tại'
            RETURN
        END 
        
        UPDATE [dbo].[House]
        SET [RoomNumber] = @pRoomNumber
        WHERE [ID] = @pID

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            SELECT N'Có lỗi xảy ra'
            ROLLBACK TRANSACTION editHouse;
        END
    END CATCH
END
GO