
namespace GroupAlignment.Core.Tests.EstimatorsTests
{
    using GroupAlignment.Core.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SequenceTests
    {
        [TestMethod]
        public void CompleteSequenceTest()
        {
            var sequence = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide._,
                    Nucleotide.G,
                    Nucleotide.N
                };
            var sequenceCompleted = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide._,
                    Nucleotide.G,
                    Nucleotide.N,
                    Nucleotide._,
                    Nucleotide._,
                    Nucleotide._
                };
            sequence = Sequence.Complete(sequence, 8);
            CollectionAssert.AreEqual(sequence, sequenceCompleted);
        }

        [TestMethod]
        public void CloneSequenceTest()
        {
            var sequence = new Sequence
                {
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide._,
                    Nucleotide.G,
                    Nucleotide.N
                };
            var sequenceCopy = Sequence.Complete(sequence, 8);
            CollectionAssert.AreNotEqual(sequence, sequenceCopy);
        }
    }
}
