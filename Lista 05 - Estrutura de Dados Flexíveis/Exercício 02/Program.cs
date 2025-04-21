using System;
using System.Runtime;

namespace Exercício_01
{
    class Celula
    {
        private int elemento;
        private Celula prox;

        public Celula(int elemento)
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

        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }

    class Pilha
    {
        private Celula topo;

        public Pilha()
        {
            topo = null;
        }

        public void Inserir(int x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
        }

        public int Remover()
        {
            if (topo == null)
                throw new Exception("Erro!");

            int elemento = topo.Elemento;
            topo = topo.Prox;
            return elemento;
        }

        public bool EstaVazia()
        {
            return topo == null;
        }
    }

    internal class Program
    {
        static void ConversaoOctal(int num)
        {
            Pilha pilha = new Pilha();
            while (num > 8)
            {
                int resto = num % 8;
                pilha.Inserir(resto);
                num /= 8;
            }

            Console.Write(num);
            while (!pilha.EstaVazia())
            {
                Console.Write(pilha.Remover());
            }
        }

        static void Main(string[] args)
        {
            int num;
            num = int.Parse(Console.ReadLine());
            ConversaoOctal(num);
        }
    }
}
