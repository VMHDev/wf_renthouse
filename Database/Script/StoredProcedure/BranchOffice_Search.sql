--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchOffice_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BranchOffice_Search]
GO
CREATE PROCEDURE [dbo].[BranchOffice_Search]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pPhone varchar(15) = '',
	@pFax varchar(20) = '',
	@pIDLocation bigint = -1
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
		 LEFT JOIN Location LAC ON LAC.ID = BRO.IDLocation
	WHERE BRO.[IsActive] = 1
		  AND (BRO.[ID] = @pID OR @pID IS NULL OR @pID = -1)
	      AND (BRO.[Name] LIKE '%' + @pName + '%' OR @pName IS NULL OR @pName = '')
	      AND (BRO.[Phone] LIKE '%' + @pPhone + '%' OR @pPhone IS NULL OR @pPhone = '')
	      AND (BRO.[Fax] LIKE '%' + @pFax + '%' OR @pFax IS NULL OR @pFax = '')
	      AND (BRO.[IDLocation] = @pIDLocation OR @pIDLocation IS NULL OR @pIDLocation = -1)
GO

--EXEC BranchOffice_Search -1, '', '', 'A', -1
--DECLARE @pFax varchar(20)
--SET @pFax = 'A'
--PRINT @pFax
--SELECT *
--FROM BranchOffice
--WHERE Fax LIKE '%' + @pFax + '%'