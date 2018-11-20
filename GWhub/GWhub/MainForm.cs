﻿using System;
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

        private void FileBtn_Click(object sender, EventArgs e)
        {
            graph = new Digraph();
            GraphImg.Image = GraphImg.InitialImage;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePathTxt.Text = ofd.FileName;
            }
            Parser p = new Parser();
            graph = p.Parse(FilePathTxt.Text);
            
            GraphImg.Image = Image.FromFile(graph.SaveGraphAsImg(IMG_PATH));
        }

        private void CurrencyBtn_Click(object sender, EventArgs e)
        {
            CurrencyVertex from = graph.nodes.Find(x => x.Symbol == FromTxt.Text);
            CurrencyVertex to = graph.nodes.Find(x => x.Symbol == ToTxt.Text);
            double moneyAtSource = double.Parse(ExchangeAmountTxt.Text);
            var exchange = new BestExchange(graph);
            exchange.Find(from, to, moneyAtSource);
        }

        private void ArbitrageBtn_Click(object sender, EventArgs e)
        {

        }
    }
}