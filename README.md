# Hệ Thống Quản Lý Thư Viện (QLTV)

## Mô Tả Dự Án

Phần mềm Quản lý thư viện phát triển bằng C\# WinForms, được xây dựng theo kiến trúc 3 lớp (3-Layer Architecture) để đảm bảo tính module hóa và dễ bảo trì.

### Kiến trúc

  * **DAL (Data Access Layer):** Chịu trách nhiệm tương tác trực tiếp với cơ sở dữ liệu SQL Server.
  * **BLL (Business Logic Layer):** Xử lý các logic nghiệp vụ, quy tắc và tính toán của hệ thống.
  * **GUI (Graphical User Interface):** Giao diện người dùng WinForms, tương tác với BLL.

-----

## Yêu Cầu Hệ Thống

  * Visual Studio 2019 (hoặc 2022)
  * .NET Framework 4.7.2 (trở lên)
  * SQL Server 2019 (hoặc SQL Server Express)
  * Git

-----

## Hướng Dẫn Cài Đặt và Cấu Hình

Vui lòng thực hiện các bước sau để thiết lập môi trường phát triển.

### 1\. Clone Repository

Sử dụng Git để clone dự án về máy:

```bash
git clone https://github.com/QuangAnh253/QLTV_Project.git
cd QLTV_Project
```

### 2\. Setup Database

1.  Mở **SQL Server Management Studio (SSMS)**.
2.  Kết nối với SQL Server instance của bạn.
3.  Chạy script `Database/01_CreateDatabase.sql` để tạo cơ sở dữ liệu và các bảng.
4.  (Tùy chọn) Chạy script `Database/02_InsertSampleData.sql` để thêm dữ liệu mẫu.

### 3\. Cấu Hình Connection String

1.  Mở file `QLTV_GUI/App.config` trong Visual Studio.

2.  Tìm đến phần `connectionStrings`.

3.  Thay đổi giá trị `YOUR_SERVER_NAME` trong `connectionString` thành tên SQL Server của bạn (ví dụ: `.\SQLEXPRESS` hoặc `DESKTOP-ABC\SQLEXPRESS`).

    ```xml
    <connectionStrings>
      <add name="QLTV_DB" 
           connectionString="Server=YOUR_SERVER_NAME;Database=QLTV_DB;Integrated Security=True;" 
           providerName="System.Data.SqlClient" />
    </connectionStrings>
    ```

### 4\. Cấu Hình Project References

Đảm bảo các project trong solution tham chiếu đúng:

  * **QLTV\_DAL:**
      * Assemblies: `System.Configuration`, `System.Data`
  * **QLTV\_BLL:**
      * Projects: `QLTV_DAL`
  * **QLTV\_GUI:**
      * Projects: `QLTV_BLL`, `QLTV_DAL`
      * Assemblies: `System.Configuration`

### 5\. Build và Chạy Thử

1.  Trong Solution Explorer, click chuột phải vào project `QLTV_GUI` và chọn **Set as StartUp Project**.
2.  Build solution (Phím tắt: **Ctrl + Shift + B**).
3.  Nếu không có lỗi, chạy dự án (Phím tắt: **F5**). Nếu ứng dụng khởi động và không báo lỗi kết nối, quá trình cài đặt đã thành công.

-----

## Quy Trình Làm Việc (Git Workflow)

Chúng ta sử dụng mô hình Pull Request để quản lý code. Nhánh `main` được bảo vệ và yêu cầu review trước khi merge.

### Bước 1: Bắt Đầu Task Mới

Luôn bắt đầu từ nhánh `main` đã được cập nhật.

```bash
# Chuyển về nhánh main
git checkout main

# Lấy code mới nhất
git pull origin main
```

Tạo nhánh mới cho nhiệm vụ của bạn theo cấu trúc: `[ten-thanh-vien]/[mo-ta-ngan-task]`.

**Prefix nhánh:**

| Thành viên | Prefix nhánh |
| :--- | :--- |
| Nguyễn Duy Thành | `duythanh` |
| Vũ Thị Thùy Trang | `thuytrang` |
| Nguyễn Minh Lộc | `vanloc` |
| Nguyễn Thị Hồng | `thihong` |
| Lê Quang Anh | `quanganh` |

**Ví dụ:**

```bash
# Duy Thành làm module Sách
git checkout -b duythanh/feature-module-sach
```

### Bước 2: Code và Commit

Làm việc trên nhánh mới của bạn và commit các thay đổi thường xuyên với message rõ ràng.

```bash
# Thêm các file đã thay đổi
git add .

# Commit với message
git commit -m "Feat: Hoan thien chuc nang BookDAO"
```

### Bước 3: Push và Tạo Pull Request

Khi hoàn thành task, đẩy nhánh của bạn lên GitHub.

```bash
# Đẩy nhánh mới lên remote (thêm -u cho lần đầu tiên)
git push -u origin [ten-nhanh-cua-ban]
```

Sau đó, truy cập GitHub:

