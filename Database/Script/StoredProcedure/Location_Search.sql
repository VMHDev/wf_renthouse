--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Location_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Location_Search]
	@pID bigint = '',
	@pStreetName nvarchar(max) = '',
	@pDistrict nvarchar(255) = '',
	@pCity nvarchar(255) = '',
	@pRegion nvarchar(255) = ''
AS
	SELECT [ID],
		   [StreetName],
		   [District],
		   [City],
		   [Region],
		   [IsActive]
	FROM [dbo].[Location]
	WHERE [IsActive] = 1
		 AND ([ID] = @pID OR @pID IS NULL OR @pID = -1)
		 AND ([StreetName] LIKE '%' + @pStreetName + '%' OR @pStreetName IS NULL OR @pStreetName = '')
		 AND ([District] LIKE '%' + @pDistrict + '%' OR @pDistrict IS NULL OR @pDistrict = '')
		 AND ([City] LIKE '%' + @pCity + '%' OR @pCity IS NULL OR @pCity = '')
		 AND ([Region] LIKE '%' + @pRegion + '%' OR @pRegion IS NULL OR @pRegion = '')
GO
