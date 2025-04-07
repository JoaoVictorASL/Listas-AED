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
            int opc, pos;
            double tempo;
            List<double> lista = new List<double>();

            do
            {
                Console.WriteLine("Op:");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            lista.Insert(0, tempo);
                            break;
                        }
                    case 2:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            lista.Add(tempo);
                            break;
                        }
                    case 3:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            pos = int.Parse(Console.ReadLine());
                            lista.Insert(pos, tempo);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(lista[0]);
                            lista.RemoveAt(0);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine(lista[lista.Count - 1]);
                            lista.RemoveAt(lista.Count - 1);
                            break;
                        }
                    case 6:
                        {
                            pos = int.Parse(Console.ReadLine());
                            Console.WriteLine(lista[pos]);
                            lista.RemoveAt(pos);
                            break;
                        }
                    case 7:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            lista.Remove(tempo);
                            break;
                        }
                    case 8:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            int cont = 0;
                            foreach (double c in lista)
                            {
                                if (c == tempo)
                                    cont++;
                            }
                            Console.WriteLine(cont);
                            break;
                        }
                    case 9:
                        {
                            foreach (double c in lista)
                            {
                                Console.WriteLine(c);
                            }
                            break;
                        }
                    case 10:
                        {
                            lista.Sort();
                            foreach (double c in lista)
                            {
                                Console.WriteLine(c);
                            }
                            break;
                        }
                    case 11:
                        {
                            lista.Sort();
                            lista.Reverse();
                            foreach (double c in lista)
                            {
                                Console.WriteLine(c);
                            }
                            break;
                        }
                }

            } while (opc != 12);

        }
    }
}
