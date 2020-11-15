--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetAll]
GO
CREATE PROCEDURE [dbo].[Users_GetAll]
AS
SELECT [UserName],
       [Password],
       [IsAdmin],
       [IsActive]
  FROM [dbo].[Users]
GO