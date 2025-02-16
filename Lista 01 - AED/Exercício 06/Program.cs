using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titulo;
            Livro livro;
            Biblioteca biblioteca = new Biblioteca();

            biblioteca.AdicionarLivro("1984", "George Orwell", "Companhia das Letras");
            biblioteca.AdicionarLivro("A Menina que Roubava Livros", "Markus Zusak", "Intrínseca");
            biblioteca.AdicionarLivro("O Morro dos Ventos Uivantes", "Emily Brontë", "Martin Claret");
            biblioteca.AdicionarLivro("Dom Casmurro", "Machado de Assis", "Record");

            Console.Write("Informe um Título: ");
            titulo = Console.ReadLine();

            livro = biblioteca.RetornarLivro(titulo);

            if (livro == null)
            {
                Console.WriteLine("\nTitulo não consta na Biblioteca!");
            }

            else
            {
                Console.WriteLine(livro);
            }

            biblioteca.TodosTitulos();
            Console.ReadLine();

        }
    }
}