USE BHKRentHouse
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE name = 'trg_Employee_Update' AND OBJECTPROPERTY(id, 'IsTrigger') = 1)
DROP TRIGGER [dbo].[trg_Employee_Update]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Employee_Update]
ON [dbo].[Employee]
FOR UPDATE
AS
    IF((Select Salary From inserted ) < 0)
    BEGIN
		WAITFOR DELAY '0:0:5'	-- Test Dirty read
		ROLLBACK TRAN
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadDataCombobox]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadDataCombobox]
GO
CREATE PROCEDURE [dbo].[LoadDataCombobox]
	@pType varchar(20) = ''
AS
	IF(@pType = 'BRA')
	BEGIN
		SELECT BRO.[ID] AS [Value],
		       BRO.[Name] AS [Display]
		FROM BranchOffice BRO
		WHERE BRO.[IsActive] = 1
	END
	--ELSE IF(@pType = 'CON')
	--BEGIN
	--	SELECT BRO.[ID] AS [Value],
	--	       BRO.[Name] AS [Display]
	--	FROM BranchOffice BRO
	--	WHERE BRO.[IsActive] = 1
	--END
	ELSE IF(@pType = 'CUS')
	BEGIN
		SELECT CUS.[ID] AS [Value],
		       CUS.[Name] AS [Display]
		FROM Customer CUS
		WHERE CUS.[IsActive] = 1
	END
	ELSE IF(@pType = 'EMP')
	BEGIN
		SELECT EMP.[ID] AS [Value],
		       EMP.[Name] AS [Display]
		FROM Employee EMP
		WHERE EMP.[IsActive] = 1
	END
	ELSE IF(@pType = 'HOU')
	BEGIN
		SELECT HOU.[ID] AS [Value],
		       CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS [Display]
		FROM House HOU
		WHERE HOU.[IsActive] = 1
	END
	ELSE IF(@pType = 'HOH')
	BEGIN
		SELECT HOH.[ID] AS [Value],
		       HOH.[Name] AS [Display]
		FROM Householder HOH
		WHERE HOH.[IsActive] = 1
	END
	ELSE IF(@pType = 'HOT')
	BEGIN
		SELECT HOT.[ID] AS [Value],
		       HOT.[Name] AS [Display]
		FROM HouseType HOT
		WHERE HOT.[IsActive] = 1
	END
	ELSE IF(@pType = 'LOC')
	BEGIN
		SELECT LOC.[ID] AS [Value],
		       LOC.[StreetName] + ', ' + LOC.[District] + ', ' + LOC.[City] + ', ' + LOC.[Region] AS [Display]
		FROM Location LOC
		WHERE LOC.[IsActive] = 1
	END
	ELSE IF(@pType = 'URS')
	BEGIN
		SELECT URS.[UserName] AS [Value],
		       URS.[UserName] AS [Display]
		FROM Users URS
		WHERE URS.[IsActive] = 1
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_Login]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[Users_Login]
	@pUserName nvarchar(20) = NULL,
	@pPassword varchar(50) = NULL	
AS
	DECLARE @sResult varchar(20)
	DECLARE @sUserID varchar(15)
	DECLARE @sActive char(1)
	DECLARE @sErrorDesc nvarchar(1000)

	IF EXISTS(SELECT TOP 1 1 FROM Users WHERE UserName = @pUserName AND [Password] = @pPassword AND IsActive = 1)
	BEGIN
		SELECT	1 AS Result,
				USR.UserName,
				USR.IsActive
		FROM Users USR
		WHERE UserName = @pUserName 
	END
	ELSE
	BEGIN
		SELECT	0 AS Result,
				'' AS UserName,
				'' AS IsActive	
	END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Users_InsUpd]
	@pUserName nvarchar(255) = NULL,
	@pPassword varchar(255) = NULL,
	@pIsAdmin bit = NULL,
	@pIsActive bit = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''
	
	IF NOT EXISTS (SELECT TOP 1 1  FROM [Users] WHERE [UserName] = @pUserName)
	BEGIN
		INSERT INTO [dbo].[Users]([UserName],
								  [Password],
								  [IsAdmin], 
								  [IsActive])
		 VALUES(@pUserName,
		        @pPassword,
		        @pIsAdmin,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Users]
		SET [Password] = @pPassword,
			[IsAdmin] =  @pIsAdmin
		WHERE [UserName] = @pUserName
	END

