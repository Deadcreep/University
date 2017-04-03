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
        Label loginLabel;
        TextBox loginBox;
        Label passLabel;
        TextBox passBox;
        Button TryLogin;

        public LoginForm()
        {
            var aut = new Authorization();
            loginLabel = new Label()
            {
                Text = "Login ",
                Dock = DockStyle.Fill
            };

            loginBox = new TextBox()
            {   
                Size = new Size(ClientSize.Width, 30),
                Dock = DockStyle.Fill
            };

            passLabel = new Label()
            {   
                Text = "Password ",
                Dock = DockStyle.Fill
            };

            passBox = new TextBox()
            {
                Dock = DockStyle.Fill,                
                PasswordChar = '*'
                
            };

            TryLogin = new Button()
            {
                Text = "Вход",                
                Dock = DockStyle.Top
            };

            var table = new TableLayoutPanel();

            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(loginLabel, 0, 0);
            table.Controls.Add(loginBox, 0, 1);
            table.Controls.Add(passLabel, 0, 2);
            table.Controls.Add(passBox, 0, 3);
            table.Controls.Add(TryLogin, 0, 4);
            table.Dock = DockStyle.Fill;
            Controls.Add(table);
            var tempPass = passBox.Text;
            var tempLog = loginBox.Text
            TryLogin.Click += (sender, args) => aut.TryLogin_Click(this, tempLog, tempPass);
        }
        
    }
}
