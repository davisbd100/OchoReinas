﻿using System;
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
        }
    }
}
