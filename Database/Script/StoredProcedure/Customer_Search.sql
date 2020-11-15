--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customer_Search]
	@pID bigint = '',
	@pName varchar(255) = '',
	@pPhone varchar(15) = '',
	@pAddress varchar(max) = '',
	@pDescription nvarchar(max) = '',
	@pAbilityRent bit = -1,
	@pIDBranchOffice bigint = NULL
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
		 AND (CUS.[ID] = @pID OR @pID IS NULL OR @pID = -1)
		 AND (CUS.[Name] LIKE '%' + @pName + '%' OR @pName IS NULL OR @pName = '')
		 AND (CUS.[Phone] LIKE '%' + @pPhone + '%' OR @pPhone IS NULL OR @pPhone = '')
		 AND (CUS.[Address] LIKE '%' + @pAddress + '%' OR @pAddress IS NULL OR @pAddress = '')
		 AND (CUS.[Description] LIKE '%' + @pDescription + '%' OR @pDescription IS NULL OR @pDescription = '')
		 AND (CUS.[AbilityRent] = @pAbilityRent OR @pAbilityRent IS NULL OR @pAbilityRent = -1)
		 AND (CUS.[IDBranchOffice] = @pIDBranchOffice OR @pIDBranchOffice IS NULL OR @pIDBranchOffice = -1)
GO

--SELECT * FROM Customer WHERE AbilityRent = 1