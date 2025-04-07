using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_01
{
    internal class Lista
    {
        private double[] array;
        private int n;
        public Lista(int tamanho)
        {
            array = new double[tamanho];
            n = 0;
        }
        public void InserirInicio(double x)
        {
            if (n == array.Length)
                throw new Exception("Erro!");
            for (int i = n; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = x;
            n++;
        }
        public void InserirFim(double x)
        {
            if (n == array.Length)
                throw new Exception("Erro!");
            array[n] = x;
            n++;
        }
        public void Inserir(double x, int pos)
        {
            if (n == array.Length || pos < 0 || pos > n)
                throw new Exception("Erro!");
            for (int i = n; i > pos; i--)
            {
                array[i] = array[i - 1];
            }
            array[pos] = x;
            n++;
        }
        public double RemoverInicio()
        {
            if (n == 0)
                throw new Exception("Erro!");
            double resp = array[0];
            n--;
            for (int i = 0; i < n; i++)
            {
                array[i] = array[i + 1];
            }
            return resp;
        }
        public double RemoverFim()
        {
            if (n == 0)
                throw new Exception("Erro!");
            n--;
            return array[n];
        }
        public double Remover(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
                throw new Exception("Erro!");
            double resp = array[pos];
            n--;
            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }
            return resp;
        }

        public void RemoverItem(double x)
        {
            if (n == 0)
                throw new Exception("Erro!");
            bool removido = false;
            for (int i = 0; i < n && !removido; i++)
            {
                if (array[i] == x)
                {
                    Remover(i);
                    removido = true;
                }
            }
        }

        public int Contar(double x)
        {
            if (n == 0)
                return 0;
            int cont = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == x)
                    cont++;
            }
            return cont;
        }
        public void Mostrar()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc, pos;
            double tempo;
            Lista lista = new Lista(10);

            do
            {
                Console.WriteLine("Op:");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            lista.InserirInicio(tempo);
                            break;
                        }
                    case 2:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            lista.InserirFim(tempo);
                            break;
                        }
                    case 3:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            pos = int.Parse(Console.ReadLine());
                            lista.Inserir(tempo, pos);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(lista.RemoverInicio());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine(lista.RemoverFim());
                            break;
                        }
                    case 6:
                        {
                            pos = int.Parse(Console.ReadLine());
                            Console.WriteLine(lista.Remover(pos));
                            break;
                        }
                    case 7:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            lista.RemoverItem(tempo);
                            break;
                        }
                    case 8:
                        {
                            tempo = double.Parse(Console.ReadLine());
                            Console.WriteLine(lista.Contar(tempo));
                            break;
                        }
                    case 9:
                        {
                            lista.Mostrar();
                            break;
                        }
                }

            } while (opc != 10);

        }
    }
}
