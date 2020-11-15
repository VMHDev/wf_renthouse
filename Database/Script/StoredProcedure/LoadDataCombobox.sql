--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadDataCombobox]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadDataCombobox]
GO
CREATE PROCEDURE [dbo].[LoadDataCombobox]
	@pType varchar(20) = ''
AS
	IF(@pType = 'BRA')
	BEGIN
		SELECT BRO.[ID] AS [Value],
		       BRO.[Name] AS [Display]
		FROM BranchOffice BRO
		WHERE BRO.[IsActive] = 1
	END
	--ELSE IF(@pType = 'CON')
	--BEGIN
	--	SELECT BRO.[ID] AS [Value],
	--	       BRO.[Name] AS [Display]
	--	FROM BranchOffice BRO
	--	WHERE BRO.[IsActive] = 1
	--END
	ELSE IF(@pType = 'CUS')
	BEGIN
		SELECT CUS.[ID] AS [Value],
		       CUS.[Name] AS [Display]
		FROM Customer CUS
		WHERE CUS.[IsActive] = 1
	END
	ELSE IF(@pType = 'EMP')
	BEGIN
		SELECT EMP.[ID] AS [Value],
		       EMP.[Name] AS [Display]
		FROM Employee EMP
		WHERE EMP.[IsActive] = 1
	END
	ELSE IF(@pType = 'HOU')
	BEGIN
		SELECT HOU.[ID] AS [Value],
		       CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS [Display]
		FROM House HOU
		WHERE HOU.[IsActive] = 1
	END
	ELSE IF(@pType = 'HOH')
	BEGIN
		SELECT HOH.[ID] AS [Value],
		       HOH.[Name] AS [Display]
		FROM Householder HOH
		WHERE HOH.[IsActive] = 1
	END
	ELSE IF(@pType = 'HOT')
	BEGIN
		SELECT HOT.[ID] AS [Value],
		       HOT.[Name] AS [Display]
		FROM HouseType HOT
		WHERE HOT.[IsActive] = 1
	END
	ELSE IF(@pType = 'LOC')
	BEGIN
		SELECT LOC.[ID] AS [Value],
		       LOC.[StreetName] + ', ' + LOC.[District] + ', ' + LOC.[City] + ', ' + LOC.[Region] AS [Display]
		FROM Location LOC
		WHERE LOC.[IsActive] = 1
	END
	ELSE IF(@pType = 'URS')
	BEGIN
		SELECT URS.[UserName] AS [Value],
		       URS.[UserName] AS [Display]
		FROM Users URS
		WHERE URS.[IsActive] = 1
	END
GO