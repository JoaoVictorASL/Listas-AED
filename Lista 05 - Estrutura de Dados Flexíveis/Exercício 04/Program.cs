using System;

namespace Exercício_04
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

    class Fila
    {
        private Celula primeiro, ultimo;

        public Fila()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public void Inserir(string x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }

        public string Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            string elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }

        public void Listar()
        {
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento);
            }
        }

        public bool Pesquisar(string nome)
        {
            bool result = false;
            for (Celula i = primeiro.Prox; i != null && !result; i = i.Prox)
            {
                if (i.Elemento == nome)
                {
                    result = true;
                }
            }
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Fila filaIC = new Fila();
            Fila filaM = new Fila();
            int opc;
            string nome;

            do
            {
                Console.WriteLine("Op:");
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opc))
                {
                    Console.WriteLine("Opção inválida. Digite um número.");
                    continue;
                }

                switch (opc)
                {
                    case 1:
                        nome = Console.ReadLine();
                        filaIC.Inserir(nome);
                        break;

                    case 2:
                        nome = Console.ReadLine();
                        filaM.Inserir(nome);
                        break;

                    case 3:
                        Console.WriteLine(filaIC.Remover());
                        break;

                    case 4:
                        Console.WriteLine(filaM.Remover());
                        break;

                    case 5:
                        filaIC.Listar();
                        break;

                    case 6:
                        filaM.Listar();
                        break;

                    case 7:
                        nome = Console.ReadLine();
                        Console.WriteLine(filaIC.Pesquisar(nome) ? "S" : "N");
                        break;

                    case 8:
                        nome = Console.ReadLine();
                        Console.WriteLine(filaM.Pesquisar(nome) ? "S" : "N");
                        break;
                }

            } while (opc != 9);
        }
    }
}
