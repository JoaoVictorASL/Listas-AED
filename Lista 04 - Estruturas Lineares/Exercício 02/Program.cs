using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_02
{
    internal class Lista
    {
        private Produto[] array;
        private int n;
        public Lista(int tamanho)
        {
            array = new Produto[tamanho];
            n = 0;
        }
        public void InserirFim(Produto x)
        {
            if (n == array.Length)
                throw new Exception("Erro!");
            array[n] = x;
            n++;
        }
        public Produto Remover(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
                throw new Exception("Erro!");
            Produto resp = array[pos];
            n--;
            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }
            return resp;
        }

        public Produto RemoverItem(string x)
        {
            if (n == 0)
                throw new Exception("Erro!");
            for (int i = 0; i < n; i++)
            {
                if (array[i].Nome == x)
                {
                    return Remover(i);
                }
            }
            return null;
        }

        public bool Pesquisar(string x)
        {
            foreach (Produto c in array)
            {
                if (c.Nome == x)
                {
                    return true;
                }
            }
            return false;
        }

        public void Listar()
        {
            foreach (Produto x in array)
            {
                Console.WriteLine(x);
            }
        }
    }
    internal class Produto
    {
        private string nome;
        private int quant;
        private double preco;

        public Produto(string nome, int quant, double preco)
        {
            this.nome = nome;
            this.quant = quant;
            this.preco = preco;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Quant
        {
            get { return quant; }
            set { quant = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public override string ToString()
        {
            return $"{nome} {quant} {preco}";
        }

    }
    internal class Teste
    {
        static void Main(string[] args)
        {
            int opc, quant;
            string nome;
            double preco;
            Produto produto;
            Lista lista = new Lista(100);

            do
            {
                Console.WriteLine("Op:");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        {
                            nome = Console.ReadLine();
                            quant = int.Parse(Console.ReadLine());
                            preco = double.Parse(Console.ReadLine());
                            produto = new Produto(nome, quant, preco);
                            lista.InserirFim(produto);
                            break;
                        }
                    case 2:
                        {
                            nome = Console.ReadLine();
                            Console.WriteLine(lista.RemoverItem(nome));
                            break;
                        }
                    case 3:
                        {
                            lista.Listar();
                            break;
                        }
                    case 4:
                        {
                            nome = Console.ReadLine();
                            bool encontrado = lista.Pesquisar(nome);
                            if (encontrado == true)
                                Console.WriteLine("produto cadastrado");
                            else
                                Console.WriteLine("produto não cadastrado");
                            break;
                        }
                }

            } while (opc != 5);

        }
    }
}
