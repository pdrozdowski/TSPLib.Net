using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TspLibNet;
using TspLibNet.Defines;

namespace TspLibNetTests
{
    [TestClass]
    public class TspFileLoaderTests
    {
        /*
        [TestMethod]
        public void LoadBerlin52Problem()
        {
            TspFile tspFile;
            TspFileLoader loader = new TspFileLoader();
            using(StreamReader reader = new StreamReader(Samples.Berlin52_Problem))
            {
                tspFile = loader.Load(reader);
                reader.Close();
            }

            Assert.IsNotNull(tspFile);

            Assert.AreEqual("berlin52", tspFile.Name);
            Assert.AreEqual(FileType.TSP, tspFile.Type);
            Assert.AreEqual("52 locations in Berlin (Groetschel)", tspFile.Comment);
            Assert.AreEqual(52, tspFile.Dimension);
            Assert.AreEqual(EdgeWeightType.Euclidean2D, tspFile.EdgeWeightType);
            Assert.AreEqual(52, tspFile.Nodes.Count);

            Assert.AreEqual(1, tspFile.Nodes[0].Id);
            Assert.AreEqual(565.0, tspFile.Nodes[0].X);
            Assert.AreEqual(575.0, tspFile.Nodes[0].Y);

            Assert.AreEqual(2, tspFile.Nodes[1].Id);
            Assert.AreEqual(25.0, tspFile.Nodes[1].X);
            Assert.AreEqual(185.0, tspFile.Nodes[1].Y);

            Assert.AreEqual(52, tspFile.Nodes[51].Id);
            Assert.AreEqual(1740.0, tspFile.Nodes[51].X);
            Assert.AreEqual(245.0, tspFile.Nodes[51].Y);
        }

        [TestMethod]
        public void LoadBerlin52Tour()
        {
            TspFile tspFile;
            TspFileLoader loader = new TspFileLoader();
            using (StreamReader reader = new StreamReader(Samples.Berlin52_Tour))
            {
                tspFile = loader.Load(reader);
                reader.Close();
            }

            Assert.IsNotNull(tspFile);

            Assert.AreEqual("berlin52.opt.tour", tspFile.Name);
            Assert.AreEqual(FileType.Tour, tspFile.Type);
            Assert.AreEqual(52, tspFile.Dimension);
            Assert.AreEqual(52, tspFile.Tour.Count);

            Assert.AreEqual(1, tspFile.Tour[0]);
            Assert.AreEqual(49, tspFile.Tour[1]);
            Assert.AreEqual(22, tspFile.Tour[51]);
        }*/
    }
}
