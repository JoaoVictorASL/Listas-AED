using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_06
{
    internal class Biblioteca
    {
        private Livro[] acervo;
        private int numLivros;
        const int maxLivros = 50;

        public Biblioteca()
        {
            numLivros = 0;
            acervo = new Livro[maxLivros];
        }

        public bool AdicionarLivro(string titulo, string autor, string editora)
        {
            bool result = false;
            if (numLivros == maxLivros)
            {
                Console.WriteLine("Não foi possivel adicionar o livro!");
                return result;
            }
            else
            {
                for (int i = 0; i <= acervo.Length; i++)
                {
                    if (acervo[i] == null)
                    {
                        acervo[i] = new Livro(titulo, autor, editora);
                        result = true;
                        break;
                    }
                }
                numLivros++;
            }

            return result;
        }

        public bool AdicionarLivroObj(Livro livro)
        {
            bool result = false;
            if (numLivros == maxLivros)
            {
                Console.WriteLine("Não foi possivel adicionar o livro!");
                return result;
            }
            else
            {
                for (int i = 0; i < acervo.Length; i++)
                {
                    if (acervo[i] == null)
                        acervo[i] = livro;
                    break;
                }
                numLivros++;
            }

            return result;
        }

        public Livro RetornarLivro(string titulo)
        {
            for (int i = 0; i < acervo.Length; i++)
            {
                if (acervo[i].Titulo == titulo)
                {
                    return acervo[i];
                }
            }

            return null;
        }

        public string TodosTitulos()
        {
            if (numLivros > 0)
            {
                Console.WriteLine("\nTodos os Livros da Biblioteca: \n");
                for (int i = 0; i < acervo.Length && acervo[i] != null; i++)
                {
                    Console.WriteLine($"{acervo[i].Titulo}");
                }

                return "\nFim!";
            }

            else
                return "Não há livros na Biblioteca!";
        }

        public int NumLivros()
        {
            return numLivros;
        }
    }
}