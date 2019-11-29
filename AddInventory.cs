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
    public partial class AddInventory : Form
    {
        InventoryCategory _inv;
        public AddInventory(InventoryCategory inv)
        {
            _inv = inv;
            
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {   
            string a = txtName.Text;
            Abacre.Insert ins = new Abacre.Insert();
            ins.insert_Inven_Cat(a);
            MessageBox.Show("Them vao thanh cong");
            _inv.load();
            this.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
