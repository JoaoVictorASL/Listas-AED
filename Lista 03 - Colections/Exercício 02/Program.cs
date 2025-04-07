using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expressao = Console.ReadLine();
            double num1, num2;
            double result;
            Stack<double> Pilha = new Stack<double>();

            for (int i = 0; i < expressao.Length; i++)
            {
                char c = expressao[i];
                double num = Char.GetNumericValue(c);

                if (num >= 0 && num <= 9)
                {
                    Pilha.Push(num);
                }
                else
                {
                    num1 = Pilha.Pop();
                    num2 = Pilha.Pop();

                    if (c == '+')
                        result = num2 + num1;
                    else if (c == '-')
                        result = num2 - num1;
                    else if (c == '*')
                        result = num2 * num1;
                    else
                        result = num2 / num1;

                    Pilha.Push(result);
                }
            }

            result = Pilha.Pop();
            Console.WriteLine(result);
        }
    }
}
