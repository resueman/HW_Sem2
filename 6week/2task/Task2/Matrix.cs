using System;
using System.Collections.Generic;

namespace Task2
{
    class Matrix<T>
    {
        private static T[,] matrix;
        private static readonly int defaultSize = 2;
        private static readonly int resizeIndex = 20;

        public const int leftBorder = 0;
        public const int topBorder = 0;
        public static int MaxRightBorder { get; private set; } = defaultSize - 1;
        public static int MaxDownBorder { get; private set; } = defaultSize - 1;

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
                Resize(true);
            }
            if (column >= matrix.GetLength(1))
            {
                Resize(false);
            }
            matrix[line, column] = value;
        }
        public void Resize(bool addLines)
        {
            T[,] newMatrix;
            if (addLines)
            {
                newMatrix = new T[resizeIndex + matrix.GetLength(0), matrix.GetLength(1)];
                MaxDownBorder = newMatrix.GetLength(0);
            }
            else
            {
                newMatrix = new T[matrix.GetLength(0), resizeIndex + matrix.GetLength(1)];
                MaxRightBorder = newMatrix.GetLength(1);
            }
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            matrix = newMatrix;
        }
    }
}
