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
        public int FitnessValue { get; set; }


        public Subject()
        {

        }

        public bool SetQueen(int yPos, int xPos)
        {
            bool result;
            if (CheckHorizontalCollision(yPos, xPos, 1))
            {
                result = false;
            }
            else
            {
                Tablero[yPos][xPos] = 1;
                result = true;
            }
            return result;
        }

        public bool SetValue(int yPos, int xPos, int value)
        {
            bool result;
            if (CheckHorizontalCollision(yPos, xPos, value))
            {
                result = false;
            }
            else
            {
                Tablero[yPos][xPos] = value;
                result = true;
            }
            return result;
        }


        public int CalculateAttitudeValue()
        {
            int fitnessValue = 0;
            for (int i = 0; i < Tablero.Length; i++)
            {
                for (int j = 0; j < Tablero[0].Length; j++)
                {
                    if (Tablero[i][j] == 1)
                    {
                        fitnessValue += GetVerticalCollision(i,j);
                        fitnessValue += GetDiagonalCollision(i,j);
                    }
                }
            }
            FitnessValue = fitnessValue;
            return fitnessValue;
        }

        bool CheckHorizontalCollision(int i, int j, int value)
        {
            bool Collision = false;

            for (int l = j + 1; l < Tablero[i].Length; l++)
            {
                if (Tablero[i][l] == value)
                {
                    Collision = true;
                    break;
                }
            }
            if (!Collision)
            {
                for (int l = j - 1; l > 0; l--)
                {
                    if (Tablero[i][l] == value)
                    {
                        Collision = true;
                        break;
                    }
                }
            }
            return Collision;
        }

        int GetVerticalCollision(int i, int j)
        {
            int collisionTimes = 0;

            for (int l = i + 1; l < Tablero.Length; l++)
            {
                if (Tablero[l][j] == 1)
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
