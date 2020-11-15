USE BHKRentHouse
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM Location
GO
SET IDENTITY_INSERT [dbo].[Location] ON 
INSERT [dbo].[Location] ([ID], [StreetName], [District], [City], [Region], [IsActive]) VALUES (0, N'Nguyễn Văn Cừ', N'Q5', N'HCM', N'Đông Nam Bộ', 1)
INSERT [dbo].[Location] ([ID], [StreetName], [District], [City], [Region], [IsActive]) VALUES (1, N'Ngô Gia Tự', N'Q10', N'HCM', N'Đông Nam Bộ', 1)
INSERT [dbo].[Location] ([ID], [StreetName], [District], [City], [Region], [IsActive]) VALUES (2, N'Nguyễn Đình Chiểu', N'Q3', N'HCM', N'Đông Nam Bộ', 1)
INSERT [dbo].[Location] ([ID], [StreetName], [District], [City], [Region], [IsActive]) VALUES (3, N'Nguyễn Văn Linh', N'Q7', N'HCM', N'Đông Nam Bộ', 1)
INSERT [dbo].[Location] ([ID], [StreetName], [District], [City], [Region], [IsActive]) VALUES (4, N'Trường Sơn', N'Tân Bình', N'HCM', N'Đông Nam Bộ', 1)
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
DBCC CHECKIDENT('[dbo].[Location]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM BranchOffice
GO
SET IDENTITY_INSERT [dbo].[BranchOffice] ON 
INSERT [dbo].[BranchOffice] ([ID], [Name], [Phone], [Fax], [IDLocation], [IsActive]) VALUES (0, N'Q7', N'03265985456    ', N'0365986532BCF       ', 3, 1)
INSERT [dbo].[BranchOffice] ([ID], [Name], [Phone], [Fax], [IDLocation], [IsActive]) VALUES (1, N'Q10', N'03265984521    ', N'0326598542BJV       ', 1, 1)
INSERT [dbo].[BranchOffice] ([ID], [Name], [Phone], [Fax], [IDLocation], [IsActive]) VALUES (2, N'Tân Bình', N'03265985632    ', N'03265985456AWQ      ', 4, 1)
INSERT [dbo].[BranchOffice] ([ID], [Name], [Phone], [Fax], [IDLocation], [IsActive]) VALUES (3, N'Q3', N'03265985421    ', N'03265985142VCX      ', 2, 1)
INSERT [dbo].[BranchOffice] ([ID], [Name], [Phone], [Fax], [IDLocation], [IsActive]) VALUES (4, N'Q5', N'01235648975    ', N'03215645235MNB      ', 0, 1)
SET IDENTITY_INSERT [dbo].[BranchOffice] OFF
GO
DBCC CHECKIDENT('[dbo].[BranchOffice]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM Employee
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
INSERT [dbo].[Employee] ([ID], [Name], [Address], [Phone], [Gender], [Birthday], [Salary], [IDBranchOffice], [IsActive]) VALUES (0, N'Vũ Việt A', N'Đồng Nai', N'0231564895     ', 0, CAST(N'1997-05-05 00:00:00.000' AS DateTime), 100, 0, 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [Phone], [Gender], [Birthday], [Salary], [IDBranchOffice], [IsActive]) VALUES (1, N'Nguyễn Thiện B', N'Q4', N'0312659452     ', 0, CAST(N'1997-07-02 00:00:00.000' AS DateTime), 100, 1, 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [Phone], [Gender], [Birthday], [Salary], [IDBranchOffice], [IsActive]) VALUES (2, N'Ngô Thừa C', N'Q2', N'02365984523    ', 1, CAST(N'1998-03-05 00:00:00.000' AS DateTime), 100, 0, 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [Phone], [Gender], [Birthday], [Salary], [IDBranchOffice], [IsActive]) VALUES (3, N'Đinh Trường D', N'Q1', N'0326598452     ', 1, CAST(N'1898-10-05 00:00:00.000' AS DateTime), 100, 0, 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [Phone], [Gender], [Birthday], [Salary], [IDBranchOffice], [IsActive]) VALUES (4, N'Tạ Quang E', N'Q8', N'0326541985     ', 1, CAST(N'2019-10-05 00:00:00.000' AS DateTime), 100, 1, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
DBCC CHECKIDENT('[dbo].[Employee]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM Customer
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Description], [AbilityRent], [IDBranchOffice], [IsActive]) VALUES (0, N'Hồ Tuấn A', N'03265985232    ', N'Q1', N'View đẹp', 1, 0, 1)
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Description], [AbilityRent], [IDBranchOffice], [IsActive]) VALUES (1, N'Văn Vĩ B', N'02315648562    ', N'Q7', N'View sông', 1, 1, 1)
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Description], [AbilityRent], [IDBranchOffice], [IsActive]) VALUES (2, N'Nguyễn Văn C', N'03265985623    ', N'Q3', N'Thoáng', 1, 0, 1)
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Description], [AbilityRent], [IDBranchOffice], [IsActive]) VALUES (3, N'Cao Võ D', N'03216548562    ', N'Q2', N'Mặt phố', 1, 0, 1)
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Description], [AbilityRent], [IDBranchOffice], [IsActive]) VALUES (4, N'Hà Ngô E', N'02316598452    ', N'Q8', N'Đường lớn', 1, 3, 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
DBCC CHECKIDENT('[dbo].[Customer]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM HouseType
GO
SET IDENTITY_INSERT [dbo].[HouseType] ON 
INSERT [dbo].[HouseType] ([ID], [Name], [Description], [IsActive]) VALUES (0, N'L1.1', N'Cao cấp', 1)
INSERT [dbo].[HouseType] ([ID], [Name], [Description], [IsActive]) VALUES (1, N'L1.2', N'Tốt', 1)
INSERT [dbo].[HouseType] ([ID], [Name], [Description], [IsActive]) VALUES (2, N'L2.1', N'Khá Tốt', 1)
INSERT [dbo].[HouseType] ([ID], [Name], [Description], [IsActive]) VALUES (3, N'L2.2', N'Khá', 1)
INSERT [dbo].[HouseType] ([ID], [Name], [Description], [IsActive]) VALUES (4, N'L3.1', N'Trung Bình Khá', 1)
INSERT [dbo].[HouseType] ([ID], [Name], [Description], [IsActive]) VALUES (5, N'L3.2', N'Trung Bình', 1)
SET IDENTITY_INSERT [dbo].[HouseType] OFF
GO
DBCC CHECKIDENT('[dbo].[HouseType]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM Householder
GO
SET IDENTITY_INSERT [dbo].[Householder] ON 
INSERT [dbo].[Householder] ([ID], [Name], [Address], [Phone], [IsActive]) VALUES (0, N'Võ Văn A', N'Q4', N'03265415987    ', 1)
INSERT [dbo].[Householder] ([ID], [Name], [Address], [Phone], [IsActive]) VALUES (1, N'Nguyễn Phong B', N'Q8', N'03265984521    ', 1)
INSERT [dbo].[Householder] ([ID], [Name], [Address], [Phone], [IsActive]) VALUES (2, N'Trình Định C', N'Q9', N'03265985423    ', 1)
INSERT [dbo].[Householder] ([ID], [Name], [Address], [Phone], [IsActive]) VALUES (3, N'Tô Vũ D', N'Q12', N'03265945231    ', 1)
INSERT [dbo].[Householder] ([ID], [Name], [Address], [Phone], [IsActive]) VALUES (4, N'Ngô Thừa E', N'Tân Phú', N'0326954125     ', 1)
SET IDENTITY_INSERT [dbo].[Householder] OFF
GO
DBCC CHECKIDENT('[dbo].[Householder]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM House
GO
SET IDENTITY_INSERT [dbo].[House] ON 
INSERT [dbo].[House] ([ID], [RoomNumber], [FeeMonth], [IDHouseholder], [IDEmployee], [IDHouseType], [IDLocation], [IsActive]) VALUES (0, 5, 500, 1, 0, 1, 0, 1)
INSERT [dbo].[House] ([ID], [RoomNumber], [FeeMonth], [IDHouseholder], [IDEmployee], [IDHouseType], [IDLocation], [IsActive]) VALUES (1, 3, 600, 2, 1, 2, 2, 1)
INSERT [dbo].[House] ([ID], [RoomNumber], [FeeMonth], [IDHouseholder], [IDEmployee], [IDHouseType], [IDLocation], [IsActive]) VALUES (2, 3, 1000, 4, 4, 0, 4, 1)
INSERT [dbo].[House] ([ID], [RoomNumber], [FeeMonth], [IDHouseholder], [IDEmployee], [IDHouseType], [IDLocation], [IsActive]) VALUES (3, 2, 600, 2, 2, 3, 2, 1)
INSERT [dbo].[House] ([ID], [RoomNumber], [FeeMonth], [IDHouseholder], [IDEmployee], [IDHouseType], [IDLocation], [IsActive]) VALUES (4, 6, 1500, 3, 1, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[House] OFF
GO
DBCC CHECKIDENT('[dbo].[House]', RESEED, 5)
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
DELETE FROM Users
GO
INSERT [dbo].[Users] ([UserName], [Password], [IsAdmin], [IsActive]) VALUES (N'0', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1)
INSERT [dbo].[Users] ([UserName], [Password], [IsAdmin], [IsActive]) VALUES (N'1', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1)
INSERT [dbo].[Users] ([UserName], [Password], [IsAdmin], [IsActive]) VALUES (N'2', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1)
INSERT [dbo].[Users] ([UserName], [Password], [IsAdmin], [IsActive]) VALUES (N'3', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1)
INSERT [dbo].[Users] ([UserName], [Password], [IsAdmin], [IsActive]) VALUES (N'4', N'c4ca4238a0b923820dcc509a6f75849b', 0, 1)
INSERT [dbo].[Users] ([UserName], [Password], [IsAdmin], [IsActive]) VALUES (N'admin', N'c4ca4238a0b923820dcc509a6f75849b', 1, 1)
--=========================================================================================================================================================
--=========================================================================================================================================================
EXEC sp_msforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"
GO	
