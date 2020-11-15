--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchOffice_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BranchOffice_Del]
GO
CREATE PROCEDURE [dbo].[BranchOffice_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  BranchOffice WHERE ID = @pID)
	BEGIN
		UPDATE BranchOffice SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_Del]
GO
CREATE PROCEDURE [dbo].[Customer_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  Customer WHERE ID = @pID)
	BEGIN
		UPDATE Customer SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_Del]
GO
CREATE PROCEDURE [dbo].[Employee_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  Employee WHERE ID = @pID)
	BEGIN
		UPDATE Employee SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_Del]
GO
CREATE PROCEDURE [dbo].[House_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  House WHERE ID = @pID)
	BEGIN
		UPDATE House SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Householder_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Householder_Del]
GO
CREATE PROCEDURE [dbo].[Householder_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  Householder WHERE ID = @pID)
	BEGIN
		UPDATE Householder SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HouseType_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HouseType_Del]
GO
CREATE PROCEDURE [dbo].[HouseType_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  HouseType WHERE ID = @pID)
	BEGIN
		UPDATE HouseType SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Location_Del]
GO
CREATE PROCEDURE [dbo].[Location_Del]
	@pID bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM  Location WHERE ID = @pID)
	BEGIN
		UPDATE Location SET IsActive = 0 WHERE ID = @pID
	END
	ELSE
	BEGIN
		SET @vMessage = 'Không tồn tại!'
	END
	IF @@Error <> 0 GOTO ABORT 

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF (@vMessage = '')
	BEGIN
		SET @vMessage = 'Xóa thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO