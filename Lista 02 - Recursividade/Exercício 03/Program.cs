using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_03
{
    internal class Program
    {
        static void ConversaoBinaria(int n)
        {
            int result = n / 2;
            int resto = n % 2;

            if (result == 0)
            {
                Console.Write(resto);
            }

            else  
            {
                ConversaoBinaria(n / 2);
                Console.Write(resto);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Informe um valor decimal: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\nConvertido para Binário: ");
            ConversaoBinaria(n);
            Console.ReadLine(); 
                
        }
    }
}
