using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MindboxEx1.Tests
{
    [TestClass]
    public class SequenceBuilderTest
    {
        [TestMethod]
        public void Build_EmptyCollection_ReturnsEmptyCollection()
        {
            var emptyCollection = Enumerable.Empty<Pair<int>>();

            var result = SequenceBuilder.Build(emptyCollection);

            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod]
        public void Build_OneElementCollection_ReturnsOneElementCollection()
        {
            var collection = new Pair<int>[] { new Pair<int> { First = 1, Second = 2 } };

            var result = SequenceBuilder.Build(collection);

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        public void Build_StringCollection_ReturnsSorted()
        {
            var first = new Pair<string> { First = "A", Second = "B" };
            var second = new Pair<string> { First = "B", Second = "C" };
            var third = new Pair<string> { First = "C", Second = "D" };
            var collection = new Pair<string>[] { second, third, first };

            var result = SequenceBuilder.Build(collection).ToArray();

            Assert.AreEqual(first, result[0]);
            Assert.AreEqual(second, result[1]);
            Assert.AreEqual(third, result[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Build_ErrorStringCollection_ThrowsArgumentException()
        {
            var first = new Pair<string> { First = "A", Second = "B" };
            var second = new Pair<string> { First = "B", Second = "C" };
            var third = new Pair<string> { First = "F", Second = "D" }; // unreachable
            var collection = new Pair<string>[] { second, third, first };

            SequenceBuilder.Build(collection);
        }

    }
}
