using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_07
{
    internal class Estacionamento
    {
        private string nome;
        private int numVagasLivres;
        private string[] vagas;

        public Estacionamento(string nome, int numVagasLivres)
        {
            this.nome = nome;
            this.numVagasLivres = numVagasLivres;
            vagas = new string[numVagasLivres];
        }

        public int GetNumVagasLivres()
        { return numVagasLivres; }

        public int Estacionar(string placa)
        {
            if (numVagasLivres > 0)
            {
                for (int i = 0;  i < vagas.Length; i++)
                {
                    if (vagas[i] == null)
                    {
                        vagas[i] = placa;
                        numVagasLivres--;
                        return i;
                    }
                }
            }
            return -1; 
        }

        public int BuscarNumVaga(string placa)
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == placa)
                    return i;
            }
            return -1;
        }

        public void Retirar(string placa)
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == placa)
                {   
                    vagas[i] = null;
                    numVagasLivres++;
                    break;
                }
            }
        }

        public void ExibirOcupacao()
        {
            for (int i = 0; i < vagas.Length; i++)
            {
                if (vagas[i] == null)
                    Console.WriteLine($"Vaga nº{i+1}: Vazia");
                else
                    Console.WriteLine($"Vaga nº{i+1}: {vagas[i]}");
            }
        }
    }
}
