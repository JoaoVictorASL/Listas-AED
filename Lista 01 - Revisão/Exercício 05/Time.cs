using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_05
{
    internal class Time
    {
        private string nome;
        private Jogador[] titulares;
        private int quantTitulares;
        private Jogador[] reservas;
        private int quantReservas;

        public Time(string nome)
        {
            this.nome = nome;
            this.titulares = new Jogador[11];
            this.quantTitulares = 0;
            this.reservas = new Jogador[12];
            this.quantReservas = 0;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public bool AdicionarTitular(Jogador jogador)
        {
            bool result = false;
            if (quantTitulares >= 11)
                return result;

            else 
                for (int i = 0; i < titulares.Length || result != true; i++)
                {
                    if (titulares[i] == null)
                    {
                        titulares[i] = jogador;
                        quantTitulares++;
                        result = true;
                    }
                }

            return result;
        }

        public bool AdicionarReserva(Jogador jogador)
        {
            bool result = false;
            if (quantReservas >= 12)
                return result;

            else
                for (int i = 0; i < reservas.Length || result != true; i++)
                {
                    if (reservas[i] == null)
                    {
                        reservas[i] = jogador;
                        quantReservas++;
                        result = true;
                    }
                }

            return result;
        }

        public bool SubistituirTitular(string nome, Jogador jogadorNovo)
        {
            bool result = false;
            for (int i = 0; i < titulares.Length && !result; i++)
            {
                if (titulares[i].Nome == nome)
                {
                    titulares[i] = jogadorNovo;
                    result = true;
                }
            }

            return result;
        }

        public bool SubistituirReserva(string nome, Jogador jogadorNovo)
        {
            bool result = false;
            for (int i = 0; i < reservas.Length && !result; i++)
            {
                if (reservas[i].Nome == nome)
                {
                    reservas[i] = jogadorNovo;
                    result = true;
                }
            }

            return result;
        }

        public bool ConsultarTitular(string nome)
        {
            bool result = false;
            for (int i = 0; i < titulares.Length && !result; i++)
            {
                if (titulares[i].Nome == nome)
                    result = true;
            }

            return result;
        }

        public bool ConsultarReserva(string nome)
        {
            bool result = false;
            for (int i = 0; i < reservas.Length && !result; i++)
            {
                if (reservas[i].Nome == nome)
                    result = true;
            }

            return result;
        }

        public bool ExcluirTitular(string nome)
        {
            bool result = false;
            for (int i = 0; i < titulares.Length && !result; i++)
            {
                if (titulares[i].Nome == nome)
                {
                    for (int j = i+1; j < titulares.Length - 1; j++)
                    {
                        titulares[j] = titulares[j + 1];
                    }
                    titulares[titulares.Length - 1] = null;

                    quantTitulares--;
                    result = true;
                }
            }

            return result;
        }

        public bool ExcluirReserva(string nome)
        {
            bool result = false;
            for (int i = 0; i < reservas.Length && !result; i++)
            {
                if (reservas[i].Nome == nome)
                {
                    for (int j = i + 1; j < reservas.Length - 1; j++)
                    {
                        reservas[j] = reservas[j + 1];
                    }
                    reservas[reservas.Length - 1] = null;
                    quantReservas--;
                    result = true;
                }
            }

            return result;
        }

        public bool GerarArqTime(string nomeArq) 
        {
            bool result = false;
            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Time_Atletico.txt");

            try
            {
                StreamWriter arq = new StreamWriter(caminho, true, Encoding.UTF8);

                arq.WriteLine($"Dados dos Jogadores Titulares do Time {nome}:");
                for (int i = 0; i < titulares.Length; i++) 
                {
                    arq.WriteLine($"\nJogador {i + 1}:\n");
                    arq.WriteLine($"Nome: " + titulares[i].Nome);
                    arq.WriteLine($"Número: " + titulares[i].Numero);
                    arq.WriteLine($"Posição: " + titulares[i].Posicao);
                }

                arq.WriteLine($"\nDados dos Jogadores Reservas do Time {nome}:");
                for (int i = 0; i < reservas.Length; i++)
                {
                    arq.WriteLine($"\nJogador {i + 1}:\n");
                    arq.WriteLine($"Nome: " + reservas[i].Nome);
                    arq.WriteLine($"Número: " + reservas[i].Numero);
                    arq.WriteLine($"Posição: " + reservas[i].Posicao);
                }

                arq.Close();
                Console.WriteLine("Fim!");
                    
                result = true;  
                return result;

            } catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return result;
        }
    }
}
