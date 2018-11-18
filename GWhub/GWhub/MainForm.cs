using System;
using System.Drawing;
using System.Windows.Forms;

namespace GWhub
{
    public partial class MainForm : Form
    {
        static readonly string IMG_PATH = @"D:\Desktop\GWhub\2018Z_AISD_proj_ind_gr9\output\output.png";

        Digraph graph;

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

            Parser p = new Parser();
            graph = p.Parse(FilePathTxt.Text);
            graph.SaveGraphAsImg(IMG_PATH);
            GraphImg.Image = Image.FromFile(IMG_PATH);
            GraphImg.Invalidate();
        }

        private void CurrencyBtn_Click(object sender, EventArgs e)
        {

        }

        private void ArbitrageBtn_Click(object sender, EventArgs e)
        {
            double arbitrageAmount = double.Parse(ArbitrageAmountTxt.Text);
            ArbitrageFinder af = new ArbitrageFinder(graph, arbitrageAmount);
            var result = af.PrintCycle();
            OutputTxt.Text = result;
        }
    }
}