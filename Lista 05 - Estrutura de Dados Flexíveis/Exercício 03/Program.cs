using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_05
{
    class Celula
    {
        private Arquivo elemento;
        private Celula prox;

        public Celula(Arquivo elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        public Celula()
        {
            this.elemento = null;
            this.prox = null;
        }

        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }

        public Arquivo Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }

    internal class Arquivo
    {
        private string nome;
        private int numPaginas;

        public Arquivo(string nome, int numPaginas)
        {
            this.nome = nome;
            this.numPaginas = numPaginas;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int NumPaginas
        {
            get { return numPaginas; }
            set { numPaginas = value; }
        }
        public override string ToString()
        {
            return $"{nome} {numPaginas}";
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
        public void Inserir(Arquivo x)
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
            Arquivo elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento.Nome;
        }
        public void Listar()
        {
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.WriteLine(i.Elemento);
            }
        }
    }
    internal class Teste
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            string nome;
            int opc, numPaginas;
            Arquivo x;

            do
            {
                Console.WriteLine("Op:");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        nome = Console.ReadLine();
                        numPaginas = int.Parse(Console.ReadLine());
                        x = new Arquivo(nome, numPaginas);
                        fila.Inserir(x);
                        break;

                    case 2:
                        Console.WriteLine(fila.Remover());
                        break;

                    case 3:
                        fila.Listar();
                        break;
                }

            } while (opc != 4);
        }
    }
}
