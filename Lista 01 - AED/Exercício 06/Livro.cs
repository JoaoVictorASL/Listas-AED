using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_06
{
    internal class Livro
    {
        private string titulo;
        private string autor;
        private string editora;

        public Livro(string titulo, string autor, string editora)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public string Editora
        {
            get { return editora; }
            set { editora = value; }
        }

        public override string ToString()
        {
            return $"\nAutor: {autor}\nEditora: {editora}";
        }


    }
}