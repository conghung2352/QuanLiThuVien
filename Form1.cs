using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sql_connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConnectDB_SQL connectDB = new ConnectDB_SQL();
            string sUserName = txtName.Text;
            string sPass = txtPass.Text;
            Boolean result = true;
            result = connectDB.Fun_ConnectDB(sUserName, sPass);
            if (result)
            {
                Menu fr = new Menu();
                fr.Show();
                this.Hide();
                MessageBox.Show("Đăng nhập thành công");

            }
            else
            {
                MessageBox.Show("Sai tên hoặc mật khẩu");
            }
        }
        private void BtnRegister_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 reg = new Form3();
            reg.Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {     
                Application.Exit();
        }
    }
}

