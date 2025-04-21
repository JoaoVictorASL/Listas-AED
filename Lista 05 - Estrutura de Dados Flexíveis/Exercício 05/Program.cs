using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_7
{
    class Celula
    {
        private double elemento;
        private Celula prox;
        public Celula(double elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }
        public Celula()
        {
            this.elemento = 0;
            this.prox = null;
        }
        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public double Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
    class Lista
    {
        private Celula primeiro, ultimo;
        public Lista()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }
        public void InserirInicio(double x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = primeiro.Prox;
            primeiro.Prox = tmp;
            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            tmp = null;
        }


        public void InserirFim(double x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }
        public double RemoverInicio()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            double elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }

        public double RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            Celula i;
            for (i = primeiro; i.Prox != ultimo; i = i.Prox) ;
            double elemento = ultimo.Elemento;
            ultimo = i;
            i = ultimo.Prox = null;
            return elemento;
        }

        public void Inserir(double x, int pos)
        {
            int tamanho = Tamanho();
            if (pos < 0 || pos > tamanho)
            {
                throw new Exception("Erro!");
            }
            else if (pos == 0)
            {
                InserirInicio(x);
            }
            else if (pos == tamanho)
            {
                InserirFim(x);
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = new Celula(x);
                tmp.Prox = i.Prox;
                i.Prox = tmp;
                tmp = i = null;
            }
        }
        public double Remover(int pos)
        {
            double elemento, tamanho = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tamanho)
            {
                throw new Exception("Erro!");
            }
            else if (pos == 0)
            {
                elemento = RemoverInicio();
            }
            else if (pos == tamanho - 1)
            {
                elemento = RemoverFim();
            }
            else
            {
                Celula i = primeiro;
                for (int j = 0; j < pos; j++, i = i.Prox) ;
                Celula tmp = i.Prox;
                elemento = tmp.Elemento; i.Prox = tmp.Prox;
                tmp.Prox = null; i = tmp = null;
            }
            return elemento;
        }

        public void RemoverItem(double x)
        {
            int posI = 0;
            bool encontrou = false;

            for (Celula i = primeiro.Prox; i != null; i = i.Prox, posI++)
            {
                if (i.Elemento == x)
                {
                    Remover(posI);
                    encontrou = true;
                    break;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Tempo não encontrado.");
            }
        }

        public int Contar(double x)
        {
            int cont = 0;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                if (i.Elemento == x)
                {
                    cont++;
                }
            }
            return cont;
        }
        public void Mostrar()
        {
            int posI = 0;
            for (Celula i = primeiro.Prox; i != null; i = i.Prox, posI++)
            {
                Console.WriteLine(i.Elemento);
            }
        }
        public int Tamanho()
        {
            int tam = 0;
            for (Celula i = primeiro; i != ultimo; i = i.Prox)
            {
                tam++;
            }
            return tam;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
            int op = 0;

            do
            {
                Console.WriteLine("Op:");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        double tempoInicio = double.Parse(Console.ReadLine());
                        lista.InserirInicio(tempoInicio);
                        break;

                    case 2:
                        double tempoFim = double.Parse(Console.ReadLine());
                        lista.InserirFim(tempoFim);
                        break;

                    case 3:
                        double tempo = double.Parse(Console.ReadLine());
                        int pos = int.Parse(Console.ReadLine());
                        lista.Inserir(tempo, pos);
                        break;

                    case 4:
                        Console.WriteLine(lista.RemoverInicio());
                        break;

                    case 5:
                        Console.WriteLine(lista.RemoverFim());
                        break;

                    case 6:
                        int posRemover = int.Parse(Console.ReadLine());
                        Console.WriteLine(lista.Remover(posRemover));
                        break;

                    case 7:
                        double tempoRemover = double.Parse(Console.ReadLine());
                        lista.RemoverItem(tempoRemover);
                        break;

                    case 8:
                        double tempoContar = double.Parse(Console.ReadLine());
                        Console.WriteLine(lista.Contar(tempoContar));
                        break;

                    case 9:
                        lista.Mostrar();
                        break;

                    case 10:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (op != 10);
        }
    }
}

