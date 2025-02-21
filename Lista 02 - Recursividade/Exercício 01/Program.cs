using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_01
{
    internal class Program
    {
        static int CalcularPotencia(int a, int n)
        {
            int result;

            if (n == 1)
            {
                result = a;
                return result;
            }

            else
            {
                result = a * (CalcularPotencia(a, n - 1));
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Informe um valor para a base: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Informe um valor para a potência: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nResultado: {CalcularPotencia(a, n)}");
            Console.ReadLine();
        }
    }
}
