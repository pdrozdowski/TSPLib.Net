using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using TspLibNet;

namespace TspLibNetTests
{
    [TestClass]
    public class TspLib95Tests
    {
        private const string RootDir = @"..\..\..\..\..\TSPLIB95";

        [TestMethod]
        public void TspLibPathValid()
        {
            var tspLib = new TspLib95(RootDir);
            Assert.IsNotNull(tspLib);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TspLibPathEmpty()
        {
            var tspLib = new TspLib95("");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TspLibPathInvalidDirectory()
        {
            var tspLib = new TspLib95("broken");
        }

        [TestMethod]
        public void LoadNone()
        {
            var tspLib = new TspLib95(RootDir);
            Assert.IsFalse(tspLib.Items.Any());
            Assert.IsFalse(tspLib.ATSPItems().Any());
            Assert.IsFalse(tspLib.TSPItems().Any());
            Assert.IsFalse(tspLib.SOPItems().Any());
            Assert.IsFalse(tspLib.HCPItems().Any());
            Assert.IsFalse(tspLib.CVRPItems().Any());
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void LoadWrongTspDir()
        {
            var tspLib = new TspLib95(Directory.GetCurrentDirectory());
            tspLib.LoadAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadByNameNullDir()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadTSP("");
        }

        [TestMethod]
        public void LoadAllTSP()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadAllTSP();
            var items = tspLib.TSPItems();
            Assert.AreEqual(Enumerable.Count(items), 112);
        }

        [TestMethod]
        public void LoadAllATSP()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadAllATSP();
            var items = tspLib.ATSPItems();
            Assert.AreEqual(Enumerable.Count(items), 19);
        }

        [TestMethod]
        public void LoadAllHCP()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadAllHCP();
            var items = tspLib.HCPItems();
            Assert.AreEqual(Enumerable.Count(items), 9);
        }

        [TestMethod]
        public void LoadAllSOP()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadAllSOP();
            var items = tspLib.SOPItems();
            Assert.AreEqual(Enumerable.Count(items), 41);
        }

        [TestMethod]
        public void LoadAllCVRP()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadAllCVRP();
            var items = tspLib.CVRPItems();
            Assert.AreEqual(Enumerable.Count(items), 16);
        }

        [TestMethod]
        public void GetItemByInvalidName()
        {
            var tspLib = new TspLib95(RootDir);
            tspLib.LoadAllTSP();
            Assert.IsNull(tspLib.GetItemByName("bob", ProblemType.TSP));
            Assert.IsNull(tspLib.GetItemByName("", ProblemType.TSP));
            Assert.IsNull(tspLib.GetItemByName(" ", ProblemType.TSP));
        }
    }
}