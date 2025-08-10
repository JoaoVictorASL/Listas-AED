using System;

class TabelaHash
{
    private int[] tabela;
    private int tamanho;

    public TabelaHash(int tamanho)
    {
        this.tamanho = tamanho;
        tabela = new int[tamanho];
        for (int i = 0; i < tamanho; i++)
        {
            tabela[i] = -1; 
        }
    }

    private int Hash(int chave, int i)
    {
        return (chave + i) % tamanho;
    }

    public bool Inserir(int chave)
    {
        for (int i = 0; i < tamanho; i++)
        {
            int posicao = Hash(chave, i);
            if (tabela[posicao] == -1 || tabela[posicao] == -2)
            {
                tabela[posicao] = chave;
                return true;
            }
        }
        Console.WriteLine("Tabela cheia! Não foi possível inserir.");
        return false;
    }

    public bool Remover(int chave)
    {
        for (int i = 0; i < tamanho; i++)
        {
            int posicao = Hash(chave, i);
            if (tabela[posicao] == chave)
            {
                tabela[posicao] = -2;
                return true;
            }
            if (tabela[posicao] == -1) 
                break;
        }
        return false;
    }

    public bool Pesquisar(int chave)
    {
        for (int i = 0; i < tamanho; i++)
        {
            int posicao = Hash(chave, i);
            if (tabela[posicao] == chave)
                return true;
            if (tabela[posicao] == -1) 
                break;
        }
        return false;
    }

    public void ExibirTabela()
    {
        Console.WriteLine("Tabela Hash:");
        for (int i = 0; i < tamanho; i++)
        {
            Console.WriteLine($"Posição {i}: {(tabela[i] == -1 ? "Vazia" : tabela[i] == -2 ? "Removido" : tabela[i].ToString())}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TabelaHash tabela = new TabelaHash(13);
        int opcao;

        do
        {
            Console.WriteLine("\nMenu de opções:");
            Console.WriteLine("1- Inserir um número");
            Console.WriteLine("2- Remover um número");
            Console.WriteLine("3- Pesquisar um número");
            Console.WriteLine("4- Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Informe o número a ser inserido: ");
                    int numInserir = int.Parse(Console.ReadLine());
                    if (tabela.Inserir(numInserir))
                        Console.WriteLine("Número inserido com sucesso.");
                    else
                        Console.WriteLine("Falha ao inserir o número.");
                    break;

                case 2:
                    Console.Write("Informe o número a ser removido: ");
                    int numRemover = int.Parse(Console.ReadLine());
                    if (tabela.Remover(numRemover))
                        Console.WriteLine("Número removido com sucesso.");
                    else
                        Console.WriteLine("Número não encontrado.");
                    break;

                case 3:
                    Console.Write("Informe o número a ser pesquisado: ");
                    int numPesquisar = int.Parse(Console.ReadLine());
                    if (tabela.Pesquisar(numPesquisar))
                        Console.WriteLine("Número encontrado na tabela.");
                    else
                        Console.WriteLine("Número não encontrado.");
                    break;

                case 4:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            tabela.ExibirTabela();

        } while (opcao != 4);
    }
}
