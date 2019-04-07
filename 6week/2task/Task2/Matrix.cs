using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Matrix<T>
    {
        private T[,] matrix;
        private static readonly int defaultSize = 2;
        public Matrix()
        {
            matrix = new T[defaultSize, defaultSize];
        }

        private void Resize()
        {
            var newVector = new T[2 * matrix.GetLength(0), 2 * matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    newVector[i, j] = matrix[i, j];
                }
            }
            matrix = newVector;
        }

        public void SetValue(int line, int column, T value)
        {
            if(line >= matrix.GetLength(0) || column >= matrix.GetLength(1))
            {
                Resize();
            }
            matrix[line, column] = value;
        }

        public T GetValue(int line, int column)
            => matrix[line, column];

        public int GetSize()
            => matrix.GetLength(0);
    }
}
