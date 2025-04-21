using System;

class Site
{
    public string Nome { get; set; }
    public string Link { get; set; }

    public Site(string nome, string link)
    {
        Nome = nome;
        Link = link;
    }
}

class Celula
{
    private Site elemento;
    private Celula prox;

    public Celula(Site elemento)
    {
        this.elemento = elemento;
        this.prox = null;
    }

    public Celula()
    {
        this.elemento = null;
        this.prox = null;
    }

    public Celula Prox
    {
        get { return prox; }
        set { prox = value; }
    }

    public Site Elemento
    {
        get { return elemento; }
        set { elemento = value; }
    }
}

class Lista
{
    private Celula primeiro, ultimo;

    public Lista()
    {
        primeiro = new Celula();
        ultimo = primeiro;
    }

    public void InserirInicio(Site x)
    {
        Celula tmp = new Celula(x);
        tmp.Prox = primeiro.Prox;
        primeiro.Prox = tmp;
        if (primeiro == ultimo)
            ultimo = tmp;
    }

    public void InserirFim(Site x)
    {
        ultimo.Prox = new Celula(x);
        ultimo = ultimo.Prox;
    }

    public void Inserir(Site x, int pos)
    {
        if (pos < 0 || pos > Tamanho())
            throw new Exception("Erro!");

        Celula i = primeiro;
        for (int j = 0; j < pos; j++, i = i.Prox) ;

        Celula tmp = new Celula(x);
        tmp.Prox = i.Prox;
        i.Prox = tmp;

        if (tmp.Prox == null)
            ultimo = tmp;
    }

    public Site RemoverInicio()
    {
        if (primeiro == ultimo)
            throw new Exception("Erro!");

        Celula tmp = primeiro.Prox;
        primeiro.Prox = tmp.Prox;

        if (tmp == ultimo)
            ultimo = primeiro;

        return tmp.Elemento;
    }

    public Site RemoverFim()
    {
        if (primeiro == ultimo)
            throw new Exception("Erro!");

        Celula i;
        for (i = primeiro; i.Prox != ultimo; i = i.Prox) ;

        Site resp = ultimo.Elemento;
        i.Prox = null;
        ultimo = i;
        return resp;
    }

    public Site Remover(int pos)
    {
        if (pos < 0 || pos >= Tamanho())
            throw new Exception("Erro!");

        if (pos == 0)
            return RemoverInicio();
        if (pos == Tamanho() - 1)
            return RemoverFim();

        Celula i = primeiro;
        for (int j = 0; j < pos; j++, i = i.Prox) ;

        Celula tmp = i.Prox;
        i.Prox = tmp.Prox;

        return tmp.Elemento;
    }

    public void Mostrar()
    {
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            Console.WriteLine($"{i.Elemento.Nome}: {i.Elemento.Link}");
        }
    }

    public string PesquisarLink(string nome)
    {
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            if (i.Elemento.Nome == nome)
            {
                return i.Elemento.Link;
            }
        }
        return "N";
    }

    public int Tamanho()
    {
        int tam = 0;
        for (Celula i = primeiro.Prox; i != null; i = i.Prox)
        {
            tam++;
        }
        return tam;
    }
}

class Program
{
    static void Main()
    {
        Lista lista = new Lista();
        while (true)
        {
            Console.WriteLine("Op:");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                string nome = Console.ReadLine();
                string link = Console.ReadLine();
                lista.InserirInicio(new Site(nome, link));
            }
            else if (opcao == "2")
            {
                string nome = Console.ReadLine();
                string link = Console.ReadLine();
                lista.InserirFim(new Site(nome, link));
            }
            else if (opcao == "3")
            {
                int pos = int.Parse(Console.ReadLine());
                string nome = Console.ReadLine();
                string link = Console.ReadLine();
                lista.Inserir(new Site(nome, link), pos);
            }
            else if (opcao == "4")
            {
                Site removido = lista.RemoverInicio();
                Console.WriteLine(removido.Nome);
            }
            else if (opcao == "5")
            {
                Site removido = lista.RemoverFim();
                Console.WriteLine(removido.Nome);
            }
            else if (opcao == "6")
            {
                int pos = int.Parse(Console.ReadLine());
                Site removido = lista.Remover(pos);
                Console.WriteLine(removido.Nome);
            }
            else if (opcao == "7")
            {
                lista.Mostrar();
            }
            else if (opcao == "8")
            {
                string nome = Console.ReadLine();
                string link = lista.PesquisarLink(nome);
                Console.WriteLine(link);
            }
            else if (opcao == "9")
            {
                break;
            }
        }
    }
}
