using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAYMethodLibrary
{
    public class GaussianMethod : ISLAY
    {
        public int NumRow { get; set; }
        public int NumColum { get; set; }
        public double[,] MainMatrix { get; set; }
        public double[] Vector { get; set; }
        public double[] XResult { get; set; }

        public GaussianMethod(int row, int colum)
        {
            NumColum = colum;
            NumRow = row;
            MainMatrix = new double[NumRow, NumColum];
            Vector = new double[NumRow];
            XResult = new double[NumRow];
        }
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
                XResult[i] = Math.Round(XResult[i], 5);
            }
            return XResult;
        }
    }
}
