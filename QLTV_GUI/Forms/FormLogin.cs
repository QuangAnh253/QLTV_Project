using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QLTV_BLL;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_GUI.Forms
{
    public partial class FormLogin : Form
    {
        private UserBLL userBLL = new UserBLL();

        // Controls (tạo bằng code, không cần Designer)
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private CheckBox chkShowPassword;

        public FormLogin()
        {
            InitializeComponent();
            SetupFormProperties();
            CreateControls();
        }

        /// <summary>
        /// Thiết lập thuộc tính form
        /// </summary>
        private void SetupFormProperties()
        {
            this.Text = "Đăng nhập - Hệ thống Quản lý Thư viện";
            this.Size = new Size(450, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
        }

        /// <summary>
        /// Tạo các controls trên form
        /// </summary>
        private void CreateControls()
        {
            // ===== TITLE =====
            lblTitle = new Label();
            lblTitle.Text = "QUẢN LÝ THƯ VIỆN";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(100, 30);
            this.Controls.Add(lblTitle);

            // ===== USERNAME LABEL =====
            lblUsername = new Label();
            lblUsername.Text = "Tên đăng nhập:";
            lblUsername.Font = new Font("Arial", 10);
            lblUsername.Location = new Point(50, 100);
            lblUsername.AutoSize = true;
            this.Controls.Add(lblUsername);

            // ===== USERNAME TEXTBOX =====
            txtUsername = new TextBox();
            txtUsername.Font = new Font("Arial", 10);
            txtUsername.Location = new Point(50, 125);
            txtUsername.Size = new Size(340, 30);
            txtUsername.TabIndex = 0;
            this.Controls.Add(txtUsername);

            // ===== PASSWORD LABEL =====
            lblPassword = new Label();
            lblPassword.Text = "Mật khẩu:";
            lblPassword.Font = new Font("Arial", 10);
            lblPassword.Location = new Point(50, 165);
            lblPassword.AutoSize = true;
            this.Controls.Add(lblPassword);

            // ===== PASSWORD TEXTBOX =====
            txtPassword = new TextBox();
            txtPassword.Font = new Font("Arial", 10);
            txtPassword.Location = new Point(50, 190);
            txtPassword.Size = new Size(340, 30);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TabIndex = 1;
            txtPassword.KeyPress += TxtPassword_KeyPress;
            this.Controls.Add(txtPassword);

            // ===== CHECKBOX SHOW PASSWORD =====
            chkShowPassword = new CheckBox();
            chkShowPassword.Text = "Hiện mật khẩu";
            chkShowPassword.Font = new Font("Arial", 9);
            chkShowPassword.Location = new Point(50, 225);
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            this.Controls.Add(chkShowPassword);

            // ===== LOGIN BUTTON =====
            btnLogin = new Button();
            btnLogin.Text = "Đăng nhập";
            btnLogin.Font = new Font("Arial", 10, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(50, 260);
            btnLogin.Size = new Size(160, 35);
            btnLogin.TabIndex = 2;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            // ===== EXIT BUTTON =====
            btnExit = new Button();
            btnExit.Text = "Thoát";
            btnExit.Font = new Font("Arial", 10);
            btnExit.BackColor = Color.Gray;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(230, 260);
            btnExit.Size = new Size(160, 35);
            btnExit.TabIndex = 3;
            btnExit.Cursor = Cursors.Hand;
            btnExit.Click += BtnExit_Click;
            this.Controls.Add(btnExit);

            // Focus vào username khi form load
            this.Load += (s, e) => txtUsername.Focus();
        }

        /// <summary>
        /// Sự kiện Click button Đăng nhập
        /// </summary>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ TextBox
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Gọi BLL để xử lý đăng nhập
                DataRow userInfo = userBLL.Login(username, password);

                // Đăng nhập thành công
                if (userInfo != null)
                {
                    // Lưu thông tin user
                    string fullName = userInfo["FullName"].ToString();
                    string role = userInfo["Role"].ToString();
                    int userId = Convert.ToInt32(userInfo["UserID"]);

                    // Hiển thị thông báo chào mừng
                    MessageBox.Show(
                        $"Đăng nhập thành công!\n\nChào mừng: {fullName}\nVai trò: {role}",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Mở FormMain và truyền thông tin user (3 tham số)
                    FormMain frmMain = new FormMain(userId, fullName, role);
                    this.Hide(); // Ẩn FormLogin
                    frmMain.ShowDialog();
                    this.Close(); // Đóng FormLogin khi FormMain đóng
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(
                    ex.Message,
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                // Clear password để bảo mật
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        /// <summary>
        /// Sự kiện Click button Thoát
        /// </summary>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát ứng dụng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Sự kiện thay đổi checkbox Hiện mật khẩu
        /// </summary>
        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        /// <summary>
        /// Sự kiện nhấn phím trong TextBox password
        /// </summary>
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}