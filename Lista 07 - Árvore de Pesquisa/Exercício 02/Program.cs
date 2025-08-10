using System;

class No
{
    public int Valor { get; set; }
    public No Esquerda { get; set; }
    public No Direita { get; set; }

    public No(int valor)
    {
        Valor = valor;
        Esquerda = null;
        Direita = null;
    }
}

class ArvoreBinaria
{
    private No raiz;

    public void Inserir(int valor)
    {
        raiz = InserirRecursivo(raiz, valor);
    }

    private No InserirRecursivo(No no, int valor)
    {
        if (no == null)
            return new No(valor);

        if (valor < no.Valor)
            no.Esquerda = InserirRecursivo(no.Esquerda, valor);
        else if (valor > no.Valor)
            no.Direita = InserirRecursivo(no.Direita, valor);

        return no;
    }

    public void Remover(int valor)
    {
        raiz = RemoverRecursivo(raiz, valor);
    }

    private No RemoverRecursivo(No no, int valor)
    {
        if (no == null)
            return no;

        if (valor < no.Valor)
            no.Esquerda = RemoverRecursivo(no.Esquerda, valor);
        else if (valor > no.Valor)
            no.Direita = RemoverRecursivo(no.Direita, valor);
        else
        {
            if (no.Esquerda == null)
                return no.Direita;
            else if (no.Direita == null)
                return no.Esquerda;

            no.Valor = GetMenor(no.Direita);
            no.Direita = RemoverRecursivo(no.Direita, no.Valor);
        }

        return no;
    }

    public bool Pesquisar(int valor)
    {
        return PesquisarRecursivo(raiz, valor) != null;
    }

    private No PesquisarRecursivo(No no, int valor)
    {
        if (no == null || no.Valor == valor)
            return no;

        if (valor < no.Valor)
            return PesquisarRecursivo(no.Esquerda, valor);
        else
            return PesquisarRecursivo(no.Direita, valor);
    }

    public int GetMaior()
    {
        No atual = raiz;
        while (atual.Direita != null)
            atual = atual.Direita;
        return atual.Valor;
    }

    public int GetMenor(No no)
    {
        while (no.Esquerda != null)
            no = no.Esquerda;
        return no.Valor;
    }
    public int GetMenor()
    {
        if (raiz == null)
            throw new InvalidOperationException("A árvore está vazia.");

        return GetMenor(raiz);
    }

    public void CaminhamentoCentral()
    {
        CaminhamentoCentralRecursivo(raiz);
        Console.WriteLine();
    }

    private void CaminhamentoCentralRecursivo(No no)
    {
        if (no != null)
        {
            CaminhamentoCentralRecursivo(no.Esquerda);
            Console.Write(no.Valor + " ");
            CaminhamentoCentralRecursivo(no.Direita);
        }
    }

    public void CaminhamentoPosOrdem()
    {
        CaminhamentoPosOrdemRecursivo(raiz);
        Console.WriteLine();
    }

    private void CaminhamentoPosOrdemRecursivo(No no)
    {
        if (no != null)
        {
            CaminhamentoPosOrdemRecursivo(no.Esquerda);
            CaminhamentoPosOrdemRecursivo(no.Direita);
            Console.Write(no.Valor + " ");
        }
    }

    public void CaminhamentoPreOrdem()
    {
        CaminhamentoPreOrdemRecursivo(raiz);
        Console.WriteLine();
    }

    private void CaminhamentoPreOrdemRecursivo(No no)
    {
        if (no != null)
        {
            Console.Write(no.Valor + " ");
            CaminhamentoPreOrdemRecursivo(no.Esquerda);
            CaminhamentoPreOrdemRecursivo(no.Direita);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArvoreBinaria arvore = new ArvoreBinaria();
        int opcao;

        do
        {
            Console.WriteLine("Op:");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    int valorInserir = int.Parse(Console.ReadLine());
                    arvore.Inserir(valorInserir);
                    break;
                case 2:
                    int valorRemover = int.Parse(Console.ReadLine());
                    arvore.Remover(valorRemover);
                    break;
                case 3:
                    int valorPesquisar = int.Parse(Console.ReadLine());
                    Console.WriteLine(arvore.Pesquisar(valorPesquisar) ? "sim" : "nao");
                    break;
                case 4:
                    Console.WriteLine(arvore.GetMaior());
                    break;
                case 5:
                    Console.WriteLine(arvore.GetMenor());
                    break;
                case 6:
                    arvore.CaminhamentoCentral();
                    break;
                case 7:
                    arvore.CaminhamentoPosOrdem();
                    break;
                case 8:
                    arvore.CaminhamentoPreOrdem();
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;
            }
        } while (opcao != 9);
    }
}
