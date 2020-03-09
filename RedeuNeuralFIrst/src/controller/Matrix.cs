using System;
using System.Collections.Generic;
using System.Text;

namespace RedeuNeuralFIrst.src.controller
{
    class Matrix
    {
        public double[,] array;
        private static int linhas { get; set; }
        private static int colunas { get; set; }
        
        public Matrix(int linha, int coluna)
        {
            this.array = new double[linhas, colunas];
            linhas = linha;
            colunas = coluna;
        }

        static public Matrix ArrayToMatrix(int[] array)
        {
            Matrix matrix = new Matrix(array.Length, 1);
            matrix = new Matrix(array.Length, 1);

            for (int i = 0; i < array.Length; i++)
            {
                matrix.array[i, 0] = array[i];
            }

            return matrix;
        }

        static public Matrix RandomNumber()
        {
            Random random = new Random();
            Matrix matrix = new Matrix(linhas, colunas);
            
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    matrix.array[i, j] = random.NextDouble() * 2 - 1;
                }
            }

            return matrix;
        }

        static public void ImprimeMatrix(Matrix matrix)
        {
            string resultado;
            linhas = matrix.array.GetLength(0);
            colunas = matrix.array.GetLength(1);            

            for (int i = 0; i < linhas; i++)
            {
                resultado = "";

                for (int j = 0; j < colunas; j++)
                {
                    resultado += matrix.array[i, j].ToString() + "     ";
                }

                Console.WriteLine(resultado);
            }

            Console.WriteLine("\n");
        }

        static public Matrix CalculaBias(Matrix m1, Matrix m2)
        {
            Matrix matrix = new Matrix(linhas, colunas);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    matrix.array[i, j] = m1.array[i, j] + m2.array[i, j];
                }
            }

            return matrix;
        }

        static public Matrix Mulltiplier(Matrix m1, Matrix m2)
        {
            linhas = m1.array.GetLength(0);
            colunas = m2.array.GetLength(1);

            Matrix matrix = new Matrix(linhas, colunas);

            try
            {
                double soma = 0;

                for (int linha = 0; linha < linhas; linha++)
                {
                    for (int coluna = 0; coluna < colunas; coluna++)
                    {
                        for (int i = 0; i < colunas; i++)
                        {                     
                            soma += (m1.array[linha, i] * m2.array[i, coluna]);
                        }

                        matrix.array[linha, coluna] = soma;
                        soma = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return matrix;
        }
    }
}
