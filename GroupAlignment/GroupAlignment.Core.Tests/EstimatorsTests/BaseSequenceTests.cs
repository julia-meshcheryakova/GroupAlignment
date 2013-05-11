
namespace GroupAlignment.Core.Tests.EstimatorsTests
{
    using GroupAlignment.Core.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseSequenceTests
    {
        [TestMethod]
        public void CompleteSequenceTest()
        {
            var sequence = new BaseSequence
                {
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide._,
                    Nucleotide.G,
                    Nucleotide.N
                };
            var sequenceCompleted = new BaseSequence
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
            sequence = BaseSequence.Complete(sequence, 8);
            CollectionAssert.AreEqual(sequence, sequenceCompleted);
        }

        [TestMethod]
        public void CloneSequenceTest()
        {
            var sequence = new BaseSequence
                {
                    Nucleotide.A,
                    Nucleotide.C,
                    Nucleotide._,
                    Nucleotide.G,
                    Nucleotide.N
                };
            var sequenceCopy = BaseSequence.Complete(sequence, 8);
            CollectionAssert.AreNotEqual(sequence, sequenceCopy);
        }
    }
}
