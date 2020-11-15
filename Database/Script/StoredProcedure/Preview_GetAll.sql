--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Preview_GetAll]
AS
	SELECT PRV.IDHouse,
		   CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS CodeHouse,
		   HOU.RoomNumber,
		   HOU.FeeMonth,
		   PRV.IDCustomer,
		   CUS.Name AS NameCustomer,
		   CONVERT(varchar(10), PRV.PreviewDate, 103) AS PreviewDate,
		   PRV.Comment
	FROM Preview PRV
		 LEFT JOIN House HOU ON HOU.ID = PRV.IDHouse
		 LEFT JOIN Customer CUS ON CUS.ID = PRV.IDCustomer
GO

