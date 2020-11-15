IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_XemThongTinNha]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_XemThongTinNha]
GO
CREATE PROCEDURE [dbo].[sp_XemThongTinNha]
	@pID int
AS
BEGIN
    BEGIN TRAN
    IF NOT EXISTS (SELECT * FROM House WHERE [ID] = @pID)
    BEGIN
        RAISERROR(N'Nhà không tồn tại', 10, 1)
        RETURN
    END 
    
    SELECT HOU.[ID],
	       HOU.[RoomNumber],
	       HOU.[FeeMonth],
	       HOU.[IDHouseholder],
		   HHD.[Name] AS HouseholderName,
	       HOU.[IDEmployee],
		   EMP.[Name] AS EmployeeName,
	       HOU.[IDHouseType],
		   HUT.[Name] AS HouseTypeName,
	       HOU.[IDLocation],
		   LCT.[StreetName] + ', ' + LCT.[District] + ', ' + LCT.[City] AS [Address],
		   LCT.[Region],
	       HOU.[IsActive]
	FROM House HOU
		 LEFT JOIN Employee EMP ON EMP.ID = HOU.IDEmployee
		 LEFT JOIN HouseType HUT ON HUT.ID = HOU.IDHouseType
		 LEFT JOIN Householder HHD ON HHD.ID = HOU.IDHouseholder
		 LEFT JOIN Location LCT ON LCT.ID = HOU.IDLocation
	WHERE HOU.[IsActive] = 1 and HOU.[ID] = @pID

    IF @@error <> 0
    BEGIN
        RAISERROR(N'Có lỗi xảy ra, phải rollback', 10, 1)
        ROLLBACK TRAN
        RETURN
    END
    COMMIT TRAN
END
GO