COMMIT TRANSACTION
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm người dùng thất bại!'
	SELECT -1 AS Result, @vMessage ErrorDesc
	RETURN -1
END
GO
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
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_ChangePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_ChangePassword]
GO
CREATE PROCEDURE [dbo].[Users_ChangePassword]
	@pUserName nvarchar(255) = '',
	@pOldPass varchar(255) = '',
	@pNewPass varchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF EXISTS (SELECT TOP 1 1  FROM [Users] WHERE [UserName] = @pUserName AND [Password] = @pOldPass)
	BEGIN
		UPDATE [dbo].[Users]
		SET [Password] = @pNewPass
		WHERE [UserName] = @pUserName
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		SET @vMessage = N'Tên đăng nhập, Mật khẩu cũ không hợp lệ!'
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	IF(@vMessage != '')
	BEGIN
			SET @vMessage = N'Đổi mật khẩu thất bại!'
	END
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_Search]
GO
CREATE PROCEDURE [dbo].[Preview_Search]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pPreviewDate varchar(10) = ''
AS
	SELECT PRV.IDHouse,
		   CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS CodeHouse,
		   HOU.RoomNumber,
		   HOU.FeeMonth,
		   PRV.IDCustomer,
		   CUS.Name AS NameCustomer,
		   CONVERT(varchar(10), PRV.PreviewDate, 103) AS PreviewDate,
		   PRV.Comment
	FROM Preview PRV
		 LEFT JOIN House HOU ON HOU.ID = PRV.IDHouse
		 LEFT JOIN Customer CUS ON CUS.ID = PRV.IDCustomer
	WHERE 1 = 1
		  AND (PRV.IDCustomer = @pIDCustomer OR @pIDCustomer IS NULL OR @pIDCustomer = -1)
	      AND (PRV.IDHouse = @pIDHouse OR @pIDHouse IS NULL OR @pIDHouse = -1)
		  AND (CONVERT(varchar(10), PRV.PreviewDate, 103) = @pPreviewDate OR @pPreviewDate IS NULL OR @pPreviewDate = CONVERT(varchar(10), getdate(), 103))
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Preview_InsUpd]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pComment nvarchar(max) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF NOT EXISTS (SELECT TOP 1 1 FROM Preview WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND CONVERT(date, PreviewDate) = CONVERT(date, GETDATE()))
	BEGIN
		INSERT INTO [dbo].[Preview]([IDCustomer],
									[IDHouse],
									[PreviewDate],
									[Comment])
		 VALUES(@pIDCustomer,
		        @pIDHouse,
		        CONVERT(date, GETDATE()),
		        @pComment)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Preview]
		SET [Comment] = @pComment
		WHERE [IDCustomer] = @pIDCustomer AND [IDHouse] = @pIDHouse AND CONVERT(date, [PreviewDate]) = CONVERT(date, GETDATE())
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Cập nhật giao dịch xem nhà thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_GetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Preview_GetAll]
AS
	SELECT PRV.IDHouse,
		   CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS CodeHouse,
		   HOU.RoomNumber,
		   HOU.FeeMonth,
		   PRV.IDCustomer,
		   CUS.Name AS NameCustomer,
		   CONVERT(varchar(10), PRV.PreviewDate, 103) AS PreviewDate,
		   PRV.Comment
	FROM Preview PRV
		 LEFT JOIN House HOU ON HOU.ID = PRV.IDHouse
		 LEFT JOIN Customer CUS ON CUS.ID = PRV.IDCustomer
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Preview_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Preview_Del]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pPreviewDate varchar(10) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM Preview WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND (CONVERT(varchar(10), PreviewDate, 103) = @pPreviewDate))
	BEGIN
		DELETE FROM Preview WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND (CONVERT(varchar(10), PreviewDate, 103) = @pPreviewDate)
	END
	ELSE
	BEGIN
		SET @vMessage = N'Không tồn tại!'
		GOTO ABORT
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
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Location_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Location_InsUpd]
	@pID bigint = -1,
	@pStreetName nvarchar(max) = '',
	@pDistrict nvarchar(255) = '',
	@pCity nvarchar(255) = '',
	@pRegion nvarchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Location]( [StreetName],
									  [District],
									  [City],
									  [Region],
									  [IsActive])
		 VALUES(@pStreetName,
		        @pDistrict,
		        @pCity,
		        @pRegion,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Location]
		SET [StreetName] = @pStreetName, 
			[District] = @pDistrict,
			[City] = @pCity,
			[Region] = @pRegion
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm địa điểm thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
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
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HouseType_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HouseType_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HouseType_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = NULL,
	@pDescription nvarchar(max) = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[HouseType]( [Name],
									   [Description],
									   [IsActive])
		 VALUES(@pName,
		        @pDescription,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[HouseType]
		SET [Name] = @pName,
			[Description] = @pDescription
		WHERE [ID] = @pID
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm địa điểm thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
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
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Householder_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Householder_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Householder_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pAddress nvarchar(max) = '',
	@pPhone varchar(15) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Householder]([Name],
										[Address],
										[Phone],
										[IsActive])
		 VALUES(@pName,
		        @pAddress,
		        @pPhone,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Householder]
		SET [Name] = @pName,
			[Address] = @pAddress,
			[Phone] = @pPhone
		WHERE [ID] = @pID
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm chủ nhà thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
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
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[House_Search]
	@pID bigint = '',
	@pRoomNumber int = 1,
	@pFeeMonth bigint = 1,
	@pIDHouseholder bigint = NULL,
	@pIDEmployee bigint = NULL,
	@pIDHouseType bigint = NULL,
	@pIDLocation bigint = NULL
