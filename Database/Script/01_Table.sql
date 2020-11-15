IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'BHKRentHouse')
BEGIN
	USE master
	DROP DATABASE BHKRentHouse
END
GO
--#########################################################################################################################################################
USE master
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'BHKRentHouse')
BEGIN
	CREATE DATABASE BHKRentHouse
END
GO
IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'BHKRentHouse')
BEGIN
	USE BHKRentHouse
END
GO
--#########################################################################################################################################################
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserName] [nvarchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[IsAdmin] [bit] NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--#########################################################################################################################################################
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Location](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[StreetName] [nvarchar](max) NULL,
	[District] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[Region] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BranchOffice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BranchOffice](
	[ID][bigint] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Phone] [char](15) NULL,
	[Fax] [char](20) NULL,
	[IDLocation] [bigint] NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_BranchOffice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BranchOffice_Location]') AND parent_object_id = OBJECT_ID(N'[dbo].[BranchOffice]'))
ALTER TABLE [dbo].[BranchOffice]  
ADD CONSTRAINT [FK_BranchOffice_Location] FOREIGN KEY([IDLocation]) REFERENCES [dbo].[Location] ([ID])
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HouseType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HouseType](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_HouseType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Householder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Householder](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [char](15) NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_Householder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
--EXEC SP_RENAME '[Householder].[Phone]', 'PhoneNumber', 'COLUMN'
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [char](15) NULL,
	[Gender] [bit] NULL,
	[Birthday] [datetime] NULL,
	[Salary] [bigint] NULL,
	[IDBranchOffice] [bigint] NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employee_BranchOffice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employee]'))
ALTER TABLE [dbo].[Employee]  
ADD CONSTRAINT [FK_Employee_BranchOffice] FOREIGN KEY([IDBranchOffice]) REFERENCES [dbo].[BranchOffice] ([ID])
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Phone] [char](15) NULL,
	[Address] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AbilityRent] [bit] NULL,
	[IDBranchOffice] [bigint] NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Customer_BranchOffice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customer]'))
ALTER TABLE [dbo].[Customer]  
ADD CONSTRAINT [FK_Customer_BranchOffice] FOREIGN KEY([IDBranchOffice]) REFERENCES [dbo].[BranchOffice] ([ID])
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[House]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[House](
	[ID] [bigint] IDENTITY(0,1) NOT NULL,
	[RoomNumber] [int] NULL,
	[FeeMonth] [bigint] NULL,
	[IDHouseholder] [bigint] NULL,
	[IDEmployee] [bigint] NULL,
	[IDHouseType] [bigint] NULL,
	[IDLocation] [bigint] NULL,
	[IsActive] [bit] NULL,
CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_House_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[House]'))
ALTER TABLE [dbo].[House]  
ADD CONSTRAINT [FK_House_Employee] FOREIGN KEY([IDEmployee]) REFERENCES [dbo].[Employee] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_House_Householder]') AND parent_object_id = OBJECT_ID(N'[dbo].[House]'))
ALTER TABLE [dbo].[House]  
ADD CONSTRAINT [FK_House_Householder] FOREIGN KEY([IDHouseholder]) REFERENCES [dbo].[Householder] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_House_HouseType]') AND parent_object_id = OBJECT_ID(N'[dbo].[House]'))
ALTER TABLE [dbo].[House]  
ADD CONSTRAINT [FK_House_HouseType] FOREIGN KEY([IDHouseType]) REFERENCES [dbo].[HouseType] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_House_Location]') AND parent_object_id = OBJECT_ID(N'[dbo].[House]'))
ALTER TABLE [dbo].[House]  
ADD CONSTRAINT [FK_House_Location] FOREIGN KEY([IDLocation]) REFERENCES [dbo].[Location] ([ID])
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Preview]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Preview](
	[IDCustomer] [bigint] NOT NULL,
	[IDHouse] [bigint] NOT NULL,
	[PreviewDate] [datetime] NOT NULL,
	[Comment] [nvarchar](max) NULL
CONSTRAINT [PK_Preview] PRIMARY KEY CLUSTERED 
(
	[IDCustomer] ASC,
	[IDHouse] ASC, 
	[PreviewDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Preview_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Preview]'))
ALTER TABLE [dbo].[Preview]  
ADD CONSTRAINT [FK_Preview_Customer] FOREIGN KEY([IDCustomer]) REFERENCES [dbo].[Customer] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Preview_House]') AND parent_object_id = OBJECT_ID(N'[dbo].[Preview]'))
ALTER TABLE [dbo].[Preview]  
ADD CONSTRAINT [FK_Preview_House] FOREIGN KEY([IDHouse]) REFERENCES [dbo].[House] ([ID])
GO
--=========================================================================================================================================================
--=========================================================================================================================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contract](
	[IDCustomer] [bigint] NOT NULL,
	[IDHouse] [bigint] NOT NULL,
	[IDEmployee] [bigint] NOT NULL,
	[ContractDate] [datetime] NULL,
	[Status] [char](1) NULL
CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[IDCustomer] ASC,
	[IDHouse] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contract_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contract]'))
ALTER TABLE [dbo].[Contract]  
ADD CONSTRAINT [FK_Contract_Customer] FOREIGN KEY([IDCustomer]) REFERENCES [dbo].[Customer] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contract_House]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contract]'))
ALTER TABLE [dbo].[Contract]  
ADD CONSTRAINT [FK_Contract_House] FOREIGN KEY([IDHouse])REFERENCES [dbo].[House] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contract_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contract]'))
ALTER TABLE [dbo].[Contract]
ADD CONSTRAINT [FK_Contract_Employee] FOREIGN KEY ([IDEmployee]) REFERENCES [dbo].[Employee] ([ID])
GO
--=========================================================================================================================================================
--=========================================================================================================================================================