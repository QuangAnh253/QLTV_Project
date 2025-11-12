using QLTV_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_GUI.Forms
{
    public partial class FormMain : Form
    {
        // Lưu thông tin user đang đăng nhập
        private int _userId;
        private string _fullName;
        private string _role;

        /// <summary>
        /// Constructor BẮT BUỘC - Nhận thông tin user từ FormLogin
        /// </summary>
        public FormMain(int userId, string fullName, string role)
        {
            InitializeComponent();
            
            // Lưu thông tin user
            _userId = userId;
            _fullName = fullName;
            _role = role;
            
            // Thiết lập form
            SetupForm();
            CreateMenuControls();
        }

        /// <summary>
        /// Thiết lập thuộc tính form
        /// </summary>
        private void SetupForm()
        {
            // Hiển thị thông tin user trên tiêu đề
            this.Text = $"Quản lý Thư viện - {_fullName} ({_role})";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Tạo menu và các nút chức năng
        /// </summary>
        private void CreateMenuControls()
        {
            // ===== PANEL HEADER =====
            Panel pnlHeader = new Panel();
            pnlHeader.BackColor = Color.FromArgb(0, 120, 215);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 80;
            this.Controls.Add(pnlHeader);

            // Label tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            lblTitle.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            pnlHeader.Controls.Add(lblTitle);

            // Label thông tin user
            Label lblUserInfo = new Label();
            lblUserInfo.Text = $"👤 {_fullName} ({_role})";
            lblUserInfo.Font = new Font("Arial", 11);
            lblUserInfo.ForeColor = Color.White;
            lblUserInfo.AutoSize = true;
            lblUserInfo.Location = new Point(20, 50);
            pnlHeader.Controls.Add(lblUserInfo);

            // ===== PANEL MENU BÊN TRÁI =====
            Panel pnlMenu = new Panel();
            pnlMenu.BackColor = Color.FromArgb(45, 45, 48);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 250;
            this.Controls.Add(pnlMenu);

            // ===== CÁC NÚT MENU =====
            int yPos = 20;

            // Nút Quản lý Sách
            Button btnBooks = CreateMenuButton("📚 Quản lý Sách", yPos);
            btnBooks.Click += BtnBooks_Click;
            pnlMenu.Controls.Add(btnBooks);
            yPos += 60;

            // Nút Quản lý Độc giả
            Button btnMembers = CreateMenuButton("👥 Quản lý Độc giả", yPos);
            btnMembers.Click += BtnMembers_Click;
            pnlMenu.Controls.Add(btnMembers);
            yPos += 60;

            // Nút Mượn/Trả sách
            Button btnBorrow = CreateMenuButton("📖 Mượn/Trả sách", yPos);
            btnBorrow.Click += BtnBorrow_Click;
            pnlMenu.Controls.Add(btnBorrow);
            yPos += 60;

            // Nút Thống kê (chỉ Admin mới thấy)
            if (_role == "Admin")
            {
                Button btnStats = CreateMenuButton("📊 Thống kê", yPos);
                btnStats.Click += BtnStats_Click;
                pnlMenu.Controls.Add(btnStats);
                yPos += 60;
            }

            // Nút Test Connection
            Button btnTest = CreateMenuButton("🔌 Test Database", yPos);
            btnTest.Click += button1_Click;
            pnlMenu.Controls.Add(btnTest);
            yPos += 60;

            // Nút Đổi mật khẩu
            Button btnChangePass = CreateMenuButton("🔒 Đổi mật khẩu", yPos);
            btnChangePass.Click += BtnChangePass_Click;
            pnlMenu.Controls.Add(btnChangePass);
            yPos += 60;

            // Nút Đăng xuất
            Button btnLogout = CreateMenuButton("🚪 Đăng xuất", yPos);
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.Click += BtnLogout_Click;
            pnlMenu.Controls.Add(btnLogout);

            // ===== PANEL CONTENT =====
            Panel pnlContent = new Panel();
            pnlContent.BackColor = Color.White;
            pnlContent.Dock = DockStyle.Fill;
            this.Controls.Add(pnlContent);

            // Label chào mừng
            Label lblWelcome = new Label();
            lblWelcome.Text = $"Xin chào, {_fullName}!\n\nChọn chức năng từ menu bên trái để bắt đầu.";
            lblWelcome.Font = new Font("Arial", 14);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(50, 50);
            pnlContent.Controls.Add(lblWelcome);
        }

        /// <summary>
        /// Tạo nút menu với style thống nhất
        /// </summary>
        private Button CreateMenuButton(string text, int yPos)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 11, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(0, 120, 215);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = new Point(10, yPos);
            btn.Size = new Size(230, 50);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
            
            // Hiệu ứng hover
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(0, 150, 255);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(0, 120, 215);
            
            return btn;
        }

        // ===== CÁC SỰ KIỆN MENU =====

        private void BtnBooks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Sách đang phát triển...", "Thông báo");
        }

        private void BtnMembers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Độc giả đang phát triển...", "Thông báo");
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Mượn/Trả sách đang phát triển...", "Thông báo");
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Thống kê đang phát triển...", "Thông báo");
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Đổi mật khẩu đang phát triển...", "Thông báo");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ===== TEST CONNECTION (GIỮ NGUYÊN CODE CŨ) =====
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            // Empty - giữ lại để không lỗi nếu Designer có reference
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DatabaseConnection.TestConnection())
            {
                string info = DatabaseConnection.GetConnectionInfo();
                MessageBox.Show($"✓ Kết nối thành công!\n{info}",
                "Database Connection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("✗ Kết nối thất bại!\n\nVui lòng kiểm tra:\n" +
                "1. SQL Server đã chạy chưa?\n" +
                "2. Database QLTV_DB đã được tạo chưa?\n" +
                "3. Connection string trong App.config đúng chưa?",
                "Database Connection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}