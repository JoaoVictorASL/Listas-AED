using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Exercício_04
{
    class Fila
    {
        private string[] array;
        private int primeiro, ultimo;
        public Fila(int tamanho)
        {
            array = new string[tamanho + 1];
            primeiro = ultimo = 0;
        }
        public void Inserir(string x)
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
            string resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;
            return resp;
        }

        public void ObterPrimeiro()
        {
            if (primeiro == ultimo)
                Console.WriteLine("fila vazia");
            else
                Console.WriteLine(array[primeiro + 1]);

        }

        public int ObterTamanho()
        {
            int cont = 0;
            if (primeiro == ultimo)
                return cont;
            else
                for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
                    cont++;
            return cont;
        }
        public void Listar()
        {
            for (int i = primeiro; i != ultimo; i = (i + 1) % array.Length)
                Console.WriteLine(array[i]);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila(5);
            int opc;

            do
            {
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        int tamanho = fila.ObterTamanho();
                        Console.WriteLine(tamanho);
                        break;

                    case 2:
                        Console.WriteLine(fila.Remover()); 
                        break;

                    case 3:
                        string identificador = Console.ReadLine();
                        fila.Inserir(identificador);
                        break;

                    case 4:
                        fila.Listar();
                        break;

                    case 5:
                        fila.ObterPrimeiro();
                        break;
                }

            } while (opc != 6);
        }
    }
}
