using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_05
{
    internal class Program
    {
        static int QuantNumNeg(int[] array, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int cont = QuantNumNeg(array, n - 1); 

            if (array[n - 1] < 0) 
                cont++;

            return cont;
        }
        static void Main(string[] args)
        {
            int[] array = { -1, 2, -3, -4, 5 };
            Console.Write("Quantidade de números negativos no vetor: " + QuantNumNeg(array, 5));
            Console.ReadLine();
        }
    }
}
