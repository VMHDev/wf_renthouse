--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_GetAll]
GO
CREATE PROCEDURE [dbo].[House_GetAll]
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
GO