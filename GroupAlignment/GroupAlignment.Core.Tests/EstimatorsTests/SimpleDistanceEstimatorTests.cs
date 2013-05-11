
namespace GroupAlignment.Core.Tests.EstimatorsTests
{
    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SimpleDistanceEstimatorTests
    {
        private SimpleDistanceEstimator simpleDistanceEstimator;

        public SimpleDistanceEstimator SimpleDistanceEstimator
        {
            get
            {
                return this.simpleDistanceEstimator ?? (this.simpleDistanceEstimator = new SimpleDistanceEstimator());
            }
        }

        [TestMethod]
        public void SimpleNucleotideDistanceTest()
        {
            Assert.IsTrue(this.SimpleDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide.A) == 0);
            Assert.IsTrue(this.SimpleDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide.C) == 1);
            Assert.IsTrue(this.SimpleDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide.N) == 1);
            Assert.IsTrue(this.SimpleDistanceEstimator.NucleotideDistance(Nucleotide.A, Nucleotide._) == 1);
        }

        [TestMethod]
        public void SimpleDistanceTest()
        {
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
            Assert.IsTrue(SimpleDistanceEstimator.Distance(sequence1, sequence2) == 3);
            Assert.IsTrue(SimpleDistanceEstimator.Distance(sequence1, sequence3) == 4);
            Assert.IsTrue(SimpleDistanceEstimator.Distance(sequence2, sequence3) == 6);
        }
    }
}
