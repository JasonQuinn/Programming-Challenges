using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem81
{
    class Matrix
    {
        public int[][] IntMatrix { get; private set; }

        public Matrix(int[][] matrix)
        {
            IntMatrix = matrix;
        }

        public int FindMinPath()
        {
            for (var i = 0; i < IntMatrix.Length; i++)
            {
                for (var j = 0; j < IntMatrix[i].Length; j++)
                {
                    if (i == 0)
                    {
                        if (j > 0)
                        {
                            IntMatrix[i][j] = IntMatrix[i][j] + IntMatrix[i][j - 1];
                        }
                    }
                    else
                    {
                        if (j > 0)
                        {
                            IntMatrix[i][j] = IntMatrix[i][j] + Math.Min(IntMatrix[i][j - 1], IntMatrix[i - 1][j]);
                        }
                        else
                        {
                            IntMatrix[i][j] = IntMatrix[i][j] + IntMatrix[i - 1][j];
                        }
                    }
                }
            }
            return IntMatrix.Last().Last();
        }
    }
}
