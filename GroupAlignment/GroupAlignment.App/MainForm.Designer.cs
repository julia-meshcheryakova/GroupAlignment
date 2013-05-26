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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.clusterDiameterBound = new System.Windows.Forms.TextBox();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.replace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.equality = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.undefined = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.TextBox();
            this.btnCondensate = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.Label();
            this.gbxResults = new System.Windows.Forms.GroupBox();
            this.btnClusterize = new System.Windows.Forms.Button();
            this.cbVariants = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupTree = new System.Windows.Forms.TreeView();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.results = new System.Windows.Forms.RichTextBox();
            this.maxDiameter = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbxInput.SuspendLayout();
            this.gbxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cluster diameter bound:";
            // 
            // clusterDiameterBound
            // 
            this.clusterDiameterBound.Location = new System.Drawing.Point(739, 23);
            this.clusterDiameterBound.Name = "clusterDiameterBound";
            this.clusterDiameterBound.Size = new System.Drawing.Size(45, 20);
            this.clusterDiameterBound.TabIndex = 1;
            this.clusterDiameterBound.Text = "0";
            // 
            // gbxInput
            // 
            this.gbxInput.Controls.Add(this.label7);
            this.gbxInput.Controls.Add(this.label6);
            this.gbxInput.Controls.Add(this.replace);
            this.gbxInput.Controls.Add(this.label5);
            this.gbxInput.Controls.Add(this.equality);
            this.gbxInput.Controls.Add(this.label4);
            this.gbxInput.Controls.Add(this.undefined);
            this.gbxInput.Controls.Add(this.label3);
            this.gbxInput.Controls.Add(this.label2);
            this.gbxInput.Controls.Add(this.delete);
            this.gbxInput.Controls.Add(this.btnCondensate);
            this.gbxInput.Controls.Add(this.btnOpen);
            this.gbxInput.Controls.Add(this.fileName);
            this.gbxInput.Location = new System.Drawing.Point(12, 12);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(934, 96);
            this.gbxInput.TabIndex = 2;
            this.gbxInput.TabStop = false;
            this.gbxInput.Text = "Input information";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Replace";
            // 
            // replace
            // 
            this.replace.Location = new System.Drawing.Point(280, 56);
            this.replace.Name = "replace";
            this.replace.Size = new System.Drawing.Size(44, 20);
            this.replace.TabIndex = 11;
            this.replace.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Equality";
            // 
            // equality
            // 
            this.equality.Location = new System.Drawing.Point(330, 56);
            this.equality.Name = "equality";
            this.equality.Size = new System.Drawing.Size(44, 20);
            this.equality.TabIndex = 9;
            this.equality.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Undefined";
            // 
            // undefined
            // 
            this.undefined.Location = new System.Drawing.Point(380, 56);
            this.undefined.Name = "undefined";
            this.undefined.Size = new System.Drawing.Size(44, 20);
            this.undefined.TabIndex = 7;
            this.undefined.Text = "1";
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
            this.label2.Location = new System.Drawing.Point(227, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Delete";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(230, 56);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(44, 20);
            this.delete.TabIndex = 4;
            this.delete.Text = "3";
            // 
            // btnCondensate
            // 
            this.btnCondensate.Location = new System.Drawing.Point(650, 25);
            this.btnCondensate.Name = "btnCondensate";
            this.btnCondensate.Size = new System.Drawing.Size(262, 54);
            this.btnCondensate.TabIndex = 2;
            this.btnCondensate.Text = "Build group alignment";
            this.btnCondensate.UseVisualStyleBackColor = true;
            this.btnCondensate.Click += new System.EventHandler(this.RunGrouping);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 56);
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
            this.fileName.Location = new System.Drawing.Point(6, 40);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(75, 13);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "No file chosen";
            // 
            // gbxResults
            // 
            this.gbxResults.Controls.Add(this.btnClusterize);
            this.gbxResults.Controls.Add(this.cbVariants);
            this.gbxResults.Controls.Add(this.label9);
            this.gbxResults.Controls.Add(this.groupTree);
            this.gbxResults.Controls.Add(this.results);
            this.gbxResults.Controls.Add(this.maxDiameter);
            this.gbxResults.Controls.Add(this.label8);
            this.gbxResults.Controls.Add(this.label1);
            this.gbxResults.Controls.Add(this.clusterDiameterBound);
            this.gbxResults.Location = new System.Drawing.Point(12, 114);
            this.gbxResults.Name = "gbxResults";
            this.gbxResults.Size = new System.Drawing.Size(934, 424);
            this.gbxResults.TabIndex = 4;
            this.gbxResults.TabStop = false;
            this.gbxResults.Text = "Results visualization";
            // 
            // btnClusterize
            // 
            this.btnClusterize.Location = new System.Drawing.Point(803, 20);
            this.btnClusterize.Name = "btnClusterize";
            this.btnClusterize.Size = new System.Drawing.Size(125, 23);
            this.btnClusterize.TabIndex = 13;
            this.btnClusterize.Text = "Cluster";
            this.btnClusterize.UseVisualStyleBackColor = true;
            this.btnClusterize.Click += new System.EventHandler(this.Cluster);
            // 
            // cbVariants
            // 
            this.cbVariants.Enabled = false;
            this.cbVariants.FormattingEnabled = true;
            this.cbVariants.Location = new System.Drawing.Point(279, 23);
            this.cbVariants.Name = "cbVariants";
            this.cbVariants.Size = new System.Drawing.Size(45, 21);
            this.cbVariants.TabIndex = 7;
            this.cbVariants.SelectionChangeCommitted += new System.EventHandler(this.ChangeVariant);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Variant:";
            // 
            // groupTree
            // 
            this.groupTree.ImageIndex = 0;
            this.groupTree.ImageList = this.treeImageList;
            this.groupTree.Location = new System.Drawing.Point(6, 54);
            this.groupTree.Name = "groupTree";
            this.groupTree.SelectedImageIndex = 0;
            this.groupTree.Size = new System.Drawing.Size(318, 364);
            this.groupTree.TabIndex = 5;
            this.groupTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NodeSelected);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "alignment.png");
            this.treeImageList.Images.SetKeyName(1, "dna-icon.png");
            // 
            // results
            // 
            this.results.BackColor = System.Drawing.SystemColors.Window;
            this.results.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.results.Location = new System.Drawing.Point(330, 54);
            this.results.Name = "results";
            this.results.ReadOnly = true;
            this.results.Size = new System.Drawing.Size(598, 364);
            this.results.TabIndex = 4;
            this.results.Text = "";
            // 
            // maxDiameter
            // 
            this.maxDiameter.AutoSize = true;
            this.maxDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxDiameter.Location = new System.Drawing.Point(85, 26);
            this.maxDiameter.Name = "maxDiameter";
            this.maxDiameter.Size = new System.Drawing.Size(88, 13);
            this.maxDiameter.TabIndex = 3;
            this.maxDiameter.Text = "not calculated";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Max diameter:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 550);
            this.Controls.Add(this.gbxResults);
            this.Controls.Add(this.gbxInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.TextBox clusterDiameterBound;
        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.GroupBox gbxResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox delete;
        private System.Windows.Forms.Button btnCondensate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox replace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox equality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox undefined;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox results;
        private System.Windows.Forms.Label maxDiameter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TreeView groupTree;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.ComboBox cbVariants;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClusterize;
    }
}

