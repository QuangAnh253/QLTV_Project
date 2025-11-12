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

### 👥 Hướng Dẫn Dành Cho **Members** — Clone & Setup Dự Án

---

## ⚙️ 1. Clone Repo Về Máy

```bash
git clone https://github.com/QuangAnh253/QLTV_Project.git
cd QLTV_Project
````

---

## 🗃️ 2. Setup Database

1. Mở **SQL Server Management Studio (SSMS)**.
2. Chạy lần lượt các script sau:

   * `Database/01_CreateDatabase.sql`
   * `Database/02_InsertSampleData.sql`
3. Mở file `QLTV_GUI/App.config` và sửa **connection string** cho đúng tên server của bạn.

---

## 🧩 3. Mở Solution & Build

1. Mở file `QLTV_Project.sln` bằng **Visual Studio**.
2. Build solution bằng tổ hợp phím:

   ```text
   Ctrl + Shift + B
   ```

---

## ✅ 4. Kiểm Tra Kết Nối Database

* Chạy project.
* Nếu không báo lỗi kết nối → setup thành công.

---

# 🔁 Quy Trình Làm Việc Chuẩn (Workflow - Pull Request)

Đây là quy trình **bắt buộc** để **Quang Anh** có thể review code trước khi merge vào `main`.

---

## 🧠 Bước 1: Bắt Đầu Task Mới (Trên Nhánh Riêng)

Lấy code mới nhất từ `main`:

```bash
# Chuyển sang nhánh main
git checkout main

# Kéo code mới nhất từ server
git pull origin main
```

Tạo nhánh mới cho nhiệm vụ của bạn theo quy tắc:

> **Cấu trúc nhánh:** `[tên-của-bạn]/[mô-tả-ngắn-task]`

**Danh sách prefix:**

| Thành viên        | Prefix nhánh |
| ----------------- | ------------ |
| Nguyễn Duy Thành  | `duythanh`   |
| Vũ Thị Thùy Trang | `thuytrang`  |
| Nguyễn Minh Lộc   | `vanloc`     |
| Nguyễn Thị Hồng   | `thihong`    |

**Ví dụ:**

```bash
# Duy Thành code module Quản lý sách
git checkout -b duythanh/code-module-sach

# Thị Hồng thiết kế form login
git checkout -b thihong/ui-form-login
```

---

## 💻 Bước 2: Code & Commit Trên Nhánh Mới

Làm việc và commit như bình thường:

```bash
# Thêm toàn bộ thay đổi
git add .

# Commit code
git commit -m "Feature: Hoan thanh code BookDAO"
```

> Bạn có thể commit nhiều lần trên cùng nhánh.

---

## 🚀 Bước 3: Push & Tạo Pull Request

Khi đã hoàn thành task:

```bash
# Đẩy nhánh của bạn lên GitHub
git push origin [ten-nhanh-cua-ban]

