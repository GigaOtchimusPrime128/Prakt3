using System;

namespace LibMas
{
    public class LibMas
    {
        public static int MinSrediMax(int[,] mas)
        {
            int mass;
            int[] ma = new int[mas.GetLength(0)];
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                ma[i] = mas[i, 0];
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (ma[i] < mas[i,j])
                    {
                        ma[i] = mas[i,j];
                    }
                }
            }
            mass = ma[0];
            for (int i = 0; i<ma.GetLength(0);i++)
            {
                if (mass > ma[i])
                {
                    mass = ma[i];
                }
            }
            return mass;
        }
    }
}
