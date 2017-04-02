using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace University
{
    class LoginForm : Form
    {
        public LoginForm()
        {
            Label loginLabel = new Label()
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 30),
                Text = "Login "
            };

            TextBox loginBox = new TextBox()
            {
                Location = new Point(0, loginLabel.Bottom),
                Size = new Size(ClientSize.Width, 30)
            };

            Label passLabel = new Label()
            {
                Location = new Point(0, loginBox.Bottom),
                Size = new Size(ClientSize.Width, 30),
                Text = "Password "
            };

            TextBox passBox = new TextBox()
            {
                Location = new Point(0, passLabel.Bottom),
                Size = new Size(ClientSize.Width, 30)
            };

            Button TryLogin = new Button()
            {
                Location = new Point(0, passBox.Bottom + 10),
                Size = new Size(70, 30),
                Text = "Вход"
                
            };          
            Controls.Add(loginLabel);
            Controls.Add(loginBox);
            Controls.Add(passLabel);
            Controls.Add(passBox);
            Controls.Add(TryLogin);

        }
    }
}