# Nếu là lần đầu push:
git push --set-upstream origin [ten-nhanh-cua-ban]
```

Sau đó:

1. Truy cập repo trên **GitHub**.
2. Nhấn **“Compare & pull request”**.
3. Viết tiêu đề và mô tả rõ ràng (VD: *Hoàn thành chức năng quản lý sách*).
4. Ở phần **Reviewers**, chọn **Quang Anh**.
5. Nhấn **Create pull request**.

---

## 🔍 Bước 4: Review & Merge

* ❌ **Không được tự merge.**
* **Quang Anh** sẽ review code:

  * ✅ Nếu đạt yêu cầu → Merge vào `main`.
  * 🛠️ Nếu cần chỉnh sửa → Quang Anh comment góp ý.
    Bạn chỉ cần sửa code, commit & push lên **cùng nhánh**, PR sẽ tự cập nhật.
* Sau khi nhánh đã merge:

  ```bash
  # Xóa nhánh local và quay lại main
  git branch -d [ten-nhanh-cua-ban]
  git checkout main
  ```

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

# 👥 Phân Công Nhiệm Vụ Dự Án Quản Lý Thư Viện

---

## 👤 **Lê Quang Anh** (Leader - Kiến trúc & Nghiệp vụ lõi)

**Vai trò:**  
Chịu trách nhiệm kiến trúc, các nghiệp vụ phức tạp nhất và quản lý source code.

### 🧩 Database & Architecture (Nền tảng)
- **Thiết kế & Hoàn thiện Database:**  
  Viết và chốt hạ file `Database/01_CreateDatabase.sql`, đảm bảo bao gồm tất cả các bảng, khóa ngoại, và ràng buộc cần thiết.
- **Code `DatabaseConnection.cs`:**  
  Hoàn thiện 100% class này, bao gồm cả hàm `TestConnection` để team có thể kiểm tra kết nối.
- **Quản lý Git:**  
  - Setup GitHub repo.  
  - Bảo vệ nhánh `main` (yêu cầu Pull Request).  
  - Là người duy nhất **review & merge** code của các thành viên khác.

### ⚙️ Module Lõi & Phức Tạp Nhất
#### 🔐 Authentication (Xác thực)
- `UserDAO.cs`: Viết code validate user/pass.  
- `UserBLL.cs`: Xử lý logic, mã hóa password (nếu có).

#### 📚 Borrow Module (Mượn/Trả)
- `BorrowDAO.cs`: Code các query mượn, trả, tìm phiếu, quá hạn.  
- `BorrowBLL.cs`: Xử lý logic nghiệp vụ (giảm/tăng `Available` trong Books, kiểm tra phạt...).

### 🧠 Hỗ Trợ & Tích Hợp
- Hỗ trợ các thành viên khi bị "tắc" ở phần DAL hoặc BLL.  
- Tích hợp (merge) các form vào `FormMain`.

---

## 👤 **Nguyễn Duy Thành** (Module Quản Lý Sách)

**Vai trò:**  
Chịu trách nhiệm hoàn chỉnh (full-stack) cho module **Quản lý sách**.

### 📘 Code
- `BookDAO.cs`: Hoàn thiện tất cả các hàm CRUD (Get, Insert, Update, Delete, Search...).  
- `BookBLL.cs`: Validate dữ liệu sách (Quantity ≥ 0, Title không rỗng...).

### 🧩 Giao Diện & Logic
- `FormBookManagement.cs` (Logic):
  - Load data lên `DataGridView`.  
  - Lấy data từ `TextBox` gọi BLL để Thêm/Sửa/Xóa.  
  - Xử lý sự kiện click cho các button.

---

## 👤 **Vũ Thị Thùy Trang** (Module Quản Lý Độc Giả)

**Vai trò:**  
Chịu trách nhiệm hoàn chỉnh (full-stack) cho module **Quản lý độc giả**.

### 📗 Code
- `MemberDAO.cs`: Hoàn thiện tất cả các hàm CRUD.  
- `MemberBLL.cs`: Validate dữ liệu (format email, số điện thoại...).

### 🧩 Giao Diện & Logic
- `FormMemberManagement.cs` (Logic):
  - Load data lên `DataGridView`.  
  - Lấy data từ `TextBox` gọi BLL để Thêm/Sửa/Xóa.  
  - Xử lý sự kiện click.

---

## 👤 **Nguyễn Thị Hồng** (UI Design)

**Vai trò:**  
Chịu trách nhiệm **thiết kế toàn bộ giao diện người dùng (UI).**

### 🎨 Thiết Kế Giao Diện (UI Design)
Thiết kế phần **[Design]** của tất cả các form:
- `FormLogin.cs [Design]`  
- `FormMain.cs [Design]` (menu, điều hướng, icon)  
- `FormBookManagement.cs [Design]`  
- `FormMemberManagement.cs [Design]`  
- `FormBorrowManagement.cs [Design]`

### 🧱 Chuẩn Hóa
- Đảm bảo giao diện **đẹp, nhất quán**.  
- Các control đặt tên đúng chuẩn (ví dụ: `txtBookTitle`, `dgvBooks`, `btnAddNewBook`).

---

## 👤 **Nguyễn Minh Lộc** (Login & Data)

**Vai trò:**  
Chịu trách nhiệm **điểm vào (entry-point)** của ứng dụng và **dữ liệu test.**

### 🔑 Code Logic
- `FormLogin.cs` (Logic):
  - Lấy `username` / `password` từ `TextBox`.  
  - Gọi `UserBLL.Login()` (do Lê Quang Anh viết).  
  - Nếu đăng nhập thành công → mở `FormMain`, đóng `FormLogin`.

- `FormMain.cs` (Logic):
  - Viết sự kiện `Click` cho các nút menu để mở form con (do Nguyễn Thị Hồng thiết kế).

### 🧾 Data & Test
- Viết/bổ sung script `Database/02_InsertSampleData.sql` (chèn dữ liệu mẫu để test).  
- Phối hợp test các chức năng sau khi hoàn thành.

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
