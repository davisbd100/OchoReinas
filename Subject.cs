using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EigthQueens
{
    public class Subject
    {
        public List<List<int>> Tablero { get; set; }

        public Subject()
        {

        }

        public int CalculateAttitudeValue()
        {
            int fitnessValue = 0;
            for (int i = 0; i < Tablero.Count; i++)
            {
                for (int j = 0; j < Tablero[i].Count; j++)
                {
                    if (Tablero[i][j] == 1)
                    {
                        fitnessValue += GetCrossCollision(i, j);
                        fitnessValue += GetDiagonalCollision(i,j);
                    }
                }
            }
            return fitnessValue;
        }
        int GetCrossCollision(int i, int j)
        {
            int collisionTimes = 0;
            for (int k = i + 1; k < Tablero.Count; k++)
            {
                if (Tablero[k][j] == 1)
                {
                    collisionTimes++;
                }
                for (int l = j + 1; l < Tablero[i].Count; l++)
                {
                    if (Tablero[i][l] == 1)
                    {
                        collisionTimes++;
                    }
                }
            }
            return collisionTimes;
        }
        int GetDiagonalCollision(int i, int j)
        {
            int collisionTimes = 0;
            int m = i + 1;
            int n = j + 1;
            while (m < 8 && n < 8)
            {
                if (Tablero[m][n] == 1)
                {
                    collisionTimes++;
                }
                m++;
                n++;
            }
            return collisionTimes;
        }
    }
}
