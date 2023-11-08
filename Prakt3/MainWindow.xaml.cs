using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_3;
using LibMas;

namespace Prakt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] mas1;
        int colich1 = -1;
        int colich2 = -1;
        string stat = "";
        bool bbod = false;
        public void Close(object sender, RoutedEventArgs e)//Закрывает программу
        {//Скобка
            this.Close();//Закрытие окна
        }//Скобка
        int n1 = -1;
        int n2 = -1;
        public void Imputing(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Pole.Text, out int n) == true) //Если ввод данных удачный
            {
                Pole.Text = "";
                if (stat == "")
                {
                    if (n > 1)
                    {
                        bbod = true;
                        stat = "m";
                        n1 = n;
                        Nadpis.Content = "Введите m";
                    }
                    else
                    {
                        Nadpis.Content = "Введи n по мужски";
                    }
                }
                else if (stat == "m")
                {
                    if (n > 1)
                    {
                        stat = "mas";
                        n2 = n;
                        mas1 = new int[n1, n2];
                        Nadpis.Content = "Введите 1 элемент 1 строки массива";
                        colich1 = 0;
                        colich2 = 0;
                    }
                    else
                    {
                        Nadpis.Content = "Введи m по мужски";
                    }
                }
                else if (stat == "mas")
                {
                    mas1[colich1,colich2] = n;
                    colich1 += 1;
                    if (colich1 == mas1.GetLength(0))
                    {
                        colich1 = 0;
                        colich2 += 1;
                    }
                    Nadpis.Content = "Введите " + (colich1 + 1) + " элемент " + (colich2 + 1) + " строки массива";
                    if (colich2 == mas1.GetLength(1))
                    {
                        bbod = false;
                        stat = "";
                        Massiv.ItemsSource = Lib_3.Lib_3.ToDataTable(mas1).DefaultView;
                        SumNad.Content = LibMas.LibMas.MinSrediMax(mas1);
                        Nadpis.Content = "Введите число n";
                    }
                }
                Pole.Focus();
                /*if (!bbod)
                {
                    if (n1 == -1)
                    {
                        n1 = n;
                        Nadpis.Content = "Введите число m";
                        colich1 = -1;
                        colich2 = 0;
                    }
                    else
                    {
                        n2 = n;
                        Nadpis.Content = "Введите 1 элемент 1 строки массива";
                        mas1 = new int[n1, n2];
                        bbod = true;
                    }
                }
                else
                {
                    colich1 += 1;
                    if (colich1 < mas1.GetLength(0))
                    {
                        mas1[colich1, colich2] = n;
                        Nadpis.Content = "Введите " + (colich1 + 1) + " элемент " + (colich2 + 1 ) + " строки массива";
                    }
                    else if (colich1 == mas1.GetLength(0) && colich2<mas1.GetLength(1))
                    {
                        mas1[colich1, colich2] = n;
                        colich1 = 0;
                        colich2 += 1;
                        Nadpis.Content = "Введите " + (colich1 + 1) + " элемент " + (colich2 + 1) + " строки массива";
                        if (colich1 == mas1.GetLength(0) && colich2 == mas1.GetLength(1))
                        {
                            Nadpis.Content = "Введите количество столбцов";
                            Massiv.ItemsSource = Lib_3.Lib_3.ToDataTable(mas1).DefaultView;
                            SumNad.Content = LibMas.LibMas.MinSrediMax(mas1);
                            bbod = false;
                        }
                    }
                }*/
            }
            else
            {
                if (!bbod)
                {
                    if (n1 == -1)
                    { 
                        Nadpis.Content = "Введите ЧИСЛО n";
                    }
                    else
                    {
                        Nadpis.Content = "Введите ЧИСЛО m";
                    }  
                }
                else
                {
                    Nadpis.Content = "Введите " + (colich1 + 1) + " элемент " + (colich2 + 1) + " строки массива";
                }
            }
        }
        public void SvFile(object sender, RoutedEventArgs e)
        {
            if (!bbod)
            {
                Lib_3.Lib_3.SaveMass(mas1);
            }
        }
        public void OpFile(object sender, RoutedEventArgs e)
        {
            if (!bbod)
            {
                mas1 = Lib_3.Lib_3.OpenMass(mas1);
                Massiv.ItemsSource = Lib_3.Lib_3.ToDataTable(mas1).DefaultView;
            }
        }
    }
}
