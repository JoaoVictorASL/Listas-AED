using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_05
{
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


    internal class Fila
    {
        private Arquivo[] array;
        private int primeiro, ultimo;
        public Fila(int tamanho)
        {
            array = new Arquivo[tamanho + 1];
            primeiro = ultimo = 0;
        }
        public void Inserir(Arquivo x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro!");
            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
        }
        public string Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
            Arquivo resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;
            return resp.Nome;
        }
        public void Listar()
        {
            for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
                Console.WriteLine(array[i]);

        }
    }
    internal class Teste
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila(100);
            string nome;
            int opc, numPaginas;
            Arquivo x;

            do
            {
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
