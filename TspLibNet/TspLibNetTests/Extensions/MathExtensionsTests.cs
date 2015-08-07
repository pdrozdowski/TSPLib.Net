using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TspLibNet.Extensions;

namespace TspLibNetTests.Extensions
{
    [TestClass]
    public class MathExtensionsTests
    {
        [TestMethod]
        public void NearestIntCheck()
        {
            Assert.AreEqual(0, MathExtensions.NearestInt(0));
            Assert.AreEqual(0, MathExtensions.NearestInt(0.1));
            Assert.AreEqual(0, MathExtensions.NearestInt(0.2));
            Assert.AreEqual(0, MathExtensions.NearestInt(0.3));
            Assert.AreEqual(0, MathExtensions.NearestInt(0.4));
            Assert.AreEqual(0, MathExtensions.NearestInt(0.49999999));
            Assert.AreEqual(1, MathExtensions.NearestInt(0.50000001));
            Assert.AreEqual(1, MathExtensions.NearestInt(0.6));
            Assert.AreEqual(1, MathExtensions.NearestInt(0.7));
            Assert.AreEqual(1, MathExtensions.NearestInt(0.8));
            Assert.AreEqual(1, MathExtensions.NearestInt(0.9));
            Assert.AreEqual(1, MathExtensions.NearestInt(1.0));
        }

        [TestMethod]
        public void MaxOfThreeCheck()
        {
            Assert.AreEqual(3, MathExtensions.Max(1, 2, 3));
            Assert.AreEqual(3, MathExtensions.Max(1, 3, 2));
            Assert.AreEqual(3, MathExtensions.Max(3, 2, 1));
            Assert.AreEqual(3, MathExtensions.Max(3, 2, 3));
            Assert.AreEqual(3, MathExtensions.Max(3, 3, 3));
            Assert.AreEqual(-1, MathExtensions.Max(-1, -2, -3));
        }
    }
}
