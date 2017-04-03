using System;
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
