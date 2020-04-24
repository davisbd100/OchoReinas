using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EigthQueens
{
    public class Population
    {
        public double MutationProbability { get; set; }
        public int PopulationSize { get; set; }
        public int Parents { get; set; }
        public int MaxEval { get; set; }
        public int BoardSize { get; set; }
        public List<Subject> Subjects { get; set; }

        public Population(int populationSize, int boardSize, int maxEval, double mutationProbability, int parents)
        {
            PopulationSize = populationSize;
            BoardSize = boardSize;
            MaxEval = maxEval;
            MutationProbability = mutationProbability;
            Parents = parents;

            Subjects = new List<Subject>();
            GenerateRandomPopulation();
            SelectRandomParent();
        }

        void GenerateRandomPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Subject tempSubject = new Subject(BoardSize);
                Random random = new Random();
                for (int j = 0; j < BoardSize; j++)
                {
                    int var = random.Next(0, BoardSize);
                    tempSubject.SetQueen(j, var);
                }
                tempSubject.FillEmptySpaces();
                Subjects.Add(tempSubject);
            }
        }
        void SelectRandomParent()
        {
            for (int i = 0; i < Parents; i++)
            {
                List<Subject> var = Subjects.OrderBy(a => a.FitnessValue).ToList();
            }
        }
        
    }
}
