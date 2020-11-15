--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HouseType_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HouseType_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HouseType_Search]
	@pID bigint = '',
	@pName nvarchar(255) = '',
	@pDescription nvarchar(max) = ''
AS
	SELECT [ID],
	       [Name],
	       [Description],
	       [IsActive]
	FROM [dbo].[HouseType]
	WHERE [IsActive] = 1
		  AND ([ID] = @pID OR @pID IS NULL OR @pID = -1)
		  AND ([Name] LIKE N'%' + @pName + '%' OR @pName IS NULL OR @pName = '')
		  AND ([Description] LIKE N'%' + @pDescription + '%' OR @pDescription IS NULL OR @pDescription = '')
GO