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
    public partial class Menu : Form
    {
        PhysicalInventory phs;
        InventoryCategory cat;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void PhysicalInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*HideAllForm();*/
            phs = new PhysicalInventory();
            phs.MdiParent = this;
            phs.Show();
        }



        private void Button10_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void InventoryCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cat = new InventoryCategory();
            cat.MdiParent = this;
            cat.Show();
        }
    }
}
