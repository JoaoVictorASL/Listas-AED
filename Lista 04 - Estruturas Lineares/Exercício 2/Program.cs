using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_2
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
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
