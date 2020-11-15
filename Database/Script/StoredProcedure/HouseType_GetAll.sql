--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HouseType_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HouseType_GetAll]
GO
CREATE PROCEDURE [dbo].[HouseType_GetAll]
AS
	SELECT [ID],
	       [Name],
	       [Description],
	       [IsActive]
	FROM [dbo].[HouseType]
	WHERE [IsActive] = 1
GO