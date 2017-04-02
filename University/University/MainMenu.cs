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
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 30),
                Text = "Посмотреть Расписание"                
            };

            Button ChangeSheduleButton = new Button()
            {
                Location = new Point(0, SeeSheduleButton.Bottom),
                Size = new Size(ClientSize.Width, 30),
                Text = "Изменить Расписание"
            };

            Controls.Add(SeeSheduleButton);
            Controls.Add(ChangeSheduleButton);
        }

        
    }
}
