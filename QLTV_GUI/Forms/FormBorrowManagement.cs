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
    public partial class FormBorrowManagement : Form
    {
        private BorrowBLL borrowBLL = new BorrowBLL();
        public FormBorrowManagement()
        {
            InitializeComponent();
            // TODO: Design form mượn/trả sách
            // Gồm: ComboBox chọn độc giả, ComboBox chọn sách, DateTimePicker, Button
            LoadData();
        }
        private void LoadData()
        {
            // TODO: Load danh sách phiếu mượn
        }
        // TODO: Thêm event handler cho mượn/trả sách
    }
}