using System;

namespace Exercício_01
{
    class Celula
    {
        private string elemento;
        private Celula prox;

        public Celula(string elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        public Celula()
        {
            this.elemento = "";
            this.prox = null;
        }

        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public string Elemento
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

        public void Inserir(string x)
        {
            Celula tmp = new Celula(x);
            tmp.Prox = topo;
            topo = tmp;
        }

        public string Remover()
        {
            if (topo == null)
                throw new Exception("Erro!");

            string elemento = topo.Elemento;
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
        static bool VerificarSequencia(string sequencia)
        {
            Pilha pilha = new Pilha();

            foreach (char c in sequencia)
            {
                if (c == '(' || c == '[')
                {
                    pilha.Inserir(c.ToString());
                }
                else if (c == ')' || c == ']')
                {
                    if (pilha.EstaVazia())
                    {
                        return false;
                    }

                    string topo = pilha.Remover();

                    if ((c == ')' && topo != "(") || (c == ']' && topo != "["))
                    {
                        return false;
                    }
                }
            }

            return pilha.EstaVazia();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string sequencia = Console.ReadLine();

                if (string.IsNullOrEmpty(sequencia))
                    break;

                if (VerificarSequencia(sequencia))
                    Console.WriteLine("correta");
                else
                    Console.WriteLine("errada");
            }
        }
    }
}
