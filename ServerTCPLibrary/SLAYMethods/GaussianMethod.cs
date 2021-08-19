using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCPLibrary.SLAYMethods
{
    /// <summary>
    /// Class for gaussian method
    /// </summary>
    public class GaussianMethod : ISLAY
    {
        /// <summary>
        /// Number row
        /// </summary>
        public int NumRow { get; set; }
        /// <summary>
        /// Number column
        /// </summary>
        public int NumColum { get; set; }
        /// <summary>
        /// Main matrix
        /// </summary>
        public double[,] MainMatrix { get; set; }
        /// <summary>
        /// Vector
        /// </summary>
        public double[] Vector { get; set; }
        /// <summary>
        /// Result
        /// </summary>
        public double[] XResult { get; set; }

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="row">Number row</param>
        /// <param name="colum">Number column</param>
        public GaussianMethod(int row, int colum) 
        {
            NumColum = colum;
            NumRow = row;
            MainMatrix = new double[NumRow, NumColum];
            Vector = new double[NumRow];
            XResult = new double[NumRow];
        }

        /// <summary>
        /// Method for sort main matrix
        /// </summary>
        /// <param name="numSortRow">Number row for sort</param>
        private void SortMethod(int numSortRow) 
        {
            double max = MainMatrix[numSortRow, numSortRow];
            int numMaxEl = numSortRow;
            for (int i = numSortRow + 1; i < NumRow; i++)
            {
                if (MainMatrix[i, numSortRow] > max)
                {
                    max = MainMatrix[i, numSortRow];
                    numMaxEl = i;
                }
            }
            if (numMaxEl > numSortRow)
            {
                double vec = Vector[numMaxEl];
                Vector[numMaxEl] = Vector[numSortRow];
                Vector[numSortRow] = vec;

                for (int i = 0; i < NumColum; i++)
                {
                    vec = MainMatrix[numMaxEl, i];
                    MainMatrix[numMaxEl, i] = MainMatrix[numSortRow, i];
                    MainMatrix[numSortRow, i] = vec;
                }
            }
        }
        /// <summary>
        /// Method for get solution
        /// </summary>
        /// <param name="A">Main matrix</param>
        /// <param name="b">Vector</param>
        /// <returns>XResult</returns>
        public double[] GaussianSolution(double[,] A, double[] b)
        {
            MainMatrix = A;
            Vector = b;
            NumRow = A.GetLength(0);
            NumColum = A.GetLength(1);
            if (NumRow != NumColum)
                throw new Exception("No solution!!!");

            for (int i = 0; i < NumRow - 1; i++)
            {
                SortMethod(i);
                for (int j = i + 1; j < NumRow; j++)
                {
                    if (MainMatrix[i, i] != 0) 
                    {
                        double MultElement = MainMatrix[j, i] / MainMatrix[i, i];
                        for (int z = i; z < NumColum; z++)
                            MainMatrix[j, z] -= MainMatrix[i, z] * MultElement;
                        Vector[j] -= Vector[i] * MultElement;
                    }
                }
            }

            for (int i = NumRow - 2; i >= 0; i--)
            {
                XResult[i] = Vector[i];

                for (int j = NumRow - 2; j > i; j--)
                    XResult[i] -= MainMatrix[i, j] * XResult[j];

                XResult[i] /= MainMatrix[i, i];
                XResult[i] = Math.Round(XResult[i], 1);
            }
            return XResult;
        }
        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            GaussianMethod gaussian = obj as GaussianMethod;
            if (gaussian == null)
                return false;
            if (MainMatrix != gaussian.MainMatrix || NumColum != gaussian.NumColum || NumRow != gaussian.NumRow || Vector != gaussian.Vector || XResult != gaussian.XResult)
                return false;
            return true;
        }
        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return NumColum.ToString();
        }

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            return NumColum;
        }
    }
}
