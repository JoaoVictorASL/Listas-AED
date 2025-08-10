using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string caminhoArquivo = "players.csv";
        List<Jogador> jogadores = new List<Jogador>();

        using (var leitor = new StreamReader(caminhoArquivo))
        {
            leitor.ReadLine();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var campos = linha.Split(',');

                Jogador jogador = new Jogador(
                    int.Parse(campos[0]),
                    campos[1],
                    float.Parse(campos[2]),
                    float.Parse(campos[3]),
                    campos[4],
                    int.Parse(campos[5]),
                    campos[6],
                    campos[7]
                );

                jogadores.Add(jogador);
            }
        }

        jogadores = MergeSort(jogadores);

        foreach (var jogador in jogadores)
        {
            Console.WriteLine(jogador);
        }
        Console.ReadLine();

    }

    public static List<Jogador> MergeSort(List<Jogador> lista)
    {
        if (lista.Count <= 1)
            return lista;

        int meio = lista.Count / 2;
        List<Jogador> esquerda = lista.GetRange(0, meio);
        List<Jogador> direita = lista.GetRange(meio, lista.Count - meio);

        esquerda = MergeSort(esquerda);
        direita = MergeSort(direita);

        return Merge(esquerda, direita);
    }

    public static List<Jogador> Merge(List<Jogador> esquerda, List<Jogador> direita)
    {
        List<Jogador> resultado = new List<Jogador>();
        int i = 0, j = 0;

        while (i < esquerda.Count && j < direita.Count)
        {
            if (esquerda[i].AnoNasc < direita[j].AnoNasc ||
               (esquerda[i].AnoNasc == direita[j].AnoNasc && string.Compare(esquerda[i].Nome, direita[j].Nome) <= 0))
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
}

class Jogador
{
    private int id;
    private string nome;
    private float altura;
    private float peso;
    private string universidade;
    private int anoNasc;
    private string cidadeNasc;
    private string estadoNasc;

    public Jogador(int id, string nome, float altura, float peso, string universidade, int anoNasc, string cidadeNasc, string estadoNasc)
    {
        this.id = id;
        this.nome = nome;
        this.altura = altura;
        this.peso = peso;
        this.universidade = universidade;
        this.anoNasc = anoNasc;
        this.cidadeNasc = cidadeNasc;
        this.estadoNasc = estadoNasc;
    }

    public int AnoNasc => anoNasc;
    public string Nome => nome;

    public override string ToString()
    {
        return $"ID: {id}, Nome: {nome}, Altura: {altura}, Peso: {peso}, Universidade: {universidade}, Ano Nasc: {anoNasc}, Cidade Nasc: {cidadeNasc}, Estado Nasc: {estadoNasc}";
    }
}
