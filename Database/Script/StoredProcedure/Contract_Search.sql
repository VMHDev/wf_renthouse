--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_Search]
GO
CREATE PROCEDURE [dbo].[Contract_Search]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pIDEmployee bigint = -1,
	@pContractDate varchar(10) = '',
	@pStatus char(1) = ''
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
	WHERE 1 = 1
		  AND (CON.IDCustomer = @pIDCustomer OR @pIDCustomer IS NULL OR @pIDCustomer = -1)
	      AND (CON.IDHouse = @pIDHouse OR @pIDHouse IS NULL OR @pIDHouse = -1)
		  AND (CON.IDEmployee = @pIDEmployee OR @pIDEmployee IS NULL OR @pIDEmployee = -1)
		  AND (CONVERT(varchar(10), CON.[ContractDate], 103) = @pContractDate OR @pContractDate IS NULL OR @pContractDate = CONVERT(varchar(10), getdate(), 103))
		  AND (CON.[Status] = @pStatus OR @pStatus IS NULL OR @pStatus = '')
GO

--SELECT CONVERT(varchar(10), CON.[ContractDate], 103), CONVERT(varchar(10), getdate(), 103)
--FROM [Contract] CON