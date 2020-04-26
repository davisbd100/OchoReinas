using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EigthQueens
{
    public class Subject
    {
        public int[][] Board { get; set; }
        public int FitnessValue { get; set; }


        public Subject(int size)
        {
            Board = new int[size][];
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = new int[size];
            }
        }

        public void SetQueen(int yPos, int xPos)
        {
            Board[yPos][xPos] = 1;
        }

        public void SetValue(int yPos, int xPos, int value)
        {
            bool Collision = false;
            for (int l = xPos + 1; l < Board[yPos].Length; l++)
            {
                if (Board[yPos][l] == value)
                {
                    int var = Board[yPos][xPos];
                    Board[yPos][xPos] = value;
                    Board[yPos][l] = var;
                    Collision = true;
                    break;
                }
            }
            if (!Collision)
            {
                for (int l = xPos - 1; l > 0; l--)
                {
                    if (Board[yPos][l] == value)
                    {
                        int var = Board[yPos][xPos];
                        Board[yPos][xPos] = value;
                        Board[yPos][l] = var;
                        Collision = true;
                        break;
                    }
                }
            }
        }


        public int CalculateAttitudeValue()
        {
            int fitnessValue = 0;
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board[0].Length; j++)
                {
                    if (Board[i][j] == 1)
                    {
                        fitnessValue += GetVerticalCollision(i,j);
                        fitnessValue += GetDiagonalCollision(i,j);
                    }
                }
            }
            FitnessValue = fitnessValue;
            return fitnessValue;
        }

        int GetVerticalCollision(int i, int j)
        {
            int collisionTimes = 0;

            for (int l = i + 1; l < Board.Length; l++)
            {
                if (Board[l][j] == 1)
                {
                    collisionTimes++;
                }
            }
            return collisionTimes;
        }
        int GetDiagonalCollision(int i, int j)
        {
            int size = Board.Length;
            int collisionTimes = 0;
            int m = i + 1;
            int n = j + 1;
            while (m < size && n < size)
            {
                if (Board[m][n] == 1)
                {
                    collisionTimes++;
                }
                m++;
                n++;
            }
            return collisionTimes;
        }
        public void FillEmptySpaces()
        {
            int size = Board.Length;
            for (int i = 0; i < size; i++)
            {
                int value = 1;
                for (int j = 0; j < size; j++)
                {
                    if (Board[i][0] == value)
                    {
                        value++;
                    }
                    bool exist = false;
                    if (Board[i][j] == 0)
                    {
                        for (int k = j+1; k < size; k++)
                        {
                            if (Board[i][k] == value)
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
                            Board[i][j] = value;
                        }
                        value++;
                    }
                }
            }
            CalculateAttitudeValue();
        }

        override
        public String ToString()
        {
            return FitnessValue.ToString();
        }
    }
}
