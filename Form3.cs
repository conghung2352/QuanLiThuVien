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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string a, b, c, d, i, f, g;
            Boolean h;
            a = txtFN.Text;
            b = txtLN.Text;
            c = txtUser.Text;
            d = txtPhone.Text;
            i = txtStreet.Text;
            f = txtEmail.Text;
            g = txtPass.Text;
            h = cbisadmin.Checked;
            Abacre.Insert ins = new Abacre.Insert();
            ins.insert_worker1(a, b, c, d, i, f, g, h);
            MessageBox.Show("Them vao thanh cong!");
        }
    }
}
