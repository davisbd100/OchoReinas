using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EigthQueens
{
    public class GenerationData
    {
        public int GenerationNumber { get; set; }
        public Subject BetterSubject { get; set; }
        public Subject WorstSubject { get; set; }
        public double Media { get; set; }
        public double Median { get; set; }
        public double StandardDeviation { get; set; }

        public GenerationData(int generationNumber, List<Subject> generationList)
        {
            GenerationNumber = generationNumber;
            Media = CalculateMedia(generationList);
            Median = CalculateMedian(generationList);
            StandardDeviation = CalculateStandardDeviation(generationList);
            BetterSubject = generationList.First();
            WorstSubject = generationList.Last();
        }

        double CalculateMedia(List<Subject> generationList)
        {
            double result, sumTotal = 0;
            foreach (var item in generationList)
            {
                sumTotal += item.FitnessValue;
            }
            result = sumTotal / generationList.Count();
            return result;
        }

        double CalculateMedian(List<Subject> generationList)
        {
            double result;
            double listSize = generationList.Count();
            int midNumber = (int) listSize / 2;
            if (IsPar(listSize))
            {
                double numberA = generationList[midNumber - 1].FitnessValue;
                double numberB = generationList[midNumber].FitnessValue;
                result = (numberA + numberB) / 2;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        double CalculateStandardDeviation(List<Subject> generationList)
        {
            double result;
            double sumTotal = 0;
            foreach (var item in generationList)
            {
                double value = (item.FitnessValue - Media);
                value = value * value;
                sumTotal += value;
            }
            result = sumTotal / generationList.Count();
            return result;
        }

        bool IsPar(double number)
        {
            bool result = false;
            if (number % 2 == 0)
            {
                result = true;
            }


            return result;
        }


        public String ToString()
        {
            return ("Numero de Generacion: " + GenerationNumber + ", Media: " + Media + ", Mediana: " + Median +
                ", Valor de aptitud del mejor: " + BetterSubject.FitnessValue + ", Valor de aptitud del peor: " + WorstSubject.FitnessValue);
        }

    }
}
