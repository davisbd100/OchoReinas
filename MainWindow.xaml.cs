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
        }
        void FillGridGenerations()
        {
            gridGenerations.ItemsSource = null;
            gridGenerations.ItemsSource = population.Generations;
        }

        private void btEvolution_Click(object sender, RoutedEventArgs e)
        {
            population = new Population(int.Parse(tbPopulation.Text), int.Parse(tbBoard.Text), int.Parse(tbEvaluation.Text), double.Parse(tbMutation.Text), int.Parse(tbParents.Text));
            population.StartEvolutionProcess();
            FillGridGenerations();
            if (tbBoard.Text == "8")
            {
                SetBoard();
            }
        }
        void SetBoard()
        {
            Subject FirstSubject = population.ObtainBestSubject();
            foreach (Image item in gridBoard.Children)
            {
                item.Source = null;
            }

            int contImage = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (FirstSubject.Board[j][i] == 1)
                    {
                        int contImage2 = 0;
                        foreach (Image item in gridBoard.Children)
                        {
                            if (contImage2 == contImage)
                            {
                                item.Source = new BitmapImage(new Uri("Resources/Queen.png", UriKind.Relative));
                                break;
                            }
                            contImage2++;
                        }
                    }
                    contImage++;
                }

            }
        }
    }
}
