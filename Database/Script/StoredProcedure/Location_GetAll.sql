--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Location_GetAll]
GO
CREATE PROCEDURE [dbo].[Location_GetAll]
AS
SELECT [ID],
       [StreetName],
       [District],
       [City],
       [Region],
       [IsActive]
  FROM [dbo].[Location]
  WHERE [IsActive] = 1
GO


