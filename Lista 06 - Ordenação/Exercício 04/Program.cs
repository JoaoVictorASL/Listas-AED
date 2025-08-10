using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    class Pais
    {
        public string Nome;
        public int Ouro;
        public int Prata;
        public int Bronze;
    }

    static void Main()
    {
        List<Pais> paises = new List<Pais>();
        string[] linhas = File.ReadAllLines("olimpiadas.txt");

        for (int i = 0; i < linhas.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(linhas[i]))
                continue;

            try
            {
                string nome = linhas[i].Trim();
                int ouro = int.Parse(linhas[++i].Trim());
                int prata = int.Parse(linhas[++i].Trim());
                int bronze = int.Parse(linhas[++i].Trim());

                paises.Add(new Pais
                {
                    Nome = nome,
                    Ouro = ouro,
                    Prata = prata,
                    Bronze = bronze
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar os dados na linha {i + 1}. Verifique o formato dos dados.");
                Console.WriteLine($"Detalhes do erro: {ex.Message}");
            }
        }

        paises = MergeSort(paises);

        Console.WriteLine("Quadro de Medalhas:");
        Console.WriteLine("País\t\tOuro\tPrata\tBronze");

        foreach (Pais pais in paises)
        {
            Console.WriteLine($"{pais.Nome,-15}\t{pais.Ouro}\t{pais.Prata}\t{pais.Bronze}");
        }

        Console.WriteLine("Pressione qualquer tecla para sair.");
        Console.ReadKey(); 
    }

    static List<Pais> MergeSort(List<Pais> paises)
    {
        if (paises.Count <= 1)
            return paises;

        int meio = paises.Count / 2;
        List<Pais> esquerda = MergeSort(paises.GetRange(0, meio));
        List<Pais> direita = MergeSort(paises.GetRange(meio, paises.Count - meio));

        return Merge(esquerda, direita);
    }

    static List<Pais> Merge(List<Pais> esquerda, List<Pais> direita)
    {
        List<Pais> resultado = new List<Pais>();
        int i = 0, j = 0;

        while (i < esquerda.Count && j < direita.Count)
        {
            if (ComparaPaises(esquerda[i], direita[j]) <= 0)
            {
                resultado.Add(esquerda[i]);
                i++;
            }
            else
            {
                resultado.Add(direita[j]);
                j++;
            }
        }

        while (i < esquerda.Count)
        {
            resultado.Add(esquerda[i]);
            i++;
        }

        while (j < direita.Count)
        {
            resultado.Add(direita[j]);
            j++;
        }

        return resultado;
    }

    static int ComparaPaises(Pais a, Pais b)
    {
        if (a.Ouro != b.Ouro)
            return b.Ouro.CompareTo(a.Ouro);
        if (a.Prata != b.Prata)
            return b.Prata.CompareTo(a.Prata);
        if (a.Bronze != b.Bronze)
            return b.Bronze.CompareTo(a.Bronze);

        return a.Nome.CompareTo(b.Nome);
    }
}
