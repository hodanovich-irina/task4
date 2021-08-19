using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServerTCPLibrary.WorkWithData
{
    /// <summary>
    /// Class for work with data
    /// </summary>
    public class DataProcess
    {
        /// <summary>
        /// Сreating a vector from a string
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>vector</returns>
        public double[] CreateVector(string s)
        {
            string[] str = s.Split('\n');
            double[] b = new double[str.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {
                b[i] = Convert.ToDouble(str[i]);
            }
            return b;
        }

        /// <summary>
        /// Сreating a main matrix from a string
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>main matrix</returns>
        public double[,] CreateMainMatrix(string s)
        {
            string[] str = s.Split('\n');
            string rowL = Regex.Replace(str[0], @"\s+", " ", RegexOptions.None);
            rowL = rowL.Substring(1, rowL.Length - 1);
            string[] row = rowL.Split(' ');
            double[,] a = new double[str.Length, row.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {
                rowL = Regex.Replace(str[i], @"\s+", " ", RegexOptions.None);
                rowL = rowL.Substring(1, rowL.Length - 1);
                row = rowL.Split(' ');
                for (int j = 0; j < row.Length - 1; j++)
                {
                    a[i, j] = Convert.ToDouble(row[j]);
                }
            }
            return a;
        }
        /// <summary>
        /// Method for creating data to send
        /// </summary>
        /// <param name="str">string with data</param>
        /// <param name="a">Main matrix</param>
        /// <param name="b">Vector</param>
        public void GetDate(string str, out double[,] a, out double[] b)
        {
            string[] mas = str.Split('\n');
            StringBuilder builderA = new StringBuilder();
            for (int i = 0; i < mas.Length / 2; i++)
            {
                builderA.Append(mas[i]);
                builderA.Append("\n");
            }
            a = CreateMainMatrix(builderA.ToString());

            StringBuilder builderB = new StringBuilder();
            for (int i = mas.Length / 2; i < mas.Length - 1; i++)
            {
                builderB.Append(mas[i]);
                builderB.Append("\n");
            }
            b = CreateVector(builderB.ToString());
        }
    }
}
