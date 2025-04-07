using System;

namespace Exercício_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, countIntersecao = 0, countDiferenca = 0, countUniao = 0;

            Console.Write("Informe o tamanho dos vetores: ");
            n = int.Parse(Console.ReadLine());

            int[] vetX = new int[n];
            int[] vetY = new int[n];
            int[] somas = new int[n];
            int[] produtos = new int[n];
            int[] diferenca = new int[n];
            int[] intersecao = new int[n];
            int[] uniao = new int[n * 2]; 

            Console.WriteLine("\nInforme os valores do vetor X: ");
            for (int i = 0; i < n; i++)
            {
                vetX[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("\nInforme os valores do vetor Y: \n");
            for (int i = 0; i < n; i++)
            {
                vetY[i] = int.Parse(Console.ReadLine());
                somas[i] = vetX[i] + vetY[i];
                produtos[i] = vetX[i] * vetY[i];
            }

            for (int i = 0; i < n; i++)
            {
                bool diferente = true;
                for (int j = 0; j < n; j++)
                {
                    if (vetX[i] == vetY[j])
                    {
                        intersecao[countIntersecao++] = vetX[i]; 
                        diferente = false;
                        break;
                    }
                }
                if (diferente)
                {
                    diferenca[countDiferenca++] = vetX[i]; 
                }
            }

            for (int i = 0; i < n; i++)
            {
                uniao[countUniao++] = vetX[i];
            }

            for (int i = 0; i < n; i++)
            {
                bool existe = false;
                for (int j = 0; j < n; j++)
                {
                    if (vetY[i] == vetX[j])
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    uniao[countUniao++] = vetY[i];
                }
            }

            // Impressão dos resultados
            Console.Write("\nSoma entre os Vetores X e Y: ");
            foreach (int c in somas)
            {
                Console.Write(c + " ");
            }

            Console.Write("\nProduto entre os Vetores X e Y: ");
            foreach (int c in produtos)
            {
                Console.Write(c + " ");
            }

            Console.Write("\nDiferença entre os Vetores X e Y: ");
            for (int i = 0; i < countDiferenca; i++)
            {
                Console.Write(diferenca[i] + " ");
            }

            Console.Write("\nInterseção entre os Vetores X e Y: ");
            for (int i = 0; i < countIntersecao; i++)
            {
                Console.Write(intersecao[i] + " ");
            }

            Console.Write("\nUnião entre os Vetores X e Y: ");
            for (int i = 0; i < countUniao; i++)
            {
                Console.Write(uniao[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
