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

    using GroupAlignment.Core.Algorithms;
    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Extensions;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the group alignment.
        /// </summary>
        public GroupAlignment GroupAlignment { get; set; }

        /// <summary>
        /// Gets or sets the distance estimator.
        /// </summary>
        public AbstractDistanceEstimator DistanceEstimator { get; set; }

        /// <summary>
        /// Gets or sets the group alignment algorithm.
        /// </summary>
        public GroupAlignmentAlgorithm GroupAlignmentAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the cluster diameter bound.
        /// </summary>
        public double ClusterDiameterBound { get; set; }

        /// <summary>
        /// Gets or sets aligned sequences.
        /// </summary>
        public List<MultipleAlignment> ResultsGroups { get; set; }

        /// <summary>
        /// Gets or sets variants.
        /// </summary>
        public List<List<int>> Variants { get; set; }

        /// <summary>
        /// The open input file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
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
                var sequences = new List<Sequence>();
                using (var reader = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sequences.Add(new Sequence(line));
                    }
                }

                this.fileName.Text = Path.GetFileName(openFileDialog.FileName);
                this.GroupAlignment = new GroupAlignment(sequences, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        /// <summary>
        /// Runs grouping.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void RunGrouping(object sender, EventArgs e)
        {
            try
            {
                this.DistanceEstimator = new OperationDistanceEstimator(
                    Convert.ToDouble(this.delete.Text),
                    Convert.ToDouble(this.replace.Text),
                    Convert.ToDouble(this.equality.Text),
                    Convert.ToDouble(this.undefined.Text));

                this.GroupAlignment.ClearAlignment();
                this.GroupAlignmentAlgorithm = new GroupAlignmentAlgorithm(this.DistanceEstimator);
                this.GroupAlignmentAlgorithm.Condensate(this.GroupAlignment);
                this.maxDiameter.Text = string.Format("{0:0.###}", this.GroupAlignment.MaxBound);
                this.FillGroupTree(this.GroupAlignment.Groups.First());
                this.ClusterDiameterBound = this.GroupAlignment.AvgBound;
                this.clusterDiameterBound.Text = string.Format("{0:0.###}", this.ClusterDiameterBound);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check that all operation estimator parameters are double", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The fill group tree.
        /// </summary>
        /// <param name="multipleAlignment">The multiple alignment.</param>
        private void FillGroupTree(MultipleAlignment multipleAlignment)
        {
            this.groupTree.BeginUpdate();
            this.groupTree.Nodes.Clear();
            this.FillGroupTreeNode(this.groupTree.Nodes, multipleAlignment);
            this.groupTree.ExpandAll();
            this.groupTree.EndUpdate();
        }

        /// <summary>
        /// The fill group tree node.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <param name="multipleAlignment">The multiple alignment.</param>
        private void FillGroupTreeNode(TreeNodeCollection nodes, MultipleAlignment multipleAlignment)
        {
            var newNode = new TreeNode();
            var first = multipleAlignment.First;
            var second = multipleAlignment.Second;
            if (!((first == null || first.Count == 0) && (second == null || second.Count == 0)))
            {
                newNode.Text = string.Format("(D = {0},  S = {1})", multipleAlignment.Diameter, multipleAlignment.Size);
                this.FillGroupTreeNode(newNode.Nodes, multipleAlignment.Second);
                this.FillGroupTreeNode(newNode.Nodes, multipleAlignment.First);
            }
            else
            {
                newNode.Text = string.Format("{0} ({1})", multipleAlignment[0].ToString(), multipleAlignment.Id);
                newNode.ImageKey = "dna-icon.png";
                newNode.SelectedImageKey = "dna-icon.png";
            }

            newNode.Tag = multipleAlignment.Id;
            nodes.Add(newNode);
        }

        /// <summary>
        /// Clusters according the set bound.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void Cluster(object sender, EventArgs e)
        {
            try
            {
                this.ClusterDiameterBound = Convert.ToDouble(this.clusterDiameterBound.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Check that all operation estimator parameters are double", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (this.ClusterDiameterBound < 0)
            {
                MessageBox.Show("Invalid value for diameter bound.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.ResultsGroups = new List<MultipleAlignment>();
            this.ResultsGroups.AddRange(this.GroupAlignment.Groups);
            while (this.ResultsGroups.Any(m => m.Diameter > this.ClusterDiameterBound))
            {
                var newGroups = new List<MultipleAlignment>();
                newGroups.AddRange(this.ResultsGroups.Where(m => m.Diameter <= this.ClusterDiameterBound));
                var updating = this.ResultsGroups.Where(m => m.Diameter > this.ClusterDiameterBound).ToList();
                var firsts = updating.Select(m => m.First).ToList();
                var seconds = updating.Select(m => m.Second).ToList();
                newGroups.AddRange(firsts);
                newGroups.AddRange(seconds);
                this.ResultsGroups = newGroups;
            }

            this.SetVariants();
        }

        /// <summary>
        /// The node selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void NodeSelected(object sender, TreeViewEventArgs e)
        {
            var id = (this.groupTree.SelectedNode.Tag as int?).Value;
            this.ResultsGroups = this.GroupAlignment.AllGroups.Where(m => m.Id == id).ToList();
            this.SetVariants();
        }

        /// <summary>
        /// Sets variants.
        /// </summary>
        private void SetVariants()
        {
            this.Variants = new List<List<int>>();
            this.cbVariants.Items.Clear();

            for (var i = 0; i < this.ResultsGroups.Count; i++)
            {
                var resultsGroup = this.ResultsGroups[i];
                var newVariants = new List<List<int>>();
                for (var j = 0; j < resultsGroup.AlignedSequences.Count; j++)
                {
                    if (i == 0)
                    {
                        var variant = new List<int>();
                        variant.Add(j);
                        newVariants.Add(variant);
                    }
                    else
                    {
                        var copy = this.Variants.DeepClone() as List<List<int>>;
                        //copy.AddRange(this.Variants);
                        foreach (var ind in copy)
                        {
                            ind.Add(j);
                        }

                        newVariants.AddRange(copy);
                    }
                }

                this.Variants = newVariants;
            }

            for (var i = 0; i < this.Variants.Count; i++)
            {
                this.cbVariants.Items.Add(i + 1);
            }

            this.ShowAlignment(0);
            this.cbVariants.Enabled = this.Variants.Count > 1;
            this.cbVariants.SelectedIndex = 0;
        }

        /// <summary>
        /// The change variant.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void ChangeVariant(object sender, EventArgs e)
        {
            var variant = (sender as ComboBox).SelectedIndex;
            this.ShowAlignment(variant);
        }

        /// <summary>
        /// Show alignment.
        /// </summary>
        /// <param name="variantIndex">The variant Index.</param>
        private void ShowAlignment(int variantIndex = 0)
        {
            this.results.Clear();
            var variant = this.Variants[variantIndex];
            for (var i = 0; i < this.ResultsGroups.Count; i++)
            {
                var resultsGroup = this.ResultsGroups[i];
                this.results.AppendText(resultsGroup.ToString(variant[i]));
                this.results.AppendText("\n");
            }
        }
    }
}