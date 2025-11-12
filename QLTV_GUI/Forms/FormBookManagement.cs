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
    public partial class FormBookManagement : Form
    {
        private BookBLL bookBLL = new BookBLL();
        public FormBookManagement()
        {
            InitializeComponent();
            // TODO: Design form với DataGridView, TextBox, Button (Add, Update, Delete)
            LoadData();
        }
        private void LoadData()
        {
            // TODO: Gọi bookBLL.GetAllBooks() và hiển thị lên DataGridView
        }
        // TODO: Thêm các event handlers cho CRUD operations
    }
}