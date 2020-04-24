using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EigthQueens
{
    public class Population
    {
        double MutationProbability { get; set; }
        int PopulationSize { get; set; }
        int Parents { get; set; }
        int MaxEval { get; set; }
        int BoardSize { get; set; }
        List<Subject> Subjects { get; set; }

        public Population(int populationSize, int boardSize, int maxEval, double mutationProbability, int parents)
        {
            PopulationSize = populationSize;
            BoardSize = boardSize;
            MaxEval = maxEval;
            MutationProbability = mutationProbability;
            Parents = parents;

            Subjects = new List<Subject>();
            GenerateRandomPopulation();
            ChildGeneration();
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
                    tempSubject.SetQueen(j, 0);
                }
                tempSubject.FillEmptySpaces();
                Subjects.Add(tempSubject);
                Console.WriteLine(tempSubject.FitnessValue);
            }
        }

        Subject SelectRandomParent()
        {
            Random random = new Random();
            return Subjects[random.Next(0, PopulationSize)];
        }

        public void ChildGeneration()
        {
            List<Subject> parents = new List<Subject>();
            for (int i = 0; i < Parents; i++)
            {
                parents.Add(SelectRandomParent());
            }
            parents = parents.OrderBy(a => a.FitnessValue).ToList();
        }
        
    }
}
