using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_02
{
    internal class Program
    {
        static int SomarIntervalo(int m, int n)
        {
            int result;

            if (m == n)
            {
                result = m;
                return result;
            }

            else
            {
                result = m + (SomarIntervalo(m + 1, n));
            }

            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Informe um valor para m: ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Informe um valor para n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nSoma do intervalo entre {m} e {n}: {SomarIntervalo(m, n)}");
            Console.ReadLine();

        }
    }
}
