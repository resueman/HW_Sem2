using System;
using System.Collections.Generic;

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
            var newMatrix = new T[2 * matrix.GetLength(0), 2 * matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            matrix = newMatrix;
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
    }
}
