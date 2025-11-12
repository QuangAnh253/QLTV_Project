-- =============================================
-- Script: Insert dữ liệu mẫu
-- =============================================
USE QLTV_DB;
GO

-- Thêm Users
INSERT INTO Users (Username, Password, FullName, Role) VALUES
('admin', '123456', N'Quản Trị Viên', 'Admin'),
('staff1', '123456', N'Lê Quang Anh', 'Staff'),
('staff2', '123456', N'Vũ Thị Thùy Trang', 'Staff');
GO

-- Thêm Categories
INSERT INTO Categories (CategoryName, Description) VALUES
(N'Công nghệ thông tin', N'Sách về lập trình, AI, mạng máy tính'),
(N'Văn học', N'Tiểu thuyết, thơ, truyện ngắn'),
(N'Khoa học', N'Toán, Lý, Hóa, Sinh'),
(N'Kinh tế', N'Quản trị, Marketing, Tài chính'),
(N'Kỹ năng mềm', N'Giao tiếp, lãnh đạo, quản lý thời gian');
GO

-- Thêm Books
INSERT INTO Books (Title, Author, Publisher, PublishYear, CategoryID, Quantity, Available, Price) VALUES
(N'Lập trình C# cơ bản', N'Nguyễn Văn An', N'NXB Giáo Dục', 2023, 1, 10, 10, 150000),
(N'SQL Server từ A-Z', N'Trần Thị Mai', N'NXB Thanh Niên', 2022, 1, 5, 5, 200000),
(N'Trí tuệ nhân tạo', N'Lê Văn Tùng', N'NXB KHKT', 2024, 1, 8, 8, 350000),
(N'Số đỏ', N'Vũ Trọng Phụng', N'NXB Văn Học', 1936, 2, 15, 13, 80000),
(N'Tắt đèn', N'Ngô Tất Tố', N'NXB Văn Học', 1939, 2, 12, 12, 65000),
(N'Toán cao cấp tập 1', N'GS. Nguyễn Đình Trí', N'NXB Giáo Dục', 2021, 3, 20, 18, 120000),
(N'Vật lý đại cương', N'PGS. Trần Văn Bình', N'NXB ĐHQG', 2020, 3, 15, 15, 180000),
(N'Quản trị học', N'Stephen Robbins', N'NXB Tổng Hợp', 2023, 4, 10, 9, 250000),
(N'Đắc nhân tâm', N'Dale Carnegie', N'NXB Tổng Hợp', 2020, 5, 25, 20, 95000);
GO

-- Thêm Members
INSERT INTO Members (FullName, DateOfBirth, Gender, PhoneNumber, Email, Address) VALUES
(N'Lê Quang Anh', '2005-03-25', N'Nam', '0833250305', 'lequanganh253@gmail.com', N'Hà Nội'),
(N'Nguyễn Thị Hồng', '2005-09-26', N'Nữ', '0374154947', 'nguyenthihong26092005@gmail.com', N'Thái Bình'),
(N'Nguyễn Văn Lộc', '2005-09-24', N'Nam', '0567003946', 'nguyenvanloc24092005@gmail.com', N'Nghệ An'),
(N'Nguyễn Duy Thành', '2005-05-11', N'Nam', '0374223006', 'nguyendthanh11052005@gmail.com', N'Nghệ An');
GO

-- Thêm BorrowRecords (một số phiếu mượn mẫu)
INSERT INTO BorrowRecords (MemberID, BookID, BorrowDate, DueDate, UserID, Status) VALUES
(1, 4, '2025-11-01', '2025-11-15', 2, N'Đang mượn'),
(2, 9, '2025-11-05', '2025-11-19', 2, N'Đang mượn'),
(3, 6, '2025-10-20', '2025-11-03', 3, N'Quá hạn'),
(1, 1, '2025-10-25', '2025-11-08', 2, N'Đã trả');

-- Update Available count cho sách đã mượn
UPDATE Books SET Available = Available - 1 WHERE BookID IN (4, 9, 6);
GO

PRINT N'✓ Insert dữ liệu mẫu thành công!';