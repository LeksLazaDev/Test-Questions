USE [master]
GO
/****** Object:  Database [dbUserBranch]    Script Date: 11/13/2019 10:14:14 PM ******/
CREATE DATABASE [dbUserBranch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbUserBranch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbUserBranch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbUserBranch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\dbUserBranch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbUserBranch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbUserBranch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbUserBranch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbUserBranch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbUserBranch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbUserBranch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbUserBranch] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbUserBranch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbUserBranch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbUserBranch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbUserBranch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbUserBranch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbUserBranch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbUserBranch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbUserBranch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbUserBranch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbUserBranch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbUserBranch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbUserBranch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbUserBranch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbUserBranch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbUserBranch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbUserBranch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbUserBranch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbUserBranch] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbUserBranch] SET  MULTI_USER 
GO
ALTER DATABASE [dbUserBranch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbUserBranch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbUserBranch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbUserBranch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbUserBranch] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbUserBranch] SET QUERY_STORE = OFF
GO
USE [dbUserBranch]
GO
/****** Object:  Table [dbo].[tblBranch]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBranch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [text] NOT NULL,
	[AddressLine1] [text] NULL,
	[AddressLine2] [text] NULL,
	[Suburb] [text] NULL,
	[BranchCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblShift]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblShift](
	[ShiftID] [int] IDENTITY(1,1) NOT NULL,
	[ShiftDay] [text] NOT NULL,
	[ShiftTime] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ShiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [text] NOT NULL,
	[FirstName] [text] NOT NULL,
	[LastName] [text] NOT NULL,
	[BranchID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserShift]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserShift](
	[UserShiftID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ShiftID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserShiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD FOREIGN KEY([BranchID])
REFERENCES [dbo].[tblBranch] ([BranchID])
GO
ALTER TABLE [dbo].[tblUserShift]  WITH CHECK ADD FOREIGN KEY([ShiftID])
REFERENCES [dbo].[tblShift] ([ShiftID])
GO
ALTER TABLE [dbo].[tblUserShift]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[tblUser] ([UserID])
GO
/****** Object:  StoredProcedure [dbo].[prDeleteBranch]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prDeleteBranch]
	@BranchID INT
AS
BEGIN 
DELETE FROM tblBranch
WHERE BranchID=@BranchID
END
GO
/****** Object:  StoredProcedure [dbo].[prDeleteShift]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prDeleteShift]
	@ShiftID INT
AS
BEGIN 
DELETE FROM tblShift
WHERE ShiftID=@ShiftID
END
GO
/****** Object:  StoredProcedure [dbo].[prDeleteUser]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prDeleteUser]
	@UserID INT
AS
BEGIN 
DELETE FROM tblUserShift 
WHERE UserID=@UserID

DELETE FROM tblUser
WHERE UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[prEditBranch]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prEditBranch]
	@BranchID INT,
	@BranchName TEXT,
	@BranchCode INT,
	@AddressLine1 TEXT,
	@AddressLine2 TEXT,
	@Suburb TEXT
AS
BEGIN 
UPDATE tblBranch
SET BranchName=@BranchName,BranchCode=@BranchCode,AddressLine1=@AddressLine1,AddressLine2=@AddressLine2,Suburb=@Suburb
WHERE BranchID=@BranchID
END
GO
/****** Object:  StoredProcedure [dbo].[prEditShift]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prEditShift]
	@ShiftID INT,
	@ShiftDay TEXT,
	@ShiftTime TEXT
AS
BEGIN 
UPDATE tblShift
SET ShiftDay=@ShiftDay,ShiftTime=@ShiftTime
WHERE ShiftID=@ShiftID
END
GO
/****** Object:  StoredProcedure [dbo].[prEditUser]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prEditUser]
	@UserID INT,
	@Username TEXT,
	@Firstname TEXT,
	@Lastname TEXT,
	@BranchID INT

AS
BEGIN
UPDATE tblUser
SET Username=@Username,FirstName=@Firstname,LastName=@Lastname, BranchID=@BranchID
WHERE UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[prInsertBranch]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prInsertBranch]
	@BranchName TEXT,
	@BranchCode INT,
	@AddressLine1 TEXT,
	@AddressLine2 TEXT,
	@Suburb TEXT
AS
BEGIN 
INSERT INTO tblBranch(BranchName,BranchCode,AddressLine1,AddressLine2,Suburb)
VALUES(@BranchName,@BranchCode,@AddressLine1,@AddressLine2,@Suburb)
END
GO
/****** Object:  StoredProcedure [dbo].[prInsertShift]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prInsertShift]
	@ShiftDay TEXT,
	@ShiftTime TEXT
AS
BEGIN 
INSERT INTO tblShift(ShiftDay,ShiftTime)
VALUES(@ShiftDay,@ShiftTime)
END
GO
/****** Object:  StoredProcedure [dbo].[prInsertUser]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prInsertUser]
	@Username TEXT,
	@FirstName TEXT,
	@LastName TEXT,
	@BranchID INT
AS
BEGIN 
INSERT INTO tblUser(Username,FirstName,LastName,BranchID)
VALUES(@Username,@FirstName,@LastName,@BranchID)
END
GO
/****** Object:  StoredProcedure [dbo].[prViewBranches]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prViewBranches]
	
AS
BEGIN 
SELECT BranchID,BranchName,BranchCode,AddressLine1,AddressLine2,Suburb FROM tblBranch
END
GO
/****** Object:  StoredProcedure [dbo].[prViewShift]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prViewShift]
	
AS
BEGIN 
SElECT ShiftID,ShiftDay,ShiftTime FROM tblShift
END
GO
/****** Object:  StoredProcedure [dbo].[prViewUsers]    Script Date: 11/13/2019 10:14:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prViewUsers]
AS
BEGIN
SELECT U.UserID, U.Username,U.FirstName,U.LastName, B.BranchName, B.BranchCode, B.AddressLine1, B.AddressLine2, B.Suburb
FROM tblUser U INNER JOIN tblBranch B ON U.BranchID=B.BranchID
END
GO
USE [master]
GO
ALTER DATABASE [dbUserBranch] SET  READ_WRITE 
GO
