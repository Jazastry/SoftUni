using System;
using System.Collections.Generic;

namespace CustomLinkedList.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void ConstructingNewEmptyDynamicListWithNoParametersMustConstructCorrectObject()
        {
            var list = new DynamicList<int>();

            Assert.AreEqual(new DynamicList<int>().GetType(),
                list.GetType(),
                String.Format("Constructing new empty DynamicList consist of Integer values"));
        }

        [TestMethod]
        public void TestAddNodeWithValueOfOneMustCreatCorrectNode()
        {
            var list = new DynamicList<int>();
            list.Add(1);

            Assert.AreEqual(1, list[0]);
        }

        [TestMethod]
        public void TestCountAddingThreeNodesMustCreateThreeNodes()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestAddingNewNodeOnTailPositionEmptyList()
        {
            var list = new DynamicList<int>();
            list.Add(1);

            Assert.AreEqual(1, list[0]);
        }

        [TestMethod]
        public void TestAddingNewNodeOnTailPositionNonEmptyList()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(-1);

            Assert.AreEqual(-1, list[3]);
        }

        [TestMethod]
        public void TestAddingNodeOnSpecifiedPossitionMustAddElementOnSpecifaedPossition()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list[1] = 3;

            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddingNodeOnNonExistingPositivePositionMustThrowArgumentOutOfRangeException()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list[3] = 3;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddingNodeOnNonExistingNegativePositionMustThrowArgumentOutOfRangeException()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list[-1] = 3;
        }

        [TestMethod]
        public void TestRemoveAtMustReduceListLengthAndReturnElementValue()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            int removedElement = list.RemoveAt(2);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, removedElement);
        }

        [TestMethod]
        public void TestRemoveMustRemoveSpecifaedElementRetuirnItsIndexAndReduceLength()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            int removedElementIndex = list.Remove(3);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(false, list.Contains(3));
            Assert.AreEqual(2, removedElementIndex);
        }

        [TestMethod]
        public void TestRemoveNonExistingElementMustReturnMinusOne()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            int removedElementIndex = list.Remove(-1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(-1, removedElementIndex);
        }

        [TestMethod]
        public void TestIndexOfExistingElementMustReturnItsIndex()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            int elementIndex = list.IndexOf(3);

            Assert.AreEqual(2, elementIndex);
        }

        [TestMethod]
        public void TestIndexOfNonExistingElementMustReturnMinusOne()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            int defaultReturnValueOfNotFound = list.IndexOf(-3);

            Assert.AreEqual(-1, defaultReturnValueOfNotFound);
        }

        [TestMethod]
        public void TestContainsExistingElementMustReturnTrue()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            bool returnedValue = list.Contains(3);

            Assert.AreEqual(true, returnedValue);
        }

        [TestMethod]
        public void TestContainsNonElementMustReturnFalse()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            bool returnedValue = list.Contains(-3);

            Assert.AreEqual(false, returnedValue);
        }
    }
}
