<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace University
{
    class MainMenu : Form
    {
        public MainMenu()
        {
            Button SeeSheduleButton = new Button()
            {
                Dock = DockStyle.Fill,
                Text = "Посмотреть Расписание"                
            };

            Button ChangeSheduleButton = new Button()
            {
                Dock = DockStyle.Fill,
                Text = "Изменить Расписание"
            };

            var table = new TableLayoutPanel();

            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));            
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(SeeSheduleButton);
            table.Controls.Add(ChangeSheduleButton);
            Controls.Add(table);
        }        
    }
}
=======
﻿using System;
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
>>>>>>> origin/master
