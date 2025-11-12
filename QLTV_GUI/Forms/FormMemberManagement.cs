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
    public partial class FormMemberManagement : Form
    {
        private MemberBLL memberBLL = new MemberBLL();
        public FormMemberManagement()
        {
            InitializeComponent();
            // TODO: Design form quản lý độc giả
            LoadData();
        }
        private void LoadData()
        {
            // TODO: Load danh sách độc giả
        }
    }
}