using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GWhub
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void FileBtn_Click(object sender, EventArgs e)
        {
            ofd.Filter = "TXT|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePathTxt.Text = ofd.FileName;
            }
        }

        private void CurrencyBtn_Click(object sender, EventArgs e)
        {

        }

        private void ArbitrageBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
