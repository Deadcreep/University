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
                Dock = DockStyle.Fill,
                Text = "Login "
            };

            TextBox loginBox = new TextBox()
            {
                Dock = DockStyle.Fill,
            };

            Label passLabel = new Label()
            {
                Dock = DockStyle.Fill,
                Text = "Password ",
            };

            TextBox passBox = new TextBox()
            {
                Dock = DockStyle.Fill,
                PasswordChar = '*'
            };

            Button TryLogin = new Button()
            {
                Dock = DockStyle.Top,
                Text = "Вход"
            };          

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.Dock = DockStyle.Fill;

            table.Controls.Add(loginLabel);
            table.Controls.Add(loginBox);
            table.Controls.Add(passLabel);
            table.Controls.Add(passBox);
            table.Controls.Add(TryLogin);
            Controls.Add(table);
        }
    }
}
