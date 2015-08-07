using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TspLibNet.Tours;

namespace TspLibNetTests.Tours
{
    [TestClass]
    public class TourTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_OnNullNameArgument_ThrowsException()
        {
            Tour tour = new Tour(null, "comment", 3, new[] { 1, 2, 3 });
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_DimensionIsNegative_ExcptionThrown()
        {
            Tour tour = new Tour("name", "comment", -1, new[] { 1, 2, 3 });
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_OnNullNodeArgument_ThrowsException()
        {
            Tour tour = new Tour("name", "comment", 3, null);
            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_InitilizesTourProperly()
        {
            Tour tour = new Tour("name", "comment", 3, new[] { 1, 2, 3 });
            Assert.IsNotNull(tour);
            Assert.AreEqual("name", tour.Name);
            Assert.AreEqual("comment", tour.Comment);
            Assert.AreEqual(3, tour.Dimension);
            Assert.AreEqual(3, tour.Nodes.Count);
            Assert.AreEqual(1, tour.Nodes[0]);
            Assert.AreEqual(2, tour.Nodes[1]);
            Assert.AreEqual(3, tour.Nodes[2]);
        }

        [TestMethod]
        public void Constructor_DimensionIsZero_NodeCountTakenAsDimension()
        {
            Tour tour = new Tour("name", "comment", 0, new[] { 1, 2, 3 });
            Assert.IsNotNull(tour);
            Assert.AreEqual("name", tour.Name);
            Assert.AreEqual("comment", tour.Comment);
            Assert.AreEqual(3, tour.Dimension);
            Assert.AreEqual(3, tour.Nodes.Count);
            Assert.AreEqual(1, tour.Nodes[0]);
            Assert.AreEqual(2, tour.Nodes[1]);
            Assert.AreEqual(3, tour.Nodes[2]);
        }
    }
}
