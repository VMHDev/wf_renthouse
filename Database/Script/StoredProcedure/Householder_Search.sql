--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Householder_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Householder_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Householder_Search]
	@pID bigint = '',
	@pName nvarchar(255) = '',
	@pAddress nvarchar(max) = '',
	@pPhone varchar(15) = ''
AS
	SELECT [ID],
	       [Name],
	       [Address],
	       [Phone],
	       [IsActive]
	FROM [dbo].[Householder]
	WHERE [IsActive] = 1
		  AND ([ID] = @pID OR @pID IS NULL OR @pID = -1)
		  AND ([Name] LIKE N'%' + @pName + '%' OR @pName IS NULL OR @pName = '')
		  AND ([Address] LIKE N'%' + @pAddress + '%' OR @pAddress IS NULL OR @pAddress = '')
		  AND ([Phone] LIKE N'%' + @pPhone + '%' OR @pPhone IS NULL OR @pPhone = '')
GO