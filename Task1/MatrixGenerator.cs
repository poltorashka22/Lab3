using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class MatrixGenerator
    {
        private double[,] matrix;


        public MatrixGenerator(int n, int m)
        {
            matrix = new double[n, m];
            FillFirstMatrix(n, m);
        }


        public MatrixGenerator(int n)
        {
            matrix = new double[n, n];
            FillSecondMatrix(n);
        }

        public MatrixGenerator(int n, bool t)
        {
            matrix = new double[n, n];
            FillThirdMatrix(n);
        }

        public MatrixGenerator(int n, string g)
        {
            matrix = new double[n, n];
            FillPositiveMatrix(n);
        }

        public MatrixGenerator(double[,] matrix)
        {
            this.matrix = matrix;
        }


        public double this[int row, int col]
        {
            get => matrix[row, col];
            set => matrix[row, col] = value;
        }

        // Создание первого массива
        private void FillFirstMatrix(int n, int m)
        {
            Console.WriteLine("Введите элементы первого массива:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Введите элемент [{i + 1},{j + 1}]: ");
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        // Создание второго массива
        private void FillSecondMatrix(int n)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j > n - 1) // Элементы выше побочной диагонали
                    {
                        matrix[i, j] = random.NextDouble() * (120 - (-65)) + (-65);
                    }
                    else // Элементы на побочной диагонали и ниже
                    {
                        matrix[i, j] = random.NextDouble() * (10.75 - (-3.5)) + (-3.5);
                    }
                }
            }
        }

        private void FillThirdMatrix(int n)
        {
            matrix = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if ((i + j) < n)
                    {
                        matrix[i, j] = 0.5 * (i + j + 1) * (i + j + 2) + ((i + j) % 2 == 0 ? -j : -i);
                    }
                    else
                    {
                        int p = n - i - 1, q = n - j - 1;
                        matrix[i, j] = 0;
                    }
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        public void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]:F2} ");
                }
                Console.WriteLine();
            }
        }



        public double[,] Matrix => matrix;

        public int GetSize()
        {
            return matrix.GetLength(0);
        }


        // Матрица для задания 2 и 3
        private void FillPositiveMatrix(int n)
        {
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(1, 101); 
                }
            }

        }


        // Метод для задания 2
        public void MaximumElement()
        {

            // Заменяем элементы главной диагонали на 0
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = 0;
            }
            Console.WriteLine("Перед вычислением мы автоматически заменили все элементы гланой диагонали, так как банк не может быть должен сам себе!!!");
            // Находим максимальный элемент в матрице
            double maxElement = double.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    maxElement = Math.Max(maxElement, matrix[i, j]);
                }
            }

            Console.WriteLine($"Максимальная сумма долга: {maxElement}");
        }


        // Методы для задания 3

        public static MatrixGenerator operator -(MatrixGenerator a, MatrixGenerator b)
        {
            int arows = a.matrix.GetLength(0);
            int aсol = a.matrix.GetLength(1);
            int brows = b.matrix.GetLength(0);
            int bcol = b.matrix.GetLength(1);

            if (arows != brows || aсol != bcol)
                throw new ArgumentException(" Для вычисления размер матриц должен совпадать!.");

            double[,] result = new double[aсol, arows];
            for (int i = 0; i < arows; i++)
            {
                for (int j = 0; j < aсol; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return new MatrixGenerator(result);
        }

        public static MatrixGenerator operator *(MatrixGenerator a, MatrixGenerator b)
        {
            int arows = a.matrix.GetLength(0);
            int aсol = a.matrix.GetLength(1);
            int brows = b.matrix.GetLength(0);
            int bcol = b.matrix.GetLength(1);

            if (aсol != brows)
                throw new ArgumentException(" Для вычисления размер матриц должен совпадать!");

            double[,] result = new double[aсol, arows];
            for (int i = 0; i < arows; i++)
            {
                for (int j = 0; j < bcol; j++)
                {
                    for (int k = 0; k < aсol; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return new MatrixGenerator(result);
        }

        public static MatrixGenerator operator *(int scalar, MatrixGenerator a)
        {
            int arows = a.matrix.GetLength(0);
            int aсol = a.matrix.GetLength(1);

            double[,] result = new double[aсol, arows];
            for (int i = 0; i < arows; i++)
            {
                for (int j = 0; j < aсol; j++)
                {
                    result[i, j] = a[i, j] * scalar;
                }
            }
            return new MatrixGenerator(result);
        }

        public MatrixGenerator Transpose()
        {
            int arows = matrix.GetLength(0);
            int aсol = matrix.GetLength(1);

            double[,] result = new double[aсol, arows];
            for (int i = 0; i < arows; i++)
            {
                for (int j = 0; j < aсol; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return new MatrixGenerator(result);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine,
                Enumerable.Range(0, matrix.GetUpperBound(0) + 1)
                    .Select(i => "{" + string.Join("\t", Enumerable.Range(0, matrix.GetUpperBound(1) + 1)
                    .Select(j => matrix[i, j].ToString("F2"))) + "}"));
        }
    }
}

