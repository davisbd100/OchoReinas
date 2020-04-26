using System;
using System.Collections.Generic;
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

namespace EigthQueens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Population population;
        public MainWindow()
        {
            InitializeComponent();
            population = new Population(50, 8, 10000, 0.8, 5);
            Console.WriteLine();
            population.StartEvolutionProcess();
            FillGridGenerations();
            Console.WriteLine(population.Generations.Last().ToString());
        }
        void FillGridGenerations()
        {
            gridGenerations.ItemsSource = population.Generations;
        }
    }
}
