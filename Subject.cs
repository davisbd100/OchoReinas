using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EigthQueens
{
    public class Subject
    {
        public int[][] Tablero { get; set; }

        public Subject()
        {
            Tablero = new int[8][];
            Tablero[0] = new int[8];
            Tablero[0][7] = 5;
            Tablero[0][6] = 7;
            Tablero[0][2] = 1;
            Tablero[1] = new int[8];
            Tablero[2] = new int[8];
            Tablero[3] = new int[8];
            Tablero[4] = new int[8];
            Tablero[5] = new int[8];
            Tablero[6] = new int[8];
            Tablero[7] = new int[8];
            Console.WriteLine("Longitud del arreglo exterior: " + Tablero.Length + " Longitud del interior: " + Tablero[0].Length);
            FillEmptySpaces(8);
            Console.WriteLine("Longitud del arreglo exterior: " + Tablero.Length + " Longitud del interior: " + Tablero[0].Length);

        }

        public int CalculateAttitudeValue()
        {
            int fitnessValue = 0;
            for (int i = 0; i < Tablero.Length; i++)
            {
                for (int j = 0; j < Tablero[j].Length; j++)
                {
                    if (Tablero[i][j] == 1)
                    {
                        fitnessValue += GetHorizontalCollision(i,j);
                        fitnessValue += GetDiagonalCollision(i,j);
                    }
                }
            }
            return fitnessValue;
        }
        int GetHorizontalCollision(int i, int j)
        {
            int collisionTimes = 0;

            for (int l = j + 1; l < Tablero[i].Length; l++)
            {
                if (Tablero[i][l] == 1)
                {
                    collisionTimes++;
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
        void FillEmptySpaces(int size)
        {
            for (int i = 0; i < size; i++)
            {
                int value = 0;
                for (int j = 0; j < size; j++)
                {
                    bool exist = false;
                    if (Tablero[i][j] == 0)
                    {
                        value++;
                        for (int k = j+1; k < size; k++)
                        {
                            if (Tablero[i][k] == value)
                            {
                                value++;
                                k = j + 1;
                                exist = true;
                            }
                            else
                            {
                                exist = false;
                            }
                        }
                        if (!exist)
                        {
                            Tablero[i][j] = value;
                        }
                    }
                }
            }
        }
    }
}
