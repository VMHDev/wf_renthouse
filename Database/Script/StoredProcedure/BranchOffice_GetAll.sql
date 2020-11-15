--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchOffice_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BranchOffice_GetAll]
GO
CREATE PROCEDURE [dbo].[BranchOffice_GetAll]
AS
	SELECT BRO.[ID],
	       BRO.[Name],
	       BRO.[Phone],
	       BRO.[Fax],
	       BRO.[IDLocation],
		   LAC.[StreetName] + ', ' + LAC.[District] + ', ' + LAC.[City] AS [Address],
		   LAC.[Region],
	       BRO.[IsActive]
	FROM BranchOffice BRO
		 LEFT JOIN Location LAC ON LAC.ID = BRO.ID
	WHERE BRO.[IsActive] = 1
GO