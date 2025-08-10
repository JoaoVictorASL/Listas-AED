using System;
using System.Diagnostics;

namespace Exercício_01
{
    internal class Program
    {
        static int compCount, movCount;

        static void Main(string[] args)
        {
            int[] tamanhos = { 1000, 500000 };
            Random random = new Random();

            foreach (int tamanho in tamanhos)
            {
                Console.WriteLine($"Gerando vetores de tamanho {tamanho}...");

                int[] vetorCrescente = new int[tamanho];
                for (int i = 0; i < tamanho; i++) vetorCrescente[i] = i + 1;

                int[] vetorDecrescente = new int[tamanho];
                for (int i = 0; i < tamanho; i++) vetorDecrescente[i] = tamanho - i;

                int[] vetorAleatorio = new int[tamanho];
                for (int i = 0; i < tamanho; i++) vetorAleatorio[i] = random.Next(1, tamanho + 1);

                TestarAlgoritmos(vetorCrescente, tamanho, "Crescente");
                TestarAlgoritmos(vetorDecrescente, tamanho, "Decrescente");
                TestarAlgoritmos(vetorAleatorio, tamanho, "Aleatório");
                Console.ReadLine(); 
            }
        }

        static void TestarAlgoritmos(int[] vetor, int tamanho, string tipoVetor)
        {
            Console.WriteLine($"\nTestando algoritmos com vetor {tipoVetor}, tamanho {tamanho}:");

            int[] copia;

            copia = (int[])vetor.Clone();
            TestarOrdenacao(Selecao, copia, tamanho, "Seleção");

            copia = (int[])vetor.Clone();
            TestarOrdenacao(Bolha, copia, tamanho, "Bolha");

            copia = (int[])vetor.Clone();
            TestarOrdenacao(Insercao, copia, tamanho, "Inserção");

            copia = (int[])vetor.Clone();
            TestarOrdenacao((arr, n) => Quicksort(arr, 0, n - 1), copia, tamanho, "Quicksort");

            copia = (int[])vetor.Clone();
            TestarOrdenacao((arr, n) => Mergesort(arr, 0, n - 1), copia, tamanho, "Mergesort");

            copia = (int[])vetor.Clone();
            TestarOrdenacao(Heapsort, copia, tamanho, "Heapsort");
        }

        static void TestarOrdenacao(Action<int[], int> metodoOrdenacao, int[] array, int n, string nomeMetodo)
        {
            compCount = 0;
            movCount = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();

            metodoOrdenacao(array, n);

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"{nomeMetodo}: Tempo = {elapsedTime}, Comparações = {compCount}, Movimentações = {movCount}");
        }

        static void Selecao(int[] array, int n)
        {
            for (int i = 0; i < (n - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < n; j++)
                {
                    compCount++;
                    if (array[menor] > array[j])
                    {
                        menor = j;
                    }
                }
                int temp = array[menor];
                array[menor] = array[i];
                array[i] = temp;
                movCount++;
            }
        }

        static void Bolha(int[] array, int n)
        {
            int temp;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    compCount++;
                    if (array[j] < array[j - 1])
                    {
                        temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                        movCount++;
                    }
                }
            }
        }

        static void Insercao(int[] array, int n)
        {
            for (int i = 1; i < n; i++)
            {
                int tmp = array[i];
                int j = i - 1;

                compCount++;

                while (j >= 0 && array[j] > tmp)
                {
                    array[j + 1] = array[j];
                    j--;
                    movCount++;

                    if (j >= 0) compCount++;
                }

                array[j + 1] = tmp;
                movCount++;
            }
        }

        static void Quicksort(int[] array, int esq, int dir)
        {
            int i = esq, j = dir;
            int pivo = array[(esq + dir) / 2];
            while (i <= j)
            {
                while (array[i] < pivo) { i++; compCount++; }
                while (array[j] > pivo) { j--; compCount++; }
                if (i <= j)
                {
                    Trocar(array, i, j);
                    i++; j--;
                    movCount++;
                }
            }
            if (esq < j) Quicksort(array, esq, j);
            if (i < dir) Quicksort(array, i, dir);
        }

        static void Mergesort(int[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(array, esq, meio);
                Mergesort(array, meio + 1, dir);
                Intercalar(array, esq, meio, dir);
            }
        }

        static void Intercalar(int[] array, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;
            int[] arrayEsq = new int[nEsq + 1];
            int[] arrayDir = new int[nDir + 1];
            Array.Copy(array, esq, arrayEsq, 0, nEsq);
            Array.Copy(array, meio + 1, arrayDir, 0, nDir);
            arrayEsq[nEsq] = int.MaxValue;
            arrayDir[nDir] = int.MaxValue;

            for (int iEsq = 0, iDir = 0, k = esq; k <= dir; k++)
            {
                compCount++;
                if (arrayEsq[iEsq] <= arrayDir[iDir])
                {
                    array[k] = arrayEsq[iEsq++];
                }
                else
                {
                    array[k] = arrayDir[iDir++];
                }
                movCount++;
            }
        }

        static void Heapsort(int[] array, int n)
        {
            for (int tam = 2; tam <= n; tam++)
            {
                Construir(array, tam);
            }

            for (int tam = n; tam > 1; tam--)
            {
                Trocar(array, 1, tam - 1);
                Reconstruir(array, tam - 1);
            }
        }

        static void Construir(int[] array, int tam)
        {
            for (int i = tam - 1; i > 0 && array[i] > array[(i - 1) / 2]; i = (i - 1) / 2)
            {
                Trocar(array, i, (i - 1) / 2);
                movCount++;
                compCount++;
            }
        }

        static void Reconstruir(int[] array, int tam)
        {
            int i = 1;
            while (HasFilho(i, tam))
            {
                int filho = GetMaiorFilho(array, i, tam);
                compCount++;
                if (array[i] < array[filho])
                {
                    Trocar(array, i, filho);
                    i = filho;
                    movCount++;
                }
                else
                {
                    break;
                }
            }
        }

        static bool HasFilho(int i, int tam) => 2 * i < tam;

        static int GetMaiorFilho(int[] array, int i, int tam)
        {
            int filhoEsq = 2 * i;
            int filhoDir = filhoEsq + 1;
            return (filhoDir < tam && array[filhoDir] > array[filhoEsq]) ? filhoDir : filhoEsq;
        }

        static void Trocar(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
