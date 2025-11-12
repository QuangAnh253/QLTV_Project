-----

# 📚 QLTV - Hệ Thống Quản Lý Thư Viện

## 🎯 Mô Tả Dự Án

Phần mềm quản lý thư viện được phát triển bằng C\# WinForms theo kiến trúc 3 lớp:

  - **DAL** (Data Access Layer): Tương tác với SQL Server
  - **BLL** (Business Logic Layer): Xử lý logic nghiệp vụ
  - **GUI** (Graphical User Interface): Giao diện người dùng

-----

## ⚙️ PHẦN 1: SETUP DỰ ÁN (CHO LEADER & MEMBERS)

### 📋 Yêu Cầu Hệ Thống

  - Visual Studio 2022 (hoặc 2019)
  - .NET Framework 4.7.2 trở lên
  - SQL Server 2019 hoặc SQL Server Express
  - Git

### 🔧 Bước 1: Setup Database (QUAN TRỌNG\!)

#### 1.1. Tạo Database trong SQL Server

```sql
-- Mở SQL Server Management Studio (SSMS)
-- Chạy script trong Database/01_CreateDatabase.sql
-- Chạy script trong Database/02_InsertSampleData.sql (nếu có)
```

#### 1.2. Lấy Connection String

1.  Mở SSMS, kết nối vào SQL Server
2.  Lấy tên Server (ví dụ: `localhost`, `.\SQLEXPRESS`, `DESKTOP-ABC\SQLEXPRESS`)
3.  Mở file `Database/ConnectionString.txt` để xem mẫu connection string

#### 1.3. Cấu Hình App.config

1.  Mở file `QLTV_GUI/App.config`
2.  Tìm dòng:
    ```xml
    <add name="QLTV_DB" 
         connectionString="Server=YOUR_SERVER_NAME;Database=QLTV_DB;Integrated Security=True;" 
         providerName="System.Data.SqlClient" />
    ```
3.  **THAY `YOUR_SERVER_NAME`** bằng tên SQL Server của bạn
4.  LƯU FILE

### 🏗️ Bước 2: Setup Project References

**2.1. Add References cho QLTV\_DAL**

  * Right click `QLTV_DAL` project → Add → Reference → Assemblies
  * ✓ `System.Configuration`
  * ✓ `System.Data`

**2.2. Add References cho QLTV\_BLL**

  * Right click `QLTV_BLL` project → Add → Reference
  * ✓ Projects → `QLTV_DAL`

**2.3. Add References cho QLTV\_GUI**

  * Right click `QLTV_GUI` project → Add → Reference
  * ✓ Projects → `QLTV_BLL`
  * ✓ Projects → `QLTV_DAL`
  * ✓ `System.Configuration` (Assemblies)

### ✅ Bước 3: Kiểm Tra Build

1.  Set `QLTV_GUI` làm StartUp Project (Right click → Set as StartUp Project)
2.  Build toàn bộ solution: **Ctrl + Shift + B**
3.  Nếu không có lỗi → SETUP THÀNH CÔNG\!

-----

## 🔄 PHẦN 2: QUY TRÌNH GIT WORKFLOW

### 👨‍💼 Dành cho LEADER (Setup lần đầu)

```bash
# 1. Tạo repo trên GitHub (tên: QLTV_Project)

# 2. Mở Terminal/CMD tại thư mục QLTV_Project
cd path/to/QLTV_Project

# 3. Khởi tạo Git
git init
git add .
git commit -m "Initial commit: Project skeleton"

# 4. Kết nối với GitHub và push
git remote add origin https://github.com/YOUR_USERNAME/QLTV_Project.git
git branch -M main
git push -u origin main

# 5. Thông báo link repo cho team members
```

### 👥 Dành cho MEMBERS (Clone và setup)

```bash
# 1. Clone repo về máy
git clone https://github.com/YOUR_USERNAME/QLTV_Project.git
cd QLTV_Project

# 2. Setup Database (theo hướng dẫn ở Phần 1)
# - Chạy script SQL
# - Sửa App.config

# 3. Mở solution và build
# - Mở file QLTV_Project.sln bằng Visual Studio
# - Build solution (Ctrl + Shift + B)

# 4. Kiểm tra kết nối database
# - Chạy project, nếu không lỗi kết nối → OK!
```

### 🔁 Quy Trình Làm Việc Hàng Ngày

**Trước khi bắt đầu code (PULL mới nhất)**

```bash
git pull origin main
```

**Sau khi hoàn thành task (COMMIT & PUSH)**

