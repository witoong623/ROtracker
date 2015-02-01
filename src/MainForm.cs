using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROtracker.Extension;

namespace ROtracker
{
    public partial class MainForm : Form
    {
        private List<RoundDetail> eachBoss = new List<RoundDetail>();
        private System.Timers.Timer Clock = new System.Timers.Timer(60000);
        private DBConnector myDB;

        public List<RoundDetail> EachBoss
        {
            get
            {
                return eachBoss;
            }
        }

        private static void Main()
        {
            MainForm main = new MainForm();
            Application.EnableVisualStyles();
            Application.Run(main);
        }

        public MainForm()
        {
            InitializeComponent();
            // this.Text = "ROtracker : wait boss " + boss.Count;
        }

        private void testConnection_Click(object sender, EventArgs e)
        {
            if (myDB == null)
            {
                myDB = new DBConnector();
            }

            if (myDB.CanConnect())
            {
                MessageBox.Show("Can connect to database", "Sucesses to connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cannot connect to databse", "Cannot connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void AddBossDetail()
        {
            // Test revert
            AddNewTime newTime = new AddNewTime();
            newTime.ShowDialog();
            newTime.Dispose();
        }

        private void stmAddNewTime_Click(object sender, EventArgs e)
        {
            AddNewTime addNewTimeForm = new AddNewTime();
            addNewTimeForm.ShowDialog();
            addNewTimeForm.Dispose();
        }

    }
}
