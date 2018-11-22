using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GWhub
{
    public partial class MainForm : Form
    {
        static readonly string IMG_PATH = @"D:\Desktop\GWhub\2018Z_AISD_proj_ind_gr9\output\output.png";

        public MainForm()
        {
            InitializeComponent();
            this.ActiveControl = GraphImg;
        }

        private void FileBtn_Click(object sender, EventArgs e)
        {
            Digraph graph = new Digraph();
            GraphImg.Image = GraphImg.InitialImage;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "TXT|*.txt"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePathTxt.Text = ofd.FileName;
            }

            Parser p = new Parser();
            graph = p.Parse(FilePathTxt.Text);            
            GraphImg.Image = Image.FromFile(graph.SaveGraphAsImg(IMG_PATH));
            GraphImg.Focus();
        }

        private void CurrencyBtn_Click(object sender, EventArgs e)
        {
            Digraph graph = new Digraph();
            Parser p = new Parser();
            graph = p.Parse(FilePathTxt.Text);

            CurrencyVertex from = graph.nodes.Find(x => x.Symbol == FromTxt.Text);
            CurrencyVertex to = graph.nodes.Find(x => x.Symbol == ToTxt.Text);
            double moneyAtSource = double.Parse(ExchangeAmountTxt.Text);
            var exchange = new BestExchange(graph);
            List<CurrencyVertex> path = exchange.Find(from, to, moneyAtSource);

            string result = exchange.PrintOutput(path);
            OutputTxt.Text = result;
            GraphImg.Focus();
        }

        private void ArbitrageBtn_Click(object sender, EventArgs e)
        {
            Digraph graph = new Digraph();
            Parser p = new Parser();
            graph = p.Parse(FilePathTxt.Text);


            double moneyAtSource = double.Parse(ArbitrageAmountTxt.Text);
            var arbitrage = new Arbitrage(graph);
            List<CurrencyVertex> path = arbitrage?.Find(moneyAtSource);
            string result;
            if (path != null)
            {
                result = arbitrage.PrintOutput(path, moneyAtSource); 
            }
            else
            {
                result = "No arbitrage opportunity detected";
            }
            OutputTxt.Text = result;
            GraphImg.Focus();
        }
    }
}