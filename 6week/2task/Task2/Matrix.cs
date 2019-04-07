using System;
using System.Collections.Generic;

namespace Task2
{
    class Matrix<T>
    {
        private static T[,] matrix;
        private static readonly int defaultSize = 2;
        private static readonly int resizeIndex = 20;
        public Matrix()
        {
            matrix = new T[defaultSize, defaultSize];
        }
        public T GetValue(int line, int column)
            => matrix[line, column];
        public void SetValue(int line, int column, T value)
        {
            if (line >= matrix.GetLength(0))
            {
                AddLines();
            }
            if (column >= matrix.GetLength(1))
            {
                AddColumns();
            }
            matrix[line, column] = value;
        }
        public void CopyValuesToNewMatrix(T[,] newMatrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            matrix = newMatrix;
        }
        private void AddLines()
        {
            var newMatrix = new T[resizeIndex + matrix.GetLength(0), matrix.GetLength(1)];
            CopyValuesToNewMatrix(newMatrix);
        }
        private void AddColumns()
        {
            var newMatrix = new T[matrix.GetLength(0), resizeIndex + matrix.GetLength(1)];
            CopyValuesToNewMatrix(newMatrix);
        }
    }
}
