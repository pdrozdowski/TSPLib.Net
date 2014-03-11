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
namespace TspLibNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using TspLibNet.Tours;

    /// <summary>
    /// Main class providing access to all TSP library resources.
    /// </summary>
    public class TspLib95
    {
        /// <summary>
        /// Creates new instance of TspLib95 class.
        /// </summary>
        /// <param name="rootPath">library root path</param>
        public TspLib95(string rootPath)
        {
            if (string.IsNullOrEmpty(rootPath))
            {
                throw new ArgumentNullException("rootPath");
            }

            this.RootPath = rootPath;
            this.Items = new List<TspLib95Item>();
        }

        /// <summary>
        /// Gets or sets library root path
        /// </summary>
        public string RootPath { get; protected set; }

        public void Clear()
        {
            this.Items.Clear();
        }

        public int LoadAll()
        {
            int counter = 0;
            counter += this.LoadTSP();
            counter += this.LoadATSP();
            counter += this.LoadHCP();
            counter += this.LoadSOP();
            counter += this.LoadVRP();
            return counter;
        }

        public int LoadTSP()
        {
            return this.LoadTSP("*");
        }

        public int LoadATSP()
        {
            return this.LoadATSP("*");
        }

        public int LoadHCP()
        {
            return this.LoadHCP("*");
        }

        public int LoadSOP()
        {            
            return this.LoadSOP("*");
        }

        public int LoadVRP()
        {
            return this.LoadVRP("*");
        }

        public int LoadTSP(string name)
        {
            return this.ProblemLoader(name, "TravelingSalesmanProblem", ".tsp", "TSP", "bestSolutions.txt", ".opt.tour");
        }

        public int LoadATSP(string name)
        {
            return this.ProblemLoader(name, "TravelingSalesmanProblem",  ".atsp", "ATSP", "bestSolutions.txt", ".opt.tour");
        }

        public int LoadHCP(string name)
        {
            return this.ProblemLoader(name, "HamiltonianCycleProblem", ".hcp", "HCP", "bestSolutions.txt", ".opt.tour");
        }

        public int LoadSOP(string name)
        {
            // do not load best solution, lack of support at the moment
            return this.ProblemLoader(name, "SequentialOrderingProblem", ".sop", "SOP", "????.txt", ".opt.tour");
        }

        public int LoadVRP(string name)
        {
            return this.ProblemLoader(name, "CapacitatedVehicleRoutingProblem", ".vrp", "VRP", "bestSolutions.txt", ".opt.tour");
        }

        protected int ProblemLoader(string name, string type, string extension, string dir, string solutionsFile, string optTourExtension)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            int counter = 0;
            name = name.Replace(extension, "");
            string instancesDir = Path.Combine(this.RootPath, dir);
            string instancePattern = name + extension;
            Dictionary<string, double> solutions = this.LoadBestSolutionsFile(Path.Combine(instancesDir, solutionsFile));
            foreach (string file in Directory.GetFiles(instancesDir, instancePattern))
            {
                IProblem problem = this.FactorizeProblem(file, type);
                ITour tour = null;
                string tourName = file.Replace(extension, optTourExtension);
                if (File.Exists(tourName))
                {
                    tour = Tour.FromFile(tourName);
                }

                double distance = double.MaxValue;
                if (solutions.ContainsKey(problem.Name))
                    distance = solutions[problem.Name];
                this.Items.Add(new TspLib95Item(problem, tour, distance));
                counter++;
            }

            return counter;
        }

        protected IProblem FactorizeProblem(string filename, string type)
        {
            switch (type)
            {
                case "TravelingSalesmanProblem" :
                    return TravelingSalesmanProblem.FromFile(filename);
                case "SequentialOrderingProblem":
                    return SequentialOrderingProblem.FromFile(filename);
                case "CapacitatedVehicleRoutingProblem":
                    return CapacitatedVehicleRoutingProblem.FromFile(filename);
                case "HamiltonianCycleProblem":
                    return HamiltonianCycleProblem.FromFile(filename);
            }

            throw new ArgumentOutOfRangeException("type");
        }

        protected Dictionary<string, double> LoadBestSolutionsFile(string filename)
        {
            Dictionary<string, double> results = new Dictionary<string,double>();
            if (File.Exists(filename))
            {
                foreach (string line in File.ReadAllLines(filename))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] parts = line.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        results.Add(parts[0], double.Parse(parts[1]));
                    }
                }
            }

            return results;
        }

        public List<TspLib95Item> Items { get; protected set; }
    }
}
