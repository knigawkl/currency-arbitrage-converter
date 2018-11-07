﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
