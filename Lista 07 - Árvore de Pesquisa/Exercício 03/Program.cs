using System;

public class No
{
    public string Valor { get; set; }
    public No Esquerda { get; set; }
    public No Direita { get; set; }

    public No(string valor)
    {
        Valor = valor;
        Esquerda = null;
        Direita = null;
    }
}

public class ArvoreBinaria
{
    private No raiz;

    public void Inserir(string valor)
    {
        raiz = Inserir(raiz, valor);
    }

    private No Inserir(No no, string valor)
    {
        if (no == null)
            return new No(valor);

        if (valor.CompareTo(no.Valor) < 0)
            no.Esquerda = Inserir(no.Esquerda, valor);
        else if (valor.CompareTo(no.Valor) > 0)
            no.Direita = Inserir(no.Direita, valor);

        return no;
    }

    public void Remover(string valor)
    {
        raiz = Remover(raiz, valor);
    }

    private No Remover(No no, string valor)
    {
        if (no == null)
            return null;

        if (valor.CompareTo(no.Valor) < 0)
            no.Esquerda = Remover(no.Esquerda, valor);
        else if (valor.CompareTo(no.Valor) > 0)
            no.Direita = Remover(no.Direita, valor);
        else
        {
            if (no.Esquerda == null)
                return no.Direita;
            if (no.Direita == null)
                return no.Esquerda;

            no.Valor = GetMenor(no.Direita);
            no.Direita = Remover(no.Direita, no.Valor);
        }

        return no;
    }

    private string GetMenor(No no)
    {
        while (no.Esquerda != null)
            no = no.Esquerda;
        return no.Valor;
    }

    public bool Pesquisar(string valor)
    {
        return Pesquisar(raiz, valor);
    }

    private bool Pesquisar(No no, string valor)
    {
        if (no == null)
            return false;

        if (valor.CompareTo(no.Valor) == 0)
            return true;
        if (valor.CompareTo(no.Valor) < 0)
            return Pesquisar(no.Esquerda, valor);

        return Pesquisar(no.Direita, valor);
    }

    public void CaminhamentoCentral()
    {
        CaminhamentoCentral(raiz);
    }

    private void CaminhamentoCentral(No no)
    {
        if (no != null)
        {
            CaminhamentoCentral(no.Esquerda);
            Console.Write(no.Valor + " ");
            CaminhamentoCentral(no.Direita);
        }
    }

    public void CaminhamentoPosOrdem()
    {
        CaminhamentoPosOrdem(raiz);
    }

    private void CaminhamentoPosOrdem(No no)
    {
        if (no != null)
        {
            CaminhamentoPosOrdem(no.Esquerda);
            CaminhamentoPosOrdem(no.Direita);
            Console.Write(no.Valor + " ");
        }
    }

    public void CaminhamentoPreOrdem()
    {
        CaminhamentoPreOrdem(raiz);
    }

    private void CaminhamentoPreOrdem(No no)
    {
        if (no != null)
        {
            Console.Write(no.Valor + " ");
            CaminhamentoPreOrdem(no.Esquerda);
            CaminhamentoPreOrdem(no.Direita);
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
                    string nomeInserir = Console.ReadLine();
                    arvore.Inserir(nomeInserir);
                    break;

                case 2:
                    string nomeRemover = Console.ReadLine();
                    arvore.Remover(nomeRemover);
                    break;

                case 3:
                    string nomePesquisar = Console.ReadLine();
                    if (arvore.Pesquisar(nomePesquisar))
                        Console.WriteLine("sim");
                    else
                        Console.WriteLine("nao");
                    break;

                case 4:
                    arvore.CaminhamentoCentral();
                    Console.WriteLine();
                    break;

                case 5:
                    arvore.CaminhamentoPosOrdem();
                    Console.WriteLine();
                    break;

                case 6:
                    arvore.CaminhamentoPreOrdem();
                    Console.WriteLine();
                    break;

            }
        } while (opcao != 7);
    }
}