```bash
# 1. Kiểm tra file đã thay đổi
git status

# 2. Add các file cần commit
git add .

# 3. Commit với message rõ ràng
git commit -m "Feature: Hoàn thành chức năng quản lý sách"

# 4. Pull lại để tránh conflict
git pull origin main

# 5. Nếu có conflict, xử lý rồi mới push
git push origin main
```

### ⚠️ Lưu Ý Tránh Conflict

**✅ NÊN:**

  * Mỗi người code một module riêng (VD: A làm BookDAO, B làm MemberDAO)
  * Luôn pull trước khi bắt đầu code
  * Commit thường xuyên với message rõ ràng
  * Thông báo khi sửa file chung (`DatabaseConnection.cs`, `App.config`)

**❌ KHÔNG NÊN:**

  * 2 người cùng sửa 1 file cùng lúc
  * Commit code lỗi/chưa test
  * Push mà không pull trước
  * Commit file `App.config` với connection string cá nhân (nên dùng `.gitignore`)

-----

## 🚀 PHẦN 3: PHÂN CÔNG & HƯỚNG PHÁT TRIỂN

### 📊 Phân Công Module Chính Thức

| Tên Thành Viên | Vai Trò & Nhiệm Vụ Chính |
| :--- | :--- |
| **Lê Quang Anh** | **(Leader)**: Kiến trúc, Database, Git, Module Authentication (`UserDAO`/`BLL`), Module Mượn/Trả (`BorrowDAO`/`BLL`). |
| **Nguyễn Duy Thành** | **(Module Sách)**: `BookDAO`, `BookBLL`, Logic `FormBookManagement`. |
| **Vũ Thị Thùy Trang** | **(Module Độc Giả)**: `MemberDAO`, `MemberBLL`, Logic `FormMemberManagement`. |
| **Nguyễn Thị Hồng** | **(UI Design)**: Thiết kế toàn bộ giao diện (`.cs [Design]`) cho tất cả các Form. |
| **Nguyễn Minh Lộc** | **(Login & Data)**: Logic `FormLogin`, Logic `FormMain` (navigation), `02_InsertSampleData.sql`. |

#### 👤 Lê Quang Anh (Leader - Kiến trúc & Nghiệp vụ lõi)

**Vai trò:** Chịu trách nhiệm kiến trúc, các nghiệp vụ phức tạp nhất và quản lý source code.

1.  **Database & Architecture (Nền tảng):**

      * **Thiết kế & Hoàn thiện Database:** Viết và chốt hạ file `Database/01_CreateDatabase.sql` (bao gồm tất cả các bảng, khóa ngoại, ràng buộc - theo `PHẦN 6` tài liệu).
      * **Code `DatabaseConnection.cs`:** Hoàn thiện 100% class này (theo `PHẦN 5`) để team có thể test kết nối.
      * **Quản lý Git:** Setup GitHub repo, quản lý branch và là người **duyệt (review) & merge** code của các thành viên khác.

2.  **Module Lõi & Phức Tạp Nhất:**

      * **Authentication (Xác thực):**
          * `UserDAO.cs` (Viết code validate user/pass)
          * `UserBLL.cs` (Xử lý logic, mã hóa password nếu có)
      * **Borrow Module (Nghiệp vụ Mượn/Trả):** Đây là module khó nhất vì nó liên kết tất cả các bảng khác.
          * `BorrowDAO.cs` (Code các query mượn, trả, tìm phiếu, quá hạn)
          * `BorrowBLL.cs` (Xử lý logic nghiệp vụ: *khi mượn phải giảm `Available` bên `Books`, khi trả phải tăng, kiểm tra độc giả có bị phạt không...*)

3.  **Hỗ Trợ & Tích Hợp:**

      * Hỗ trợ các thành viên khi bị "tắc" (block) ở phần DAL hoặc BLL.
      * Chịu trách nhiệm tích hợp (merge) các form vào `FormMain`.

-----

#### 👤 Nguyễn Duy Thành (Module Quản Lý Sách)

**Vai trò:** Chịu trách nhiệm hoàn chỉnh (full-stack) cho module quản lý sách.

1.  **Code `BookDAO.cs`:** Hoàn thiện tất cả các hàm CRUD cho Sách (Get, Insert, Update, Delete, Search...).
2.  **Code `BookBLL.cs`:** Hoàn thiện logic validate dữ liệu sách (ví dụ: `Quantity` không được âm, `Title` không được rỗng...).
3.  **Code `FormBookManagement.cs` (Logic):** Lập trình logic cho form:
      * Load data lên `DataGridView`.
      * Lấy data từ `TextBox` gọi BLL để Thêm/Sửa/Xóa.
      * Xử lý sự kiện click cho các button.

