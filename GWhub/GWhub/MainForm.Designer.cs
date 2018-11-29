namespace GWhub
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OutputTxt = new System.Windows.Forms.TextBox();
            this.CurrencyBtn = new System.Windows.Forms.Button();
            this.ArbitrageBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ToTxt = new System.Windows.Forms.TextBox();
            this.ExchangeAmountTxt = new System.Windows.Forms.TextBox();
            this.ArbitrageAmountTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FileBtn = new System.Windows.Forms.Button();
            this.FilePathTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GraphImg = new System.Windows.Forms.PictureBox();
            this.FromTxt = new System.Windows.Forms.TextBox();
            this.FromLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GraphImg)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputTxt
            // 
            this.OutputTxt.ForeColor = System.Drawing.SystemColors.MenuText;
            this.OutputTxt.Location = new System.Drawing.Point(12, 451);
            this.OutputTxt.Multiline = true;
            this.OutputTxt.Name = "OutputTxt";
            this.OutputTxt.ReadOnly = true;
            this.OutputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputTxt.Size = new System.Drawing.Size(674, 52);
            this.OutputTxt.TabIndex = 0;
            this.OutputTxt.TabStop = false;
            // 
            // CurrencyBtn
            // 
            this.CurrencyBtn.Location = new System.Drawing.Point(504, 186);
            this.CurrencyBtn.Name = "CurrencyBtn";
            this.CurrencyBtn.Size = new System.Drawing.Size(146, 28);
            this.CurrencyBtn.TabIndex = 2;
            this.CurrencyBtn.TabStop = false;
            this.CurrencyBtn.Text = "Exchange currency";
            this.CurrencyBtn.UseVisualStyleBackColor = true;
            this.CurrencyBtn.Click += new System.EventHandler(this.CurrencyBtn_Click);
            // 
            // ArbitrageBtn
            // 
            this.ArbitrageBtn.Location = new System.Drawing.Point(504, 301);
            this.ArbitrageBtn.Name = "ArbitrageBtn";
            this.ArbitrageBtn.Size = new System.Drawing.Size(148, 28);
            this.ArbitrageBtn.TabIndex = 3;
            this.ArbitrageBtn.TabStop = false;
            this.ArbitrageBtn.Text = "Find arbitrage";
            this.ArbitrageBtn.UseVisualStyleBackColor = true;
            this.ArbitrageBtn.Click += new System.EventHandler(this.ArbitrageBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output:";
            // 
            // ToTxt
            // 
            this.ToTxt.Location = new System.Drawing.Point(504, 130);
            this.ToTxt.Name = "ToTxt";
            this.ToTxt.Size = new System.Drawing.Size(146, 22);
            this.ToTxt.TabIndex = 1;
            // 
            // ExchangeAmountTxt
            // 
            this.ExchangeAmountTxt.Location = new System.Drawing.Point(504, 158);
            this.ExchangeAmountTxt.Name = "ExchangeAmountTxt";
            this.ExchangeAmountTxt.Size = new System.Drawing.Size(146, 22);
            this.ExchangeAmountTxt.TabIndex = 2;
            // 
            // ArbitrageAmountTxt
            // 
            this.ArbitrageAmountTxt.Location = new System.Drawing.Point(504, 273);
            this.ArbitrageAmountTxt.Name = "ArbitrageAmountTxt";
            this.ArbitrageAmountTxt.Size = new System.Drawing.Size(146, 22);
            this.ArbitrageAmountTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Amount";
            // 
            // FileBtn
            // 
            this.FileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.FileBtn.Location = new System.Drawing.Point(17, 35);
            this.FileBtn.Name = "FileBtn";
            this.FileBtn.Size = new System.Drawing.Size(80, 29);
            this.FileBtn.TabIndex = 17;
            this.FileBtn.TabStop = false;
            this.FileBtn.Text = "Open File";
            this.FileBtn.UseVisualStyleBackColor = true;
            this.FileBtn.Click += new System.EventHandler(this.FileBtn_Click);
            // 
            // FilePathTxt
            // 
            this.FilePathTxt.Location = new System.Drawing.Point(103, 38);
            this.FilePathTxt.Name = "FilePathTxt";
            this.FilePathTxt.ReadOnly = true;
            this.FilePathTxt.Size = new System.Drawing.Size(583, 22);
            this.FilePathTxt.TabIndex = 18;
            this.FilePathTxt.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(14, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Please select input file:";
            // 
            // GraphImg
            // 
            this.GraphImg.Image = ((System.Drawing.Image)(resources.GetObject("GraphImg.Image")));
            this.GraphImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("GraphImg.InitialImage")));
            this.GraphImg.Location = new System.Drawing.Point(16, 91);
            this.GraphImg.Name = "GraphImg";
            this.GraphImg.Size = new System.Drawing.Size(399, 328);
            this.GraphImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GraphImg.TabIndex = 21;
            this.GraphImg.TabStop = false;
            // 
            // FromTxt
            // 
            this.FromTxt.Location = new System.Drawing.Point(504, 102);
            this.FromTxt.Name = "FromTxt";
            this.FromTxt.Size = new System.Drawing.Size(146, 22);
            this.FromTxt.TabIndex = 0;
            // 
            // FromLbl
            // 
            this.FromLbl.AutoSize = true;
            this.FromLbl.Location = new System.Drawing.Point(435, 105);
            this.FromLbl.Name = "FromLbl";
            this.FromLbl.Size = new System.Drawing.Size(40, 17);
            this.FromLbl.TabIndex = 23;
            this.FromLbl.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(14, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(275, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Graph preview (hq image in output folder):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 515);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FromLbl);
            this.Controls.Add(this.FromTxt);
            this.Controls.Add(this.GraphImg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FilePathTxt);
            this.Controls.Add(this.FileBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArbitrageAmountTxt);
            this.Controls.Add(this.ExchangeAmountTxt);
            this.Controls.Add(this.ToTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArbitrageBtn);
            this.Controls.Add(this.CurrencyBtn);
            this.Controls.Add(this.OutputTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GWhub";
            ((System.ComponentModel.ISupportInitialize)(this.GraphImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutputTxt;
        private System.Windows.Forms.Button CurrencyBtn;
        private System.Windows.Forms.Button ArbitrageBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ToTxt;
        private System.Windows.Forms.TextBox ExchangeAmountTxt;
        private System.Windows.Forms.TextBox ArbitrageAmountTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button FileBtn;
        private System.Windows.Forms.TextBox FilePathTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox GraphImg;
        private System.Windows.Forms.TextBox FromTxt;
        private System.Windows.Forms.Label FromLbl;
        private System.Windows.Forms.Label label6;
    }
}

