-- =============================================
-- Script: Tạo Database QLTV_DB
-- Mô tả: Database quản lý thư viện
-- =============================================
-- Tạo database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QLTV_DB')

BEGIN
CREATE DATABASE QLTV_DB;
END
GO

USE QLTV_DB;
GO

-- =============================================
-- Bảng Users (Quản lý tài khoản Admin/Staff)
-- =============================================

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')

BEGIN
CREATE TABLE Users (
UserID INT PRIMARY KEY IDENTITY(1,1),
Username NVARCHAR(50) NOT NULL UNIQUE,
Password NVARCHAR(100) NOT NULL,
FullName NVARCHAR(100) NOT NULL,
Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Staff')),
CreatedDate DATETIME DEFAULT GETDATE(),
IsActive BIT DEFAULT 1
);
END
GO

-- =============================================
-- Bảng Categories (Thể loại sách)
-- =============================================

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Categories' AND xtype='U')

BEGIN
CREATE TABLE Categories (
CategoryID INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(100) NOT NULL UNIQUE,
Description NVARCHAR(500)
);
END
GO

-- =============================================
-- Bảng Books (Quản lý sách)
-- =============================================

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Books' AND xtype='U')

BEGIN
CREATE TABLE Books (
BookID INT PRIMARY KEY IDENTITY(1,1),
Title NVARCHAR(200) NOT NULL,
Author NVARCHAR(100) NOT NULL,
Publisher NVARCHAR(100),
PublishYear INT,
CategoryID INT,
Quantity INT NOT NULL DEFAULT 0,
Available INT NOT NULL DEFAULT 0,
Price DECIMAL(18,2),
Description NVARCHAR(1000),
CreatedDate DATETIME DEFAULT GETDATE(),
FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
END
GO

-- =============================================
-- Bảng Members (Quản lý độc giả)
-- =============================================

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Members' AND xtype='U')

BEGIN
CREATE TABLE Members (
MemberID INT PRIMARY KEY IDENTITY(1,1),
FullName NVARCHAR(100) NOT NULL,
DateOfBirth DATE,
Gender NVARCHAR(10) CHECK (Gender IN (N'Nam', N'Nữ', N'Khác')),
PhoneNumber NVARCHAR(15) NOT NULL,
Email NVARCHAR(100),
Address NVARCHAR(200),
RegisterDate DATETIME DEFAULT GETDATE(),
IsActive BIT DEFAULT 1
);
END
GO

-- =============================================
-- Bảng BorrowRecords (Quản lý mượn trả)
-- =============================================

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BorrowRecords' AND xtype='U')

BEGIN
CREATE TABLE BorrowRecords (
BorrowID INT PRIMARY KEY IDENTITY(1,1),
MemberID INT NOT NULL,
BookID INT NOT NULL,
BorrowDate DATETIME DEFAULT GETDATE(),
DueDate DATETIME NOT NULL, -- Ngày phải trả
ReturnDate DATETIME NULL, -- Ngày trả thực tế
Status NVARCHAR(20) NOT NULL DEFAULT N'Đang mượn'
CHECK (Status IN (N'Đang mượn', N'Đã trả', N'Quá hạn')),
Fine DECIMAL(18,2) DEFAULT 0, -- Tiền phạt
Notes NVARCHAR(500),
UserID INT NOT NULL, -- Staff tạo phiếu mượn
FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
FOREIGN KEY (BookID) REFERENCES Books(BookID),
FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
END
GO

-- =============================================
-- Index để tăng tốc truy vấn
-- =============================================

CREATE NONCLUSTERED INDEX IX_Books_CategoryID ON Books(CategoryID);
CREATE NONCLUSTERED INDEX IX_BorrowRecords_MemberID ON BorrowRecords(MemberID);
CREATE NONCLUSTERED INDEX IX_BorrowRecords_Status ON BorrowRecords(Status);
GO

PRINT N'✓ Tạo database và các bảng thành công!';