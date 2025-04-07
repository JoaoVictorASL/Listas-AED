using System;

namespace VerificacaoSequencia
{
    class Pilha
    {
        private char[] array;
        private int topo;

        public Pilha()
        {
            array = new char[100];
            topo = 0;
        }

        public void Empilhar(char elemento)
        {
            if (topo < array.Length)
            {
                array[topo] = elemento;
                topo++;
            }
        }

        public char Desempilhar()
        {
            if (topo > 0)
            {
                topo--;
                return array[topo];
            }
            return '\0';
        }

        public bool EstaVazia()
        {
            return topo == 0;
        }

        public int ObterTamanho()
        {
            return topo;
        }
    }

    class Program
    {
        static bool VerificarSequencia(string sequencia)
        {
            Pilha pilha = new Pilha();

            foreach (char c in sequencia)
            {
                if (c == '(' || c == '[')
                {
                    pilha.Empilhar(c);
                }
                else if (c == ')' || c == ']')
                {
                    if (pilha.EstaVazia())
                    {
                        return false;
                    }

                    char topo = pilha.Desempilhar();

                    if ((c == ')' && topo != '(') || (c == ']' && topo != '['))
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

                if (VerificarSequencia(sequencia))
                {
                    Console.WriteLine("correta");
                }
                else
                {
                    Console.WriteLine("errada");
                }
            }
        }
    }
}
