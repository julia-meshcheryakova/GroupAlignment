namespace GroupAlignment.App
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
            this.label1 = new System.Windows.Forms.Label();
            this.cluaterDiameterBound = new System.Windows.Forms.TextBox();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCondesate = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.Label();
            this.gbxResults = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxInput.SuspendLayout();
            this.gbxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cluster diameter bound:";
            // 
            // cluaterDiameterBound
            // 
            this.cluaterDiameterBound.Location = new System.Drawing.Point(130, 28);
            this.cluaterDiameterBound.Name = "cluaterDiameterBound";
            this.cluaterDiameterBound.Size = new System.Drawing.Size(57, 20);
            this.cluaterDiameterBound.TabIndex = 1;
            this.cluaterDiameterBound.Text = "0";
            // 
            // gbxInput
            // 
            this.gbxInput.Controls.Add(this.label7);
            this.gbxInput.Controls.Add(this.label6);
            this.gbxInput.Controls.Add(this.textBox4);
            this.gbxInput.Controls.Add(this.label5);
            this.gbxInput.Controls.Add(this.textBox3);
            this.gbxInput.Controls.Add(this.label4);
            this.gbxInput.Controls.Add(this.textBox2);
            this.gbxInput.Controls.Add(this.label3);
            this.gbxInput.Controls.Add(this.label2);
            this.gbxInput.Controls.Add(this.textBox1);
            this.gbxInput.Controls.Add(this.btnCondesate);
            this.gbxInput.Controls.Add(this.btnOpen);
            this.gbxInput.Controls.Add(this.fileName);
            this.gbxInput.Location = new System.Drawing.Point(12, 12);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(934, 113);
            this.gbxInput.TabIndex = 2;
            this.gbxInput.TabStop = false;
            this.gbxInput.Text = "Input information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Operation estimates:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Delete";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "3";
            // 
            // btnCondesate
            // 
            this.btnCondesate.Location = new System.Drawing.Point(485, 19);
            this.btnCondesate.Name = "btnCondesate";
            this.btnCondesate.Size = new System.Drawing.Size(149, 54);
            this.btnCondesate.TabIndex = 2;
            this.btnCondesate.Text = "Open file";
            this.btnCondesate.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 50);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(101, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.OpenInputFile);
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(6, 34);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(75, 13);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "No file chosen";
            // 
            // gbxResults
            // 
            this.gbxResults.Controls.Add(this.label1);
            this.gbxResults.Controls.Add(this.cluaterDiameterBound);
            this.gbxResults.Location = new System.Drawing.Point(12, 131);
            this.gbxResults.Name = "gbxResults";
            this.gbxResults.Size = new System.Drawing.Size(934, 407);
            this.gbxResults.TabIndex = 4;
            this.gbxResults.TabStop = false;
            this.gbxResults.Text = "Results visualization";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Undefined";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(382, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Equality";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(332, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 20);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Replace";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(282, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(44, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Input file:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 550);
            this.Controls.Add(this.gbxResults);
            this.Controls.Add(this.gbxInput);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNA group alignment application";
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            this.gbxResults.ResumeLayout(false);
            this.gbxResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cluaterDiameterBound;
        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.GroupBox gbxResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCondesate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
    }
}

