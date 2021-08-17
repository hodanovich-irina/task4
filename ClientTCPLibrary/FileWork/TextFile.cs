using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientTCPLibrary.FileWork
{
    public class TextFile
    {
        public void GetDate(string str, out double[,] a, out double[] b)
        {
            string[] mas = str.Split('\n');
            StringBuilder builderA = new StringBuilder();
            for (int i = 0; i < mas.Length / 2; i++) 
            {
                builderA.Append(mas[i]);
                builderA.Append("\n");
            }
            a = ReadMainMatrix(builderA.ToString());

            StringBuilder builderB = new StringBuilder();
            for (int i = mas.Length / 2 ; i < mas.Length - 1; i++) 
            {
                builderB.Append(mas[i]);
                builderB.Append("\n");
            }
            b = ReadVector(builderB.ToString());
            /*var strB = strA[0, strA.GetLength(1) - 1] + "\n";
            for (int i = 1; i < strA.GetLength(0) - 1; i++)
            {
                strB += strA[i, strA.GetLength(1) - 1] + "\n";
            }
            b = ReadVector(strB);
            double[,] x = new double[strA.GetLength(0), strA.GetLength(1) - 1];
            for (int i = 0; i < strA.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < strA.GetLength(1) - 2; j++)
                {
                    x[i, j] = strA[i,j];
                    // Console.Write(" {0}", a[i, j]);
                }
                //Console.WriteLine();
            }
            a = x;*/

        }
        public string SendMessage(string path1, string path2) 
        {
            string[] str1 = SendMainMatrix(path1).Split('\n'); 
            string[] str2 = SendVector(path2).Split('\n');
            StringBuilder str = new StringBuilder();
            //string str = str1[0] + " " + str2[0] + "\n";

            for (int i = 0; i < str1.Length - 1; i++)
            {
                str.Append(str1[i]);
                str.Append("\n");
                
                //str += str1[i] + " " + str2[i] + "\n";
            }
            for (int i = 0; i < str2.Length - 1; i++)
            {
                str.Append(str2[i]);
                str.Append("\n");

                //str += str1[i] + " " + str2[i] + "\n";
            }
            return str.ToString();
        }
        public string SendMainMatrix(string path)
        {
            StreamReader file = new StreamReader(path);
            string s = file.ReadToEnd();
            file.Close();
            return s;
        }
        //public double[,] ReadMainMatrix(string path)
        public double[,] ReadMainMatrix(string s)
        {
            //StreamReader file = new StreamReader(path);
            //string s = file.ReadToEnd();
            //file.Close();
            string[] str = s.Split('\n');
            string rowL = Regex.Replace(str[0], @"\s+", " ", RegexOptions.None) ;
            rowL = rowL.Substring(1, rowL.Length - 1);
            string[] row = rowL.Split(' ');
            double[,] a = new double[str.Length, row.Length];
            //double t = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                rowL = Regex.Replace(str[i], @"\s+", " ", RegexOptions.None);
                rowL = rowL.Substring(1, rowL.Length - 1);
                row = rowL.Split(' '); 
                for (int j = 0; j < row.Length - 1; j++)
                {
                    a[i, j] = Convert.ToDouble(row[j]);
                   // Console.Write(" {0}", a[i, j]);
                }
                //Console.WriteLine();
            }
            return a;
        }

        public string SendVector(string path)
        {
            StreamReader file = new StreamReader(path);
            string s = file.ReadToEnd();
            file.Close();
            return s;
        }
        public double[] ReadVector(string s) 
        {
            string[] str = s.Split('\n');
            //string element = Regex.Replace(str[0], @"\s+", "", RegexOptions.None);
            double[] b = new double[str.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {
                b[i] = Convert.ToDouble(str[i]);
                //Console.Write(" {0}", b[i]);
            }
            return b;
        }

        /* 

         static double Rezalt(int[,] a)
         {
             int k = 0;
             double s = 0;
             for (int i = 0; i < a.GetLength(0); ++i)
                 for (int j = i + 1; j < a.GetLength(1); ++j)
                     if (a[i, j] % 2 != 0) { ++k; s += a[i, j]; }
             if (k != 0) return s / k;
             else return 0;
         }

         static void Main()
         {
             try
             {
                 int[,] myArray = AddMainMatrix("test1A");
                 Console.WriteLine("Исходный массив:");
                 PrintMainMatrix(myArray);
                 double rez = Rezalt(myArray);
                 Console.WriteLine("Среднее арифметическое ={0:f2}", rez);
             }
             catch (FileNotFoundException)
             {
                 Console.WriteLine(" Файл не найден");
             }
             catch (FormatException)
             {
                 Console.WriteLine(" Неверное значение данных");
             }
             catch (IndexOutOfRangeException)
             {
                 Console.WriteLine(" Выход за границы массива");
             }
        */

    }
}