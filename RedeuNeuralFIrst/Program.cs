using RedeuNeuralFIrst.src.controller;
using System;

namespace RedeuNeuralFIrst
{
    class Program
    {
        const int linhas = 2;
        const int colunas = 5;

        static void Main(string[] args)
        {
            RedeNeural redeNeural = new RedeNeural(1, 3, 5);

            int[] input = { 1, 2 };
            redeNeural.FeedFoward(input);
        }     
    }
}
