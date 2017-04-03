using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University
{
    public partial class MainMenu : Form
    {
        
        public delegate string DelegateButton();
        public event DelegateButton onClick;

        public MainMenu()
        {
            InitializeComponent();           
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {          
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