AS
	SELECT HOU.[ID],
	       HOU.[RoomNumber],
	       HOU.[FeeMonth],
	       HOU.[IDHouseholder],
		   HHD.[Name] AS HouseholderName,
	       HOU.[IDEmployee],
		   EMP.[Name] AS EmployeeName,
	       HOU.[IDHouseType],
		   HUT.[Name] AS HouseTypeName,
	       HOU.[IDLocation],
		   LCT.[StreetName] + ', ' + LCT.[District] + ', ' + LCT.[City] AS [Address],
		   LCT.[Region],
	       HOU.[IsActive]
	FROM House HOU
		 LEFT JOIN Employee EMP ON EMP.ID = HOU.IDEmployee
		 LEFT JOIN HouseType HUT ON HUT.ID = HOU.IDHouseType
		 LEFT JOIN Householder HHD ON HHD.ID = HOU.IDHouseholder
		 LEFT JOIN Location LCT ON LCT.ID = HOU.IDLocation
	WHERE HOU.[IsActive] = 1
		  AND (HOU.[ID] = @pID OR @pID IS NULL OR @pID = -1)
		  AND (HOU.[RoomNumber] = @pRoomNumber OR @pRoomNumber IS NULL OR @pRoomNumber = -1)
		  AND (HOU.[FeeMonth] = @pFeeMonth OR @pFeeMonth IS NULL OR @pFeeMonth = -1)
		  AND (HOU.[IDHouseholder] = @pIDHouseholder OR @pIDHouseholder IS NULL OR @pIDHouseholder = -1)
		  AND (HOU.[IDEmployee] = @pIDEmployee OR @pIDEmployee IS NULL OR @pIDEmployee = -1)
		  AND (HOU.[IDHouseType] = @pIDHouseType OR @pIDHouseType IS NULL OR @pIDHouseType = -1)
		  AND (HOU.[IDLocation] = @pIDLocation OR @pIDLocation IS NULL OR @pIDLocation = -1)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[House_InsUpd]
	@pID bigint = -1,
	@pRoomNumber int = 1,
	@pFeeMonth bigint = 1,
	@pIDHouseholder bigint = NULL,
	@pIDEmployee bigint = NULL,
	@pIDHouseType bigint = NULL,
	@pIDLocation bigint = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[House](	[RoomNumber],
									[FeeMonth],
									[IDHouseholder],
									[IDEmployee],
									[IDHouseType],
									[IDLocation],
									[IsActive])
		 VALUES(@pRoomNumber,
		        @pFeeMonth,
		        @pIDHouseholder,
		        @pIDEmployee,
				@pIDHouseType,
				@pIDLocation,
		        1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[House]
		SET [RoomNumber] = @pRoomNumber,
			[FeeMonth] = @pFeeMonth,
			[IDHouseholder] = @pIDHouseholder,
			[IDEmployee] = @pIDEmployee,
			[IDHouseType] = @pIDHouseType,
			[IDLocation] = @pIDLocation
		WHERE [ID] = @pID
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm nhà thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_GetAll]
GO
CREATE PROCEDURE [dbo].[House_GetAll]
AS
	SELECT HOU.[ID],
	       HOU.[RoomNumber],
	       HOU.[FeeMonth],
	       HOU.[IDHouseholder],
		   HHD.[Name] AS HouseholderName,
	       HOU.[IDEmployee],
		   EMP.[Name] AS EmployeeName,
	       HOU.[IDHouseType],
		   HUT.[Name] AS HouseTypeName,
	       HOU.[IDLocation],
		   LCT.[StreetName] + ', ' + LCT.[District] + ', ' + LCT.[City] AS [Address],
		   LCT.[Region],
	       HOU.[IsActive]
	FROM House HOU
		 LEFT JOIN Employee EMP ON EMP.ID = HOU.IDEmployee
		 LEFT JOIN HouseType HUT ON HUT.ID = HOU.IDHouseType
		 LEFT JOIN Householder HHD ON HHD.ID = HOU.IDHouseholder
		 LEFT JOIN Location LCT ON LCT.ID = HOU.IDLocation
	WHERE HOU.[IsActive] = 1
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[House_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_Search]
	@pID bigint = '',	
	@pName varchar(255) = '',
	@pAddress varchar(255) = '',
	@pPhone varchar(15) = '',
	@pGender bit = -1,
	@pBirthday varchar(10) = '',
	@pSalary bigint = -1,
	@pIDBranchOffice bigint = NULL