-----

#### 👤 Vũ Thị Thùy Trang (Module Quản Lý Độc Giả)

**Vai trò:** Chịu trách nhiệm hoàn chỉnh (full-stack) cho module quản lý độc giả.

1.  **Code `MemberDAO.cs`:** Hoàn thiện tất cả các hàm CRUD cho Độc giả.
2.  **Code `MemberBLL.cs`:** Hoàn thiện logic validate dữ liệu (ví dụ: kiểm tra format email, số điện thoại...).
3.  **Code `FormMemberManagement.cs` (Logic):** Lập trình logic cho form:
      * Load data lên `DataGridView`.
      * Lấy data từ `TextBox` gọi BLL để Thêm/Sửa/Xóa.
      * Xử lý sự kiện click.

-----

#### 👤 Nguyễn Thị Hồng (UI Design)

**Vai trò:** Chịu trách nhiệm thiết kế toàn bộ giao diện người dùng (UI).

1.  **Thiết Kế Giao Diện (UI Design):**
      * Chịu trách nhiệm **kéo thả, thiết kế** giao diện cho *tất cả* các Form (`.cs [Design]`).
      * `FormLogin.cs [Design]`
      * `FormMain.cs [Design]` (Thiết kế menu, các nút điều hướng, icon).
      * `FormBookManagement.cs [Design]`
      * `FormMemberManagement.cs [Design]`
      * `FormBorrowManagement.cs [Design]`
2.  **Chuẩn Hóa:** Đảm bảo giao diện đẹp, nhất quán, và các control được đặt tên đúng chuẩn (ví dụ: `txtBookTitle`, `dgvBooks`, `btnAddNewBook`) để các thành viên khác code logic.

-----

#### 👤 Nguyễn Minh Lộc (Login & Data)

**Vai trò:** Chịu trách nhiệm cho điểm vào (entry-point) của ứng dụng và dữ liệu test.

1.  **Code `FormLogin.cs` (Logic):**
      * Lập trình logic cho form: Lấy `username`/`password` từ `TextBox`.
      * Gọi `UserBLL.Login()` (do Lê Quang Anh viết).
      * Nếu đăng nhập thành công, mở `FormMain` và đóng `FormLogin`.
2.  **Code `FormMain.cs` (Logic):**
      * Lập trình logic cho form: Viết các sự kiện `Click` cho các nút menu/button để mở các form con (do Nguyễn Thị Hồng thiết kế).
3.  **Data & Test:**
      * Viết/bổ sung script `Database/02_InsertSampleData.sql` (chèn nhiều dữ liệu mẫu để team test).
      * Phối hợp test các chức năng sau khi hoàn thành.

-----

### 🔍 Các Chức Năng Cần Phát Triển

1.  **Authentication (Đăng nhập)**
      * Validate username/password
      * Phân quyền Admin/Staff
      * Session management
2.  **Quản Lý Sách**
      * Thêm/Sửa/Xóa sách
      * Tìm kiếm theo: tên sách, tác giả, thể loại
      * Hiển thị số lượng available/borrowed
3.  **Quản Lý Độc Giả**
      * CRUD độc giả
      * Validate phone/email format
      * Xem lịch sử mượn của độc giả
4.  **Mượn/Trả Sách**
      * Tạo phiếu mượn (kiểm tra sách còn không)
      * Trả sách (cập nhật return date, tăng số lượng)
      * Tính phí phạt trễ hạn
      * Xem danh sách sách quá hạn
5.  **Báo Cáo/Thống Kê (Nâng cao)**
      * Sách được mượn nhiều nhất
      * Độc giả mượn nhiều nhất
      * Báo cáo theo tháng/năm

### 🎨 Gợi Ý Cải Tiến

  * **UI/UX:**
      * Dùng icon cho button
      * Theme màu thống nhất
      * Validation message thân thiện
  * **Tính năng:**
      * Export Excel
      * In phiếu mượn
      * Gửi email nhắc trả sách
      * Dashboard với chart
  * **Bảo mật:**
      * Mã hóa password (MD5/SHA256)
      * Lock user sau 3 lần đăng nhập sai
      * Log hoạt động user

### 📞 Hỗ Trợ

  * **Gặp vấn đề?**
      * Không kết nối được database → Kiểm tra connection string
      * Build lỗi → Kiểm tra references giữa các project
      * Conflict Git → Liên hệ leader để hỗ trợ merge
  * **Contact Leader:**
      * **Lê Quang Anh** - lequanganh253@gmail.com

### 📝 License

Dự án học tập - Đại học Công nghệ Giao thông vận tải/74DCHT22 - 2025