1.  Bạn sẽ thấy thông báo "Compare & pull request". Nhấn vào đó.
2.  Đặt tiêu đề rõ ràng (VD: *Hoàn thành chức năng Quản lý Sách*).
3.  Trong phần **Reviewers**, chọn **Quang Anh**.
4.  Nhấn **Create pull request**.

### Bước 4: Review và Merge

  * **Lưu ý:** Thành viên không tự merge code của mình vào `main`.
  * **Quang Anh** sẽ review code.
      * Nếu code đạt yêu cầu, PR sẽ được merge.
      * Nếu cần chỉnh sửa, review-er sẽ để lại bình luận. Thành viên tiếp tục sửa code và push lên nhánh cũ (PR sẽ tự động cập nhật).
  * Sau khi nhánh được merge, bạn có thể xóa nhánh local và quay về `main`.

<!-- end list -->

```bash
git checkout main
git pull origin main
git branch -d [ten-nhanh-cua-ban]
```

-----

## Phân Công & Phụ Trách Module

### Lê Quang Anh

  * **Phụ trách:** Kiến trúc dự án, Database, quản lý Git, Module Authentication (`UserDAO`/`BLL`), Module Mượn/Trả (`BorrowDAO`/`BLL`).
  * **Nhiệm vụ:**
      * Thiết kế, hoàn thiện Database (`01_CreateDatabase.sql`).
      * Code class `DatabaseConnection.cs`.
      * Setup và bảo vệ nhánh `main`, review và merge Pull Requests.
      * Phát triển các nghiệp vụ phức tạp (Authentication, Borrow/Return).
      * Hỗ trợ các thành viên khi gặp vấn đề về kỹ thuật.

### Nguyễn Duy Thành

  * **Phụ trách:** Module Quản lý Sách.
  * **Nhiệm vụ:**
      * Code `BookDAO.cs` (CRUD, Search...).
      * Code `BookBLL.cs` (Validate dữ liệu sách).
      * Xử lý logic sự kiện cho `FormBookManagement.cs` (load data, gọi BLL để Thêm/Sửa/Xóa).

### Vũ Thị Thùy Trang

  * **Phụ trách:** Module Quản lý Độc Giả.
  * **Nhiệm vụ:**
      * Code `MemberDAO.cs` (CRUD, Search...).
      * Code `MemberBLL.cs` (Validate email, SĐT...).
      * Xử lý logic sự kiện cho `FormMemberManagement.cs`.

### Nguyễn Thị Hồng

  * **Phụ trách:** Thiết kế Giao diện người dùng (UI Design).
  * **Nhiệm vụ:**
      * Thiết kế file `.cs [Design]` cho tất cả các Form (Login, Main, Book, Member, Borrow).
      * Đảm bảo giao diện nhất quán, chuyên nghiệp.
      * Đặt tên control theo chuẩn (ví dụ: `txtBookTitle`, `dgvBooks`, `btnAddNewBook`).

### Nguyễn Minh Lộc

  * **Phụ trách:** Logic Form Login, Form Main và Dữ liệu mẫu.
  * **Nhiệm vụ:**
      * Xử lý logic `FormLogin.cs` (gọi `UserBLL.Login()`, xử lý kết quả).
      * Xử lý logic `FormMain.cs` (sự kiện click menu để mở các form con).
      * Viết và bổ sung script `Database/02_InsertSampleData.sql` để cung cấp dữ liệu test.

-----

## Danh Sách Tính Năng

1.  **Authentication:** Đăng nhập, phân quyền (Admin/Staff).
2.  **Quản lý Sách:** CRUD, tìm kiếm (tên sách, tác giả, thể loại).
3.  **Quản lý Độc Giả:** CRUD, tìm kiếm, xem lịch sử mượn.
4.  **Mượn/Trả Sách:**
      * Tạo phiếu mượn (kiểm tra số lượng sách).
      * Trả sách (cập nhật ngày trả, số lượng sách).
      * Xử lý nghiệp vụ trễ hạn, phạt (nếu có).
      * Liệt kê sách quá hạn.

## Lộ Trình Phát Triển (Roadmap)

Các tính năng/cải tiến dự kiến trong tương lai:

  * **UI/UX:**
      * Hoàn thiện theme màu thống nhất.
      * Cải thiện thông báo lỗi và validation.
  * **Tính năng:**
      * Dashboard thống kê (sách mượn nhiều, độc giả tích cực).
      * Export dữ liệu ra Excel.
      * In phiếu mượn.
  * **Bảo mật:**
      * Mã hóa mật khẩu (SHA256).
      * Ghi log (logging) hoạt động của người dùng.

-----

## Hỗ Trợ

  * **Vấn đề build lỗi:** Kiểm tra lại các **Project References**.
  * **Vấn đề kết nối:** Kiểm tra lại **Connection String** trong `App.config`.
  * **Vấn đề về Git (conflict,...):** Liên hệ **Quang Anh** để được hỗ trợ.
  * **Câu hỏi về nghiệp vụ hoặc kỹ thuật:**
      * Email: lequanganh253@gmail.com
