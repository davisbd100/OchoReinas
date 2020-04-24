using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace EigthQueens
{
    public class Population
    {
        public float MutationProbability { get; set; }
        public int PopulationSize { get; set; }
        public int Parents { get; set; }
        public int MaxEval { get; set; }
        public int BoardSize { get; set; }
        public SimplePriorityQueue<Subject> Subjects { get; set; }

        public Population(int populationSize)
        {
            PopulationSize = populationSize;
            Subjects = new SimplePriorityQueue<Subject>();
        }

        public void GenerateRandomPopulation()
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
                Subjects.Enqueue(tempSubject, tempSubject.FitnessValue);
            }
        }
    }
}
