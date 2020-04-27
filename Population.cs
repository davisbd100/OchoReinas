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
        public int CurrentEvaluation { get; set; }
        List<Subject> Subjects { get; set; }
        static Random random = new Random();
        public List<GenerationData> Generations { get; set; }

        public Population(int populationSize, int boardSize, int maxEval, double mutationProbability, int parents)
        {
            PopulationSize = populationSize;
            BoardSize = boardSize;
            MaxEval = maxEval;
            MutationProbability = mutationProbability;
            Parents = parents;

            Subjects = new List<Subject>();
            Generations = new List<GenerationData>();
            GenerateRandomPopulation();
        }

        void GenerateRandomPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Subject tempSubject = new Subject(BoardSize);
                tempSubject.Board = RandomGenerator();
                tempSubject.CalculateFitnessValue();
                Subjects.Add(tempSubject);
            }
        }

        int[] RandomGenerator()
        {
            int[] result = new int[BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                result[i] = i;
            }
            result = result.OrderBy(x => random.Next()).ToArray();
            return result;
        }

        public Subject ObtainBestSubject()
        {
            Subject subject = Generations.Last().BetterSubject;
            return subject;
        }

        public void StartEvolutionProcess()
        {
        }
    }
}
