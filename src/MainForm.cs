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
    }
}
