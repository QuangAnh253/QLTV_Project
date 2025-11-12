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
        public FormMain()
        {
            InitializeComponent();
        }
        // TODO: Thêm button "Test Connection" trong form design
        // Khi member clone về, click button này để test database

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            
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
        // TODO: Thêm các event handler khác để mở các form con
    }
}