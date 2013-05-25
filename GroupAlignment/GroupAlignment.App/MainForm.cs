namespace GroupAlignment.App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenInputFile(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            // openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                Stream myStream = null;
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    fileName.Text = Path.GetFileName(openFileDialog.FileName);
                    using (myStream)
                    {
                        // Insert code to read the stream here.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
}
