using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_04
{
    internal class Program
    {
        static int CalcularMDC(int x, int y)
        {
            int restul;
            if (x == y)
            {
                restul = x;
                return restul;
            }
            else 
            {
                if (x > y) 
                {
                    restul = CalcularMDC(x - y, y);
                }

                else 
                {
                    restul = CalcularMDC(y, x);
                }
            }
            return restul;
        }
        static void Main(string[] args)
        {
            int num1, num2;
            Console.WriteLine("Informe dois valores para calcular o Máximo Divisor Comum entre eles: ");
            Console.Write("\n1º Número: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("2º Número: ");
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nMDC entre {num1} e {num2}: " + CalcularMDC(num1, num2));
            Console.ReadLine();
        }
    }
}
