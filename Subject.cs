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
            Tablero = new List<List<int>>();
            List<int> temp = new List<int>()
            {
                1,2,3,4,5,6,7,8
            };
            Tablero = new List<List<int>>()
            {
                temp,temp,temp,temp
            };
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

                        //Comprobacion en vertical
                        for (int k = i+1; k < Tablero.Count; k++)
                        {
                            if (Tablero[k][j] == 1)
                            {
                                fitnessValue++;
                            }
                            //Comprobacion en horizontal
                            for (int l = j+1; l < Tablero[i].Count; l++)
                            {
                                if (Tablero[i][l] == 1)
                                {
                                    fitnessValue++;
                                }
                            }
                        }

                        //Comprobacion en diagonal
                        int m = i + 1;
                        int n = j + 1;
                        while (m<4 && n < 4)
                        {
                            if (Tablero[m][n] == 1)
                            {
                                fitnessValue++;
                            }
                            m++;
                            n++;
                        }

                    }
                }
            }
            return fitnessValue;
        }
    }
}