AS
	SELECT	EMP.[ID],
			EMP.[Name],
			EMP.[Address],
			EMP.[Phone],
			EMP.[Gender],
			CONVERT(varchar(10), EMP.[Birthday], 103) AS Birthday,
			EMP.[Salary],
			EMP.[IDBranchOffice],
			BRO.[Name] AS BranchOfficeName,
			EMP.[IsActive]
	FROM Employee EMP
		 LEFT JOIN BranchOffice BRO ON BRO.ID = EMP.IDBranchOffice
	WHERE EMP.[IsActive] = 1
		  AND (EMP.[ID] = @pID OR @pID IS NULL OR @pID = -1)
		  AND (EMP.[Name] LIKE '%' + @pName + '%' OR @pName IS NULL OR @pName = '')
		  AND (EMP.[Address] LIKE '%' + @pAddress + '%' OR @pAddress IS NULL OR @pAddress = '')
		  AND (EMP.[Phone] LIKE '%' + @pPhone + '%' OR @pPhone IS NULL OR @pPhone = '')
		  AND (EMP.[Gender] = @pGender OR @pGender IS NULL OR @pID = -1)
		  AND (CONVERT(varchar(10), EMP.[Birthday], 103) = @pBirthday OR @pBirthday IS NULL OR @pBirthday = CONVERT(varchar(10), getdate(), 103))
		  AND (EMP.[Salary] = @pSalary OR @pSalary IS NULL OR @pSalary = -1)
		  AND (EMP.[IDBranchOffice] = @pIDBranchOffice OR @pIDBranchOffice IS NULL OR @pIDBranchOffice = -1)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_InsUpd]
	@pID bigint = -1,	
	@pName nvarchar(255) = '',
	@pAddress nvarchar(255) = '',
	@pPhone varchar(15) = '',
	@pGender bit = 1,
	@pBirthday datetime = NULL,
	@pSalary bigint = 0,
	@pIDBranchOffice bigint = NULL,
	@pPassword varchar(255) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Employee]( [Name],
									  [Address],
									  [Phone],
									  [Gender],
									  [Birthday],
									  [Salary],
									  [IDBranchOffice],
									  [IsActive])
		 VALUES(@pName,
		        @pAddress,
		        @pPhone,
		        @pGender,
				CONVERT(date, @pBirthday),
				@pSalary,
				@pIDBranchOffice,
		        1)
		IF @@Error <> 0 GOTO ABORT

		INSERT INTO [dbo].[Users]([UserName],
								  [Password],
								  [IsAdmin], 
								  [IsActive])
		VALUES(IDENT_CURRENT('Employee'),
		        @pPassword,
		        0,
		        1)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Employee]
		SET [Name] = @pName,
			[Address] = @pAddress,
			[Phone] = @pPhone,
			[Gender] = @pGender,
			[Birthday] = @pBirthday,
			[Salary] = @pSalary,
			[IDBranchOffice] = @pIDBranchOffice
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm nhân viên thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Employee_GetAll]
GO
CREATE PROCEDURE [dbo].[Employee_GetAll]
AS
	SELECT	EMP.[ID],
			EMP.[Name],
			EMP.[Address],
			EMP.[Phone],
			EMP.[Gender],
			CONVERT(varchar(10), EMP.[Birthday], 103) AS Birthday,
			EMP.[Salary],
			EMP.[IDBranchOffice],
			BRO.[Name] AS BranchOfficeName,
			EMP.[IsActive]
	FROM Employee EMP
		 LEFT JOIN BranchOffice BRO ON BRO.ID = EMP.IDBranchOffice
	WHERE EMP.[IsActive] = 1
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_Search]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customer_Search]
	@pID bigint = '',
	@pName varchar(255) = '',
	@pPhone varchar(15) = '',
	@pAddress varchar(max) = '',
	@pDescription nvarchar(max) = '',
	@pAbilityRent bit = -1,
	@pIDBranchOffice bigint = NULL
