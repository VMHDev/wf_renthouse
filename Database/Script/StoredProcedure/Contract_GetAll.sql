--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_GetAll]
GO
CREATE PROCEDURE [dbo].[Contract_GetAll]
AS
	SELECT CON.IDHouse,
		   CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS CodeHouse,
		   HOU.RoomNumber,
		   HOU.FeeMonth,
		   CON.IDCustomer,
		   CUS.Name AS NameCustomer,
		   CONVERT(varchar(10), CON.ContractDate, 103) AS ContractDate,
		   CON.IDEmployee,
		   EMP.Name AS NameEmployee
	FROM [Contract] CON
		 LEFT JOIN House HOU ON HOU.ID = CON.IDHouse
		 LEFT JOIN Customer CUS ON CUS.ID = CON.IDCustomer
		 LEFT JOIN Employee EMP ON EMP.ID = CON.IDEmployee
GO