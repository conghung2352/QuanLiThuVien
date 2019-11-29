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
    public partial class PhysicalInventory : Form
    {
        int Hide;

        public int Hide1
        {
            get { return Hide; }
            set { Hide = value; }
        }
        public PhysicalInventory()
        {
            Hide1 = 5;
            InitializeComponent();
            load();
            //ReLoad_Languege():
        }

        public void load()
        {
            Abacre.Select s = new Abacre.Select();
            DataSet ds = new DataSet();
            dataGridView1.Rows.Clear();
            //comboBox1.Items.Clear();
            ds = s.select_all_item_store();
            DataTable dt = ds.Tables["tam"];
            int tam = dt.Rows.Count;
            for ( int i = 1; i<= tam; i++)
            {
                DataRow row = ds.Tables["tam"].Rows[i - 1];
                string s1 = row["itemid"].ToString();
                string s2 = row["name"].ToString();
                string s3 = row["physqty"].ToString();
                string s4 = row["onhqty"].ToString();

                dataGridView1.Rows.Add(s1, s2, s3, s4, "");
            }
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int t1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            int t2 = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
            /*dataGridView1.CurrentRow.Cells[4].Value = t1 - t2;
            dataGridView1.CurrentRow.Cells[3].Value = t1;
            dataGridView1.CurrentRow.Cells[2].Value = "";*/
            Abacre.Update u = new Abacre.Update();
            u.update_quatity_item(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),t1,t2);
            MessageBox.Show("Update thành công");
            load();
        }

        private void PhysicalInventory_Load(object sender, EventArgs e)
        {

        }
    }
}
