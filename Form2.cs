using System;
using System.Data;
using System.Windows.Forms;

namespace sql_connect
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Abacre.Select s = new Abacre.Select();
            DataTable dt = s.GetListItem();
            dataGridView1.DataSource = dt;
        }

    }
}
