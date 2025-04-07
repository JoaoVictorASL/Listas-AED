using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, cont = 1, ant = int.MinValue, maiorSequencia = 0;
            Console.WriteLine("Informe uma sequência: \n");
            ant = int.Parse(Console.ReadLine());

            do
            {
                num = int.Parse(Console.ReadLine());
                if (num > ant)
                {
                    cont++;
                }
                else
                {
                    if (cont > maiorSequencia)
                        maiorSequencia = cont;
                    cont = 1;
                }

                ant = num;

            } while (num != -1);

            Console.WriteLine($"\nA maior sequência foi de {maiorSequencia} números!");
            Console.ReadLine();
        }
    }
}
