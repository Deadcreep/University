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
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
           // InitializeComponent();
        }

        public static void Message(string message)
        {
            MessageBox.Show(message);
        }
    }
}
