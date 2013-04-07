
namespace GroupAlignment.Algorithms.Tests.EstimatorsTests
{
    using GroupAlignment.Algorithms.Estimators;
    using GroupAlignment.Core.Extentions;
    using GroupAlignment.Core.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OperationDistanceEstimatorTests
    {
        private OperationDistanceEstimator operationDistanceEstimator;

        public OperationDistanceEstimator OperationDistanceEstimator
        {
            get
            {
                return this.operationDistanceEstimator ?? (this.operationDistanceEstimator = new OperationDistanceEstimator(4, 2, 0, 1));
            }
        }

        [TestMethod]
        public void OperationNucleotideDistanceTest()
        {
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide.A) == 0);
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide.C) == 2);
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide.N) == 1);
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide._) == 4);
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide.N, Nucleotide.N) == 1);
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide.N, Nucleotide._) == 4);
            Assert.IsTrue(this.OperationDistanceEstimator.NucleotideDistance(Nucleotide._, Nucleotide._) == 0);
        }

        [TestMethod]
        public void OperationDistanceTest()
        {
            // AA_CGCTN_
            // AT_CC_TN_
            // _A_NTCT__
            var sequence1 = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.A,
                    Nucleotide._,
                    Nucleotide.C,
                    Nucleotide.G,
                    Nucleotide.C,
                    Nucleotide.T,
                    Nucleotide.N,
                    Nucleotide._
                };
            var sequence2 = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.T,
                    Nucleotide._,
                    Nucleotide.C,
                    Nucleotide.C,
                    Nucleotide._,
                    Nucleotide.T,
                    Nucleotide.N,
                    Nucleotide._
                }; 
            var sequence3 = new Sequence
                {
                    Nucleotide._,
                    Nucleotide.A,
                    Nucleotide._,
                    Nucleotide.N,
                    Nucleotide.T,
                    Nucleotide.C,
                    Nucleotide.T,
                    Nucleotide._,
                    Nucleotide._
                };
            Assert.IsTrue(this.OperationDistanceEstimator.Distance(sequence1, sequence2) == 9);
            Assert.IsTrue(this.OperationDistanceEstimator.Distance(sequence1, sequence3) == 11);
            Assert.IsTrue(this.OperationDistanceEstimator.Distance(sequence2, sequence3) == 17);
        }
    }
}
