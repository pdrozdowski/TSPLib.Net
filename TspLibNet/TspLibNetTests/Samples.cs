/* The MIT License (MIT)
*
* Copyright (c) 2014 Pawel Drozdowski
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace TspLibNetTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    /// <summary>
    /// This class provides sample problems for testing purposes
    /// </summary>
    public static class Samples
    {
        /// <summary>
        /// Gets Berlin52 problem stream
        /// </summary>
        public static Stream Berlin52_Problem
        {
            get
            {
                MemoryStream stream = new MemoryStream();
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("NAME: berlin52");
                    writer.WriteLine("TYPE: TSP");
                    writer.WriteLine("COMMENT: 52 locations in Berlin (Groetschel)");
                    writer.WriteLine("DIMENSION: 52");
                    writer.WriteLine("EDGE_WEIGHT_TYPE: EUC_2D");
                    writer.WriteLine("NODE_COORD_SECTION");
                    writer.WriteLine("1 565.0 575.0");
                    writer.WriteLine("2 25.0 185.0");
                    writer.WriteLine("3 345.0 750.0");
                    writer.WriteLine("4 945.0 685.0");
                    writer.WriteLine("5 845.0 655.0");
                    writer.WriteLine("6 880.0 660.0");
                    writer.WriteLine("7 25.0 230.0");
                    writer.WriteLine("8 525.0 1000.0");
                    writer.WriteLine("9 580.0 1175.0");
                    writer.WriteLine("10 650.0 1130.0");
                    writer.WriteLine("11 1605.0 620.0 ");
                    writer.WriteLine("12 1220.0 580.0");
                    writer.WriteLine("13 1465.0 200.0");
                    writer.WriteLine("14 1530.0 5.0");
                    writer.WriteLine("15 845.0 680.0");
                    writer.WriteLine("16 725.0 370.0");
                    writer.WriteLine("17 145.0 665.0");
                    writer.WriteLine("18 415.0 635.0");
                    writer.WriteLine("19 510.0 875.0  ");
                    writer.WriteLine("20 560.0 365.0");
                    writer.WriteLine("21 300.0 465.0");
                    writer.WriteLine("22 520.0 585.0");
                    writer.WriteLine("23 480.0 415.0");
                    writer.WriteLine("24 835.0 625.0");
                    writer.WriteLine("25 975.0 580.0");
                    writer.WriteLine("26 1215.0 245.0");
                    writer.WriteLine("27 1320.0 315.0");
                    writer.WriteLine("28 1250.0 400.0");
                    writer.WriteLine("29 660.0 180.0");
                    writer.WriteLine("30 410.0 250.0");
                    writer.WriteLine("31 420.0 555.0");
                    writer.WriteLine("32 575.0 665.0");
                    writer.WriteLine("33 1150.0 1160.0");
                    writer.WriteLine("34 700.0 580.0");
                    writer.WriteLine("35 685.0 595.0");
                    writer.WriteLine("36 685.0 610.0");
                    writer.WriteLine("37 770.0 610.0");
                    writer.WriteLine("38 795.0 645.0");
                    writer.WriteLine("39 720.0 635.0");
                    writer.WriteLine("40 760.0 650.0");
                    writer.WriteLine("41 475.0 960.0");
                    writer.WriteLine("42 95.0 260.0");
                    writer.WriteLine("43 875.0 920.0");
                    writer.WriteLine("44 700.0 500.0");
                    writer.WriteLine("45 555.0 815.0");
                    writer.WriteLine("46 830.0 485.0");
                    writer.WriteLine("47 1170.0 65.0");
                    writer.WriteLine("48 830.0 610.0");
                    writer.WriteLine("49 605.0 625.0");
                    writer.WriteLine("50 595.0 360.0");
                    writer.WriteLine("51 1340.0 725.0");
                    writer.WriteLine("52 1740.0 245.0");
                    writer.WriteLine("EOF");

                    writer.Flush();
                    writer.Close();
                }
                                
                return new MemoryStream(stream.GetBuffer());
            }
        }

        /// <summary>
        /// Gets Berlin52 optimal tour stream
        /// </summary>
        public static Stream Berlin52_Tour
        {
            get
            {
                MemoryStream stream = new MemoryStream();
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("NAME : berlin52.opt.tour");
                    writer.WriteLine("TYPE : TOUR");
                    writer.WriteLine("DIMENSION : 52");
                    writer.WriteLine("TOUR_SECTION");
                    writer.WriteLine("1");
                    writer.WriteLine("49");
                    writer.WriteLine("32");
                    writer.WriteLine("45");
                    writer.WriteLine("19");
                    writer.WriteLine("41");
                    writer.WriteLine("8");
                    writer.WriteLine("9");
                    writer.WriteLine("10");
                    writer.WriteLine("43");
                    writer.WriteLine("33");
                    writer.WriteLine("51");
                    writer.WriteLine("11");
                    writer.WriteLine("52");
                    writer.WriteLine("14");
                    writer.WriteLine("13");
                    writer.WriteLine("47");
                    writer.WriteLine("26");
                    writer.WriteLine("27");
                    writer.WriteLine("28");
                    writer.WriteLine("12");
                    writer.WriteLine("25");
                    writer.WriteLine("4");
                    writer.WriteLine("6");
                    writer.WriteLine("15");
                    writer.WriteLine("5");
                    writer.WriteLine("24");
                    writer.WriteLine("48");
                    writer.WriteLine("38");
                    writer.WriteLine("37");
                    writer.WriteLine("40");
                    writer.WriteLine("39");
                    writer.WriteLine("36");
                    writer.WriteLine("35");
                    writer.WriteLine("34");
                    writer.WriteLine("44");
                    writer.WriteLine("46");
                    writer.WriteLine("16");
                    writer.WriteLine("29");
                    writer.WriteLine("50");
                    writer.WriteLine("20");
                    writer.WriteLine("23");
                    writer.WriteLine("30");
                    writer.WriteLine("2");
                    writer.WriteLine("7");
                    writer.WriteLine("42");
                    writer.WriteLine("21");
                    writer.WriteLine("17");
                    writer.WriteLine("3");
                    writer.WriteLine("18");
                    writer.WriteLine("31");
                    writer.WriteLine("22");
                    writer.WriteLine("-1");
                    writer.WriteLine("EOF");
                    writer.WriteLine("");

                    writer.Flush();
                    writer.Close();
                }

                return new MemoryStream(stream.GetBuffer());
            }
        }
    }
}
