using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Wpf;

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
            SetCharts();
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

            for (int i = 0; i < 8; i++)
            {
                int row = (i * 8);
                int value = FirstSubject.Board[i];
                List<Image> images = gridBoard.Children.OfType<Image>().ToList();
                images[row + value].Source = new BitmapImage(new Uri("Resources/Queen.png", UriKind.RelativeOrAbsolute));
            }
        }

        void SetCharts()
        {
            ChartValues<double> standardDeviationChart = new LiveCharts.ChartValues<double>();
            ChartValues<double> mediaChart = new LiveCharts.ChartValues<double>();
            ChartValues<double> bestValueChart = new LiveCharts.ChartValues<double>();
            ChartValues<double> worstValueChart = new LiveCharts.ChartValues<double>();
            foreach (var item in population.Generations)
            {
                standardDeviationChart.Add(item.StandardDeviation);
                mediaChart.Add(item.Media);
                bestValueChart.Add(item.BetterSubject.FitnessValue);
                worstValueChart.Add(item.WorstSubject.FitnessValue);
            }

            SeriesCollection standardDeviationSeries =new SeriesCollection
            {
                new LineSeries
                {
                    Values = standardDeviationChart
                }
            };
            SeriesCollection mediaSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Values = mediaChart
                }
            };
            SeriesCollection bestValueSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Values = bestValueChart
                }
            };
            SeriesCollection worstValueSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Values = worstValueChart
                }
            };

            StandarDeviationChart.Series = standardDeviationSeries;
            MediaChart.Series = mediaSeries;
            BestValueChart.Series = bestValueSeries;
            WorstValueChart.Series = worstValueSeries;
        }
    }
}
