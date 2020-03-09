using System;
using System.Collections.Generic;
using System.Text;

namespace RedeuNeuralFIrst.src.controller
{
    class RedeNeural
    {
        public int i_nodes { get; set; }
        public int h_nodes { get; set; }
        public int o_nodes { get; set; }

        public Matrix bias_ih { get; set; }
        public Matrix bias_ho { get; set; }
        public Matrix weigth_ih { get; set; }
        public Matrix weigth_ho { get; set; }

        public RedeNeural(int i_nodes, int h_nodes, int o_nodes)
        {
            this.i_nodes = i_nodes;
            this.h_nodes = h_nodes;
            this.o_nodes = o_nodes;

            this.bias_ih = new Matrix(h_nodes, 1);
            this.bias_ih = Matrix.RandomNumber();
            this.bias_ho = new Matrix(o_nodes, 1);
            this.bias_ho = Matrix.RandomNumber();

            this.weigth_ih = new Matrix(h_nodes, i_nodes);
            this.weigth_ih = Matrix.RandomNumber();
            this.weigth_ho = new Matrix(o_nodes, h_nodes);
            this.weigth_ho =  Matrix.RandomNumber();
        }

        public void FeedFoward(int[] arrayInput)
        {

            //INPUT -> HIDDEN
            Matrix input = Matrix.ArrayToMatrix(arrayInput);
            Matrix hidden = Matrix.Mulltiplier(this.weigth_ih, input);
            hidden = Matrix.CalculaBias(hidden, this.bias_ih);            
            hidden = aplicaSigmoid(hidden);

            //HIDDEN -> OUTPUT
            Matrix output = Matrix.Mulltiplier(this.weigth_ho, hidden);
            output = Matrix.CalculaBias(output, this.bias_ho);
            output = aplicaSigmoid(output);
            
            Matrix.ImprimeMatrix(input);
            Matrix.ImprimeMatrix(hidden);
            Matrix.ImprimeMatrix(output);
        }

        public Matrix aplicaSigmoid(Matrix matrix)
        {
            for (int i = 0; i < matrix.array.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.array.GetLength(1); p++)
                {
                    matrix.array[i, p] = sigmoid(matrix.array[i, p]);
                }
            }

            return matrix;
        }

        public double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
