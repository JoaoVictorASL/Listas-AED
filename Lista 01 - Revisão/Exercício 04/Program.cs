using Exercício_05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCandidatos, votosNulos = 0;
            string nomeCandidato;
            int[] votos = new int[5];
            Console.Write("Informe o número de Candidatos a representante: ");
            numCandidatos = int.Parse(Console.ReadLine());

            Candidato[] candidato = new Candidato[numCandidatos];
            Console.WriteLine("\nInforme o nome dos Candidatos: \n");
            for (int i = 0; i < numCandidatos; i++)
            {
                Console.Write($"Canditado nº {i}: ");
                nomeCandidato = Console.ReadLine();

                candidato[i] = new Candidato(nomeCandidato, i);
            }

            Console.WriteLine("\nInício da Votação: \n");
            for (int i = 0; i < votos.Length; i++)
            {
                Console.Write($"Voto Nº{i+1}:  ");
                votos[i] = int.Parse(Console.ReadLine());

                if (votos[i] > 60 || votos[i] < 0)
                    votosNulos++;

                for (int j = 0; j < votos.Length; j++) 
                {
                    if (votos[i] == candidato[j].Codigo)
                    {
                        candidato[j].Votos++;
                    }
                }
            }

            string maiorCandidato = "";
            int menorCanditado = 0;
            int maisVotos = 0, menosVotos = int.MaxValue;
            for (int i = 0; i < candidato.Length; i++) 
            {
                if (candidato[i].Votos > maisVotos)
                {
                    maisVotos = candidato[i].Votos;
                    maiorCandidato = candidato[i].Nome;
                }

                if (candidato[i].Votos < menosVotos)
                {
                    menosVotos = candidato[i].Votos;
                    menorCanditado = candidato[i].Codigo;
                }
            }

            Console.WriteLine($"\nO Canditado {maiorCandidato} foi o candidato mais votado com {maisVotos} votos!");
            Console.WriteLine($"O Canditado nº{menorCanditado} foi o candidato menos votado com {menosVotos} votos!");
            Console.WriteLine($"A votação obteve {votosNulos} votos nulos!");


            Console.ReadLine();
        }
    }
}
