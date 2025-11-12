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
        public FormLogin()
        {
            InitializeComponent();
            // TODO: Design form login với TextBox username/password, Button login
        }
        // TODO: Thêm event handler cho button Login
        // private void btnLogin_Click(object sender, EventArgs e)
        // {
        // // Gọi userBLL.Login()
        // // Nếu thành công, mở FormMain và đóng FormLogin
        // }
    }
}