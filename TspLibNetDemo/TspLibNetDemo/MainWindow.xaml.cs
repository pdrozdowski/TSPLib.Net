using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TspLibNet;

namespace TspLibNetDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _libPath = @"..\..\..\..\TSPLIB95";
        private TspLib95 _tspLib;

        public MainWindow()
        {
            CreateTspLib();
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void CreateTspLib()
        {
            // Load all TSPLIB95 instances.
            Console.WriteLine(Directory.GetCurrentDirectory());
            _tspLib = new TspLib95(_libPath);
            _tspLib.LoadAll();
        }

        private void TSPCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = _tspLib.GetItemByName(this.TSPCombo.SelectedItem.ToString(), ProblemType.TSP);
            this.TSPText.Text = item.ToString();
        }

        private void ATSPCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = _tspLib.GetItemByName(this.ATSPCombo.SelectedItem.ToString(), ProblemType.ATSP);
            this.ATSPText.Text = item.ToString();
        }

        private void HCPCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = _tspLib.GetItemByName(this.HCPCombo.SelectedItem.ToString(), ProblemType.HCP);
            this.HCPText.Text = item.ToString();
        }

        private void SOPCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = _tspLib.GetItemByName(this.SOPCombo.SelectedItem.ToString(), ProblemType.SOP);
            this.SOPText.Text = item.ToString();
        }

        private void CVRPCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = _tspLib.GetItemByName(this.CVRPCombo.SelectedItem.ToString(), ProblemType.CVRP);
            this.CVRPText.Text = item.ToString();
        }

        private void PopulateComboBoxes()
        {
            this.TSPCombo.ItemsSource = _tspLib.TSPItems().Select(i => i.Problem.Name);
            this.ATSPCombo.ItemsSource = _tspLib.ATSPItems().Select(i => i.Problem.Name);
            this.HCPCombo.ItemsSource = _tspLib.HCPItems().Select(i => i.Problem.Name);
            this.SOPCombo.ItemsSource = _tspLib.SOPItems().Select(i => i.Problem.Name);
            this.CVRPCombo.ItemsSource = _tspLib.CVRPItems().Select(i => i.Problem.Name);
        }
    }
}