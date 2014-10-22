using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROtracker.src
{
    public partial class MainForm : Form
    {
        private static void Main()
        {
            MainForm main = new MainForm();
            Application.EnableVisualStyles();
            Application.Run(main);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myDB = new DBConnector();

            if (myDB.CanConnect())
            {
                MessageBox.Show("Can connect to database", "Sucesses to connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cannot connect to databse", "Cannot connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
