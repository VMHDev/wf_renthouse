--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_Search]
GO
CREATE PROCEDURE [dbo].[Preview_Search]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pPreviewDate varchar(10) = ''
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
	WHERE 1 = 1
		  AND (PRV.IDCustomer = @pIDCustomer OR @pIDCustomer IS NULL OR @pIDCustomer = -1)
	      AND (PRV.IDHouse = @pIDHouse OR @pIDHouse IS NULL OR @pIDHouse = -1)
		  AND (CONVERT(varchar(10), PRV.PreviewDate, 103) = @pPreviewDate OR @pPreviewDate IS NULL OR @pPreviewDate = CONVERT(varchar(10), getdate(), 103))
GO