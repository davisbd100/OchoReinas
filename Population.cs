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
        Random random = new Random();

        public Population(int populationSize, int boardSize, int maxEval, double mutationProbability, int parents)
        {
            PopulationSize = populationSize;
            BoardSize = boardSize;
            MaxEval = maxEval;
            MutationProbability = mutationProbability;
            Parents = parents;

            Subjects = new List<Subject>();
            GenerateRandomPopulation();
            OrderList();
            ChildGeneration();
        }

        void GenerateRandomPopulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Subject tempSubject = new Subject(BoardSize);
                for (int j = 0; j < BoardSize; j++)
                {
                    tempSubject.SetQueen(j, random.Next(0, BoardSize));
                }
                tempSubject.FillEmptySpaces();
                Subjects.Add(tempSubject);
            }
        }

        Subject SelectRandomParent()
        {
            return Subjects[random.Next(0, PopulationSize)];
        }


        void ChildGeneration()
        {
            List<Subject> parents = new List<Subject>();
            for (int i = 0; i < Parents; i++)
            {
                parents.Add(SelectRandomParent());
            }
            parents = parents.OrderBy(a => a.FitnessValue).ToList();

            Subject childA = CreateChild(parents[0], parents[1]);
            Subject childB = CreateChild(parents[1], parents[0]);

            if (random.NextDouble() <= MutationProbability)
            {
                childA = Mutate(childA);
            }

            if (random.NextDouble() <= MutationProbability)
            {
                childB = Mutate(childB);
            }

            ReplaceWorst(childA, childB);
        }

        Subject Mutate(Subject child)
        {
            int xPosA = random.Next(0, BoardSize),
                yPosA = random.Next(0, BoardSize),
                xPosB = random.Next(0, BoardSize),
                yPosB = random.Next(0, BoardSize);
            while (yPosA == yPosB)
            {
                xPosA = random.Next(0, BoardSize);
                yPosA = random.Next(0, BoardSize);
                xPosB = random.Next(0, BoardSize);
                yPosB = random.Next(0, BoardSize);
            }
            int valueA = child.Board[yPosA][xPosA];
            int valueB = child.Board[yPosB][xPosB];

            child.SetValue(yPosA, xPosA, valueB);
            child.SetValue(yPosB, xPosB, valueA);

            return child;
        }

        void ReplaceWorst(Subject childA, Subject childB)
        {
            for (int i = 0; i < 2; i++)
            {
                Subjects.Remove(Subjects.Last());
            }
            Subjects.Add(childA);
            Subjects.Add(childB);
            OrderList();
        }

        void OrderList()
        {
            Subjects = Subjects.OrderBy(a => a.FitnessValue).ToList();
        }

        Subject CreateChild(Subject parentA, Subject parentB)
        {
            Subject child = new Subject(BoardSize);
            for (int i = 0; i < BoardSize; i++)
            {
                if (i< BoardSize / 2)
                {
                    child.Board[i] = parentA.Board[i];
                }
                else
                {
                    child.Board[i] = parentB.Board[i];
                }
            }
            child.CalculateAttitudeValue();
            return child;
        }
    }
}
