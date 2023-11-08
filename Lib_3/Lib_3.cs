using Microsoft.Win32;
using System;
using System.Data;
using System.IO;

namespace Lib_3
{
    public static class Lib_3
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                res.Columns.Add("col"+(i+1), typeof(T));
            }
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i,j];
                }
                res.Rows.Add(row);
            }
            return res;
        }
        public static void SaveMass(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        file.WriteLine(mas[i,j]);
                    }
                }
                file.Close();
            }
        }
        public static int[,] OpenMass(int[,] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Dct afqks (*.*) | *.* |Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Сохранение таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int len1 = Convert.ToInt32(file.ReadLine());
                int len2 = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len1,len2];
                for (int i = 0; i < len1; i++)
                {
                    for (int j = 0; j < len2; i++)
                    {
                        mas[i,j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
                return mas;
            }
            else
            {
                if (mas == null)
                {
                    int[,] m = new int[1,1];
                    m[0,0] = 0;
                    return m;
                }
                else
                {
                    return mas;
                }
            }

        }
    }
}