AS
	SELECT CUS.[ID],
	       CUS.[Name],
	       CUS.[Phone],
	       CUS.[Address],
	       CUS.[Description],
	       CUS.[AbilityRent],
	       CUS.[IDBranchOffice],
		   BRO.[Name] AS BranchOfficeName,
	       CUS.[IsActive]
	FROM Customer CUS
		 LEFT JOIN BranchOffice BRO ON BRO.ID = CUS.IDBranchOffice
	WHERE CUS.[IsActive] = 1
		 AND (CUS.[ID] = @pID OR @pID IS NULL OR @pID = -1)
		 AND (CUS.[Name] LIKE '%' + @pName + '%' OR @pName IS NULL OR @pName = '')
		 AND (CUS.[Phone] LIKE '%' + @pPhone + '%' OR @pPhone IS NULL OR @pPhone = '')
		 AND (CUS.[Address] LIKE '%' + @pAddress + '%' OR @pAddress IS NULL OR @pAddress = '')
		 AND (CUS.[Description] LIKE '%' + @pDescription + '%' OR @pDescription IS NULL OR @pDescription = '')
		 AND (CUS.[AbilityRent] = @pAbilityRent OR @pAbilityRent IS NULL OR @pAbilityRent = -1)
		 AND (CUS.[IDBranchOffice] = @pIDBranchOffice OR @pIDBranchOffice IS NULL OR @pIDBranchOffice = -1)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customer_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pPhone char(15) = '',
	@pAddress nvarchar(max) = '',
	@pDescription nvarchar(max) = '',
	@pAbilityRent bit = 1,
	@pIDBranchOffice bigint = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Customer]( [Name],
									  [Phone],
									  [Address],
									  [Description],
									  [AbilityRent],
									  [IDBranchOffice],
									  [IsActive])
		 VALUES(@pName,
		        @pPhone,
		        @pAddress,
		        @pDescription,
				@pAbilityRent,
				@pIDBranchOffice,
		        1)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Customer]
		SET [Name] = @pName,
			[Phone] = @pPhone,
			[Address] = @pAddress,
			[Description] = @pDescription,
			[AbilityRent] = @pAbilityRent,
			[IDBranchOffice] = @pIDBranchOffice
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm khách hàng thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_GetAll]
GO
CREATE PROCEDURE [dbo].[Customer_GetAll]
AS
	SELECT CUS.[ID],
	       CUS.[Name],
	       CUS.[Phone],
	       CUS.[Address],
	       CUS.[Description],
	       CUS.[AbilityRent],
	       CUS.[IDBranchOffice],
		   BRO.[Name] AS BranchOfficeName,
	       CUS.[IsActive]
	FROM Customer CUS
		 LEFT JOIN BranchOffice BRO ON BRO.ID = CUS.IDBranchOffice
	WHERE CUS.[IsActive] = 1
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_Search]
GO
CREATE PROCEDURE [dbo].[Contract_Search]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pIDEmployee bigint = -1,
	@pContractDate varchar(10) = '',
	@pStatus char(1) = ''
