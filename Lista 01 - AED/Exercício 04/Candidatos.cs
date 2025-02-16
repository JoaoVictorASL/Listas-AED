using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_05
{
    internal class Candidato
    {
        private string nome;
        private int codigo;
        private int votos;

        public Candidato(string nome, int codigo)
        {
            this.nome = nome;
            this.codigo = codigo;
            this.votos = 0;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public int Votos
        {
            get { return votos; }
            set { votos = value; }
        }



    }
}
