--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[House_Search]
	@pID bigint = '',
	@pRoomNumber int = 1,
	@pFeeMonth bigint = 1,
	@pIDHouseholder bigint = NULL,
	@pIDEmployee bigint = NULL,
	@pIDHouseType bigint = NULL,
	@pIDLocation bigint = NULL
AS
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
	WHERE HOU.[IsActive] = 1
		  AND (HOU.[ID] = @pID OR @pID IS NULL OR @pID = -1)
		  AND (HOU.[RoomNumber] = @pRoomNumber OR @pRoomNumber IS NULL OR @pRoomNumber = -1)
		  AND (HOU.[FeeMonth] = @pFeeMonth OR @pFeeMonth IS NULL OR @pFeeMonth = -1)
		  AND (HOU.[IDHouseholder] = @pIDHouseholder OR @pIDHouseholder IS NULL OR @pIDHouseholder = -1)
		  AND (HOU.[IDEmployee] = @pIDEmployee OR @pIDEmployee IS NULL OR @pIDEmployee = -1)
		  AND (HOU.[IDHouseType] = @pIDHouseType OR @pIDHouseType IS NULL OR @pIDHouseType = -1)
		  AND (HOU.[IDLocation] = @pIDLocation OR @pIDLocation IS NULL OR @pIDLocation = -1)
GO