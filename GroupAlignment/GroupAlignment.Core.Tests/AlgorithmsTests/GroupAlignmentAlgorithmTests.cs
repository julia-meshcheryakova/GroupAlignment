namespace GroupAlignment.Core.Tests.PairAlignmentAlgorithmsTests
{
    using System;

    using GroupAlignment.Core.Algorithms;
    using GroupAlignment.Core.Estimators;
    using GroupAlignment.Core.Models;
    using GroupAlignment.Core.Models.Group;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GroupAlignmentAlgorithmTests
    {
        [TestMethod]
        public void GroupTest1()
        {
            // AACGTAG
            // ATACTAC
            // GACCTAC
            // GTACTTG
            // GTCGTTG
            var groupAlignment =
                new GroupAlignment(
                    new[]
                        {
                            new Sequence(new[] { Nucleotide.A, Nucleotide.A, Nucleotide.C, Nucleotide.G, Nucleotide.T, Nucleotide.A, Nucleotide.G }),
                            new Sequence(new[] { Nucleotide.A, Nucleotide.T, Nucleotide.A, Nucleotide.C, Nucleotide.T, Nucleotide.A, Nucleotide.C }),
                            new Sequence(new[] { Nucleotide.G, Nucleotide.A, Nucleotide.C, Nucleotide.C, Nucleotide.T, Nucleotide.A, Nucleotide.C }),
                            new Sequence(new[] { Nucleotide.G, Nucleotide.T, Nucleotide.A, Nucleotide.C, Nucleotide.T, Nucleotide.T, Nucleotide.G }),
                            new Sequence(new[] { Nucleotide.G, Nucleotide.T, Nucleotide.C, Nucleotide.G, Nucleotide.T, Nucleotide.T, Nucleotide.G })
                        },
                    true);

            var estimator = new OperationDistanceEstimator(4, 2, 0, 1);
            var groupAlgorithm = new GroupAlignmentAlgorithm(estimator);
            groupAlgorithm.Condensate(groupAlignment);
        }

        [TestMethod]
        public void GroupTest2()
        {
            // AACGTNA
            // TACGNAT
            // CCCTTAN
            // CNTAAGG
            // ATTAGCA
            // ATAGCAT
            var groupAlignment =
                new GroupAlignment(
                    new[]
                        {
                            new Sequence(new[] { Nucleotide.A, Nucleotide.A, Nucleotide.C, Nucleotide.G, Nucleotide.T, Nucleotide.N, Nucleotide.A }),
                            new Sequence(new[] { Nucleotide.T, Nucleotide.A, Nucleotide.C, Nucleotide.G, Nucleotide.N, Nucleotide.A, Nucleotide.T }),
                            new Sequence(new[] { Nucleotide.C, Nucleotide.C, Nucleotide.C, Nucleotide.T, Nucleotide.T, Nucleotide.A, Nucleotide.N }),
                            new Sequence(new[] { Nucleotide.C, Nucleotide.N, Nucleotide.T, Nucleotide.A, Nucleotide.A, Nucleotide.G, Nucleotide.G }),
                            new Sequence(new[] { Nucleotide.A, Nucleotide.T, Nucleotide.T, Nucleotide.A, Nucleotide.G, Nucleotide.C, Nucleotide.A }),
                            new Sequence(new[] { Nucleotide.A, Nucleotide.T, Nucleotide.A, Nucleotide.G, Nucleotide.C, Nucleotide.A, Nucleotide.T })
                        },
                    true);

            var estimator = new OperationDistanceEstimator(3, 2, 0, 2);
            var groupAlgorithm = new GroupAlignmentAlgorithm(estimator);
            groupAlgorithm.Condensate(groupAlignment);
        }
    }
}
