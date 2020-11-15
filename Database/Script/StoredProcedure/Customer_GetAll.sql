--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_GetAll]
GO
CREATE PROCEDURE [dbo].[Customer_GetAll]
AS
	SELECT CUS.[ID],
	       CUS.[Name],
	       CUS.[Phone],
	       CUS.[Address],
	       CUS.[Description],
	       CUS.[AbilityRent],
	       CUS.[IDBranchOffice],
		   BRO.[Name] AS BranchOfficeName,
	       CUS.[IsActive]
	FROM Customer CUS
		 LEFT JOIN BranchOffice BRO ON BRO.ID = CUS.IDBranchOffice
	WHERE CUS.[IsActive] = 1
GO