AS
	SELECT CON.IDHouse,
		   CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS CodeHouse,
		   HOU.RoomNumber,
		   HOU.FeeMonth,
		   CON.IDCustomer,
		   CUS.Name AS NameCustomer,
		   CONVERT(varchar(10), CON.ContractDate, 103) AS ContractDate,
		   CON.IDEmployee,
		   EMP.Name AS NameEmployee
	FROM [Contract] CON
		 LEFT JOIN House HOU ON HOU.ID = CON.IDHouse
		 LEFT JOIN Customer CUS ON CUS.ID = CON.IDCustomer
		 LEFT JOIN Employee EMP ON EMP.ID = CON.IDEmployee
	WHERE 1 = 1
		  AND (CON.IDCustomer = @pIDCustomer OR @pIDCustomer IS NULL OR @pIDCustomer = -1)
	      AND (CON.IDHouse = @pIDHouse OR @pIDHouse IS NULL OR @pIDHouse = -1)
		  AND (CON.IDEmployee = @pIDEmployee OR @pIDEmployee IS NULL OR @pIDEmployee = -1)
		  AND (CONVERT(varchar(10), CON.[ContractDate], 103) = @pContractDate OR @pContractDate IS NULL OR @pContractDate = CONVERT(varchar(10), getdate(), 103))
		  AND (CON.[Status] = @pStatus OR @pStatus IS NULL OR @pStatus = '')
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Contract_InsUpd]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pIDEmployee bigint = -1,
	@pStatus char(1) = ''
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF NOT EXISTS (SELECT TOP 1 1 FROM [Contract] WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND IDEmployee =  @pIDEmployee)
	BEGIN
		INSERT INTO [dbo].[Contract]([IDCustomer],
									 [IDHouse],
									 [IDEmployee],
									 [ContractDate],
									 [Status])
		 VALUES(@pIDCustomer,
		        @pIDHouse,
				@pIDEmployee,
		        GETDATE(),
		        @pStatus)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Contract]
		SET [Status] = @pStatus
		WHERE [IDCustomer] = @pIDCustomer AND [IDHouse] = @pIDHouse AND [IDEmployee] = @pIDEmployee
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Cập nhật hợp đồng thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_GetAll]
GO
CREATE PROCEDURE [dbo].[Contract_GetAll]
AS
	SELECT CON.IDHouse,
		   CAST(HOU.[ID] AS varchar(max)) + '-' + CAST(HOU.[IDHouseholder] AS varchar(max)) + '-' + CAST(HOU.[IDHouseType] AS varchar(max)) + '-' + CAST(HOU.[IDLocation] AS varchar(max)) + '-' + CAST(HOU.[IDEmployee] AS varchar(max)) AS CodeHouse,
		   HOU.RoomNumber,
		   HOU.FeeMonth,
		   CON.IDCustomer,
		   CUS.Name AS NameCustomer,
		   CONVERT(varchar(10), CON.ContractDate, 103) AS ContractDate,
		   CON.IDEmployee,
		   EMP.Name AS NameEmployee
	FROM [Contract] CON
		 LEFT JOIN House HOU ON HOU.ID = CON.IDHouse
		 LEFT JOIN Customer CUS ON CUS.ID = CON.IDCustomer
		 LEFT JOIN Employee EMP ON EMP.ID = CON.IDEmployee
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract_Del]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contract_Del]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Contract_Del]
	@pIDCustomer bigint = -1,
	@pIDHouse bigint = -1,
	@pIDEmployee bigint = -1
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(max)
	SET @vMessage = ''
	IF EXISTS (SELECT TOP 1 1 FROM [Contract] WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND IDEmployee =  @pIDEmployee)
	BEGIN
		DELETE FROM [Contract] WHERE IDCustomer = @pIDCustomer AND IDHouse = @pIDHouse AND IDEmployee =  @pIDEmployee
	END
	ELSE
	BEGIN
		SET @vMessage = N'Không tồn tại!'
		GOTO ABORT
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
--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchOffice_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BranchOffice_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BranchOffice_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pPhone varchar(15) = '',
	@pFax varchar(20) = '',
	@pIDLocation bigint
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[BranchOffice]( [Name],
										  [Phone],
										  [Fax],
										  [IDLocation],
										  [IsActive])
		 VALUES(@pName,
		       @pPhone,
		       @pFax,
		       @pIDLocation,
		       1)
	IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[BranchOffice]
		SET [Name] = @pName,
			[Phone] = @pPhone,
			[Fax] = @pFax,
			[IDLocation] = @pIDLocation
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm chi nhánh thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
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