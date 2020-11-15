--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Householder_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Householder_GetAll]
GO
CREATE PROCEDURE [dbo].[Householder_GetAll]
AS
	SELECT [ID],
	       [Name],
	       [Address],
	       [Phone],
	       [IsActive]
	FROM [dbo].[Householder]
	WHERE [IsActive] = 1
GO


