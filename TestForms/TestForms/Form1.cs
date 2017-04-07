using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var lst = new List<Tst>
            {
                new Tst {Key = 13, Value = "Thirteen"},
                new Tst {Key = 21, Value = "Twenty"},
                new Tst {Key = 101, Value = "Hunred and one"},
            };

            comboBox1.DataSource = lst;

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            

            dataGridView1["Monday", 1] = new DataGridViewTextBoxCell() {Value = new Tst { Key = 101, Value = "Hunred and one" } };
            dataGridView1["Tuesday", 0] = new DataGridViewTextBoxCell() {Value = "t0"};

            this.Load += MainForm_Load;
            
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex > 0) return;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = $"{row.Index + 1}";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var tst = comboBox1.SelectedItem as Tst;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            var temp = cell.Value as Tst;
        }
    }


    class Tst
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
