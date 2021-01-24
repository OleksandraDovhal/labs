using System;
using System.Collections.Generic;
using System.Text;

namespace Лаб_3
{
    class MyMatrix
    {     

        private double[,] matrix;

          

        public int Height
        {
            get { return matrix.GetLength(0); }
        }

        public int Width
        {
            get { return matrix.GetLength(1); }
        }

        public int getHeight()
        {
            return matrix.GetLength(0);
        }

        public int getWidth()
        {
            return matrix.GetLength(1);
        }

        public double this[int index_1, int index_2]
        {
            get
            {
                if(Check(index_1, index_2))
                {
                    return matrix[index_1, index_2];
                }
                return 0;
            }

            set
            {
                if(Check(index_1, index_2))
                {
                    matrix[index_1, index_2] = value;
                }
            }
        }

        public double Get(int index_1, int index_2)
        {
            if(Check(index_1, index_2))
            {
                return matrix[index_1, index_2];
            }
            return 0;
        }

        public void Set(int index_1, int index_2, double element)
        {
            if(Check(index_1, index_2))
            {
                matrix[index_1, index_2] = element;
            }
        }
            
        public MyMatrix(double[,] array) 
        {
            matrix = array;
        }

        public MyMatrix(MyMatrix previousMatrix) 
            matrix = previousMatrix.matrix;
        }

        public MyMatrix(double[][] array) 
        {
            matrix = new double[array.Length, array[0].Length];

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[i][j];
                }
            }
        }

        public MyMatrix(string[] str)
        {
            string[] temp = str[0].Split(" ");
            matrix = new double[str.Length, temp.Length];

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                temp = str[i].Split(" ");
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = double.Parse(temp[j]);
                }
            }
        }

          
        public void Print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += matrix[i, j] + " ";
                }

                result += "\n";
            }

            return result;
        }

        public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
        {
            double[,] array = new double[m1.Height, m1.Width];
            for(int i = 0; i < m1.Height; i++)
            {
                for(int j = 0; j < m1.Width; j++)
                {
                    array[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                }
            }
            return new MyMatrix(array);
        }

        public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
        {
            double[,] array = new double[m1.Height, m2.Width];
            for(int i = 0; i < m1.Height; i++)
            {
                for(int j = 0; j < m2.Width; j++)
                {
                    array[i, j] = 0;
                    for(int k = 0; k < m1.Width; k++)
                    {
                        array[i, j] += m1.matrix[i, k] * m2.matrix[j, k];
                    }
                }
            }
            return new MyMatrix(array);
        }

        private bool Check(int index_1, int index_2)
        {
            if(index_1 >= 0 && index_1 < Height && index_2 >= 0 && index_2 < Width)
            {
                return true;
            }
            return false;
        }

        private double[,] GetTransponedArray()
        {
            double[,] array = new double[Height, Width];
            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    array[j, i] = matrix[i, j];
                }
            }
            return array;
        }

        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }

        public void TransponeMe()
        {
            matrix = GetTransponedArray();
        }
    }
}
