using System;

class CelulaDupla
{
    public string elemento;
    public CelulaDupla anterior, proximo;

    public CelulaDupla(string elemento)
    {
        this.elemento = elemento;
        this.anterior = null;
        this.proximo = null;
    }
}

class ListaDupla
{
    private CelulaDupla primeiro;
    private CelulaDupla ultimo;

    public ListaDupla()
    {
        primeiro = null;
        ultimo = null;
    }

    public void InserirInicio(string x)
    {
        CelulaDupla nova = new CelulaDupla(x);
        if (primeiro == null)
        {
            primeiro = ultimo = nova;
        }
        else
        {
            nova.proximo = primeiro;
            primeiro.anterior = nova;
            primeiro = nova;
        }
    }

    public void InserirFim(string x)
    {
        CelulaDupla nova = new CelulaDupla(x);
        if (primeiro == null)
        {
            primeiro = ultimo = nova;
        }
        else
        {
            ultimo.proximo = nova;
            nova.anterior = ultimo;
            ultimo = nova;
        }
    }

    public void Inserir(int pos, string x)
    {
        if (pos == 0)
        {
            InserirInicio(x);
        }
        else
        {
            CelulaDupla i = primeiro;
            for (int j = 0; j < pos - 1 && i != null; j++, i = i.proximo) ;

            if (i == null || i == ultimo)
            {
                InserirFim(x);
            }
            else
            {
                CelulaDupla nova = new CelulaDupla(x);
                nova.proximo = i.proximo;
                nova.anterior = i;
                i.proximo.anterior = nova;
                i.proximo = nova;
            }
        }
    }

    public string RemoverInicio()
    {
        if (primeiro == null) return null;
        string resp = primeiro.elemento;
        if (primeiro == ultimo)
        {
            primeiro = ultimo = null;
        }
        else
        {
            primeiro = primeiro.proximo;
            primeiro.anterior = null;
        }
        return resp;
    }

    public string RemoverFim()
    {
        if (ultimo == null) return null;
        string resp = ultimo.elemento;
        if (primeiro == ultimo)
        {
            primeiro = ultimo = null;
        }
        else
        {
            ultimo = ultimo.anterior;
            ultimo.proximo = null;
        }
        return resp;
    }

    public string Remover(int pos)
    {
        if (pos == 0) return RemoverInicio();

        CelulaDupla i = primeiro;
        for (int j = 0; j < pos && i != null; j++, i = i.proximo) ;

        if (i == null || i == ultimo) return RemoverFim();

        string resp = i.elemento;
        i.anterior.proximo = i.proximo;
        i.proximo.anterior = i.anterior;
        return resp;
    }

    public bool Remover(string x)
    {
        CelulaDupla i = primeiro;
        while (i != null && i.elemento != x) i = i.proximo;

        if (i == null) return false;

        if (i == primeiro) RemoverInicio();
        else if (i == ultimo) RemoverFim();
        else
        {
            i.anterior.proximo = i.proximo;
            i.proximo.anterior = i.anterior;
        }
        return true;
    }

    public void Mostrar()
    {
        for (CelulaDupla i = primeiro; i != null; i = i.proximo)
        {
            Console.WriteLine(i.elemento);
        }
    }

    public void MostrarInverso()
    {
        for (CelulaDupla i = ultimo; i != null; i = i.anterior)
        {
            Console.WriteLine(i.elemento);
        }
    }

    public bool Pesquisar(string x)
    {
        for (CelulaDupla i = primeiro; i != null; i = i.proximo)
        {
            if (i.elemento == x) return true;
        }
        return false;
    }

    public string PesquisarAnterior(string x)
    {
        for (CelulaDupla i = primeiro; i != null; i = i.proximo)
        {
            if (i.elemento == x)
            {
                if (i.anterior == null) return null;
                return i.anterior.elemento;
            }
        }
        return null;
    }

    public string PesquisarPosterior(string x)
    {
        for (CelulaDupla i = primeiro; i != null; i = i.proximo)
        {
            if (i.elemento == x)
            {
                if (i.proximo == null) return null;
                return i.proximo.elemento;
            }
        }
        return null;
    }
}

class GerenciadorMusica
{
    static void Main()
    {
        ListaDupla lista = new ListaDupla();
        int op;
        do
        {
            Console.Write("Op:\n");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    lista.InserirFim(Console.ReadLine());
                    break;
                case 2:
                    lista.InserirInicio(Console.ReadLine());
                    break;
                case 3:
                    int pos = int.Parse(Console.ReadLine());
                    string musica = Console.ReadLine();
                    lista.Inserir(pos, musica);
                    break;
                case 4:
                    Console.WriteLine(lista.RemoverInicio());
                    break;
                case 5:
                    Console.WriteLine(lista.RemoverFim());
                    break;
                case 6:
                    int p = int.Parse(Console.ReadLine());
                    Console.WriteLine(lista.Remover(p));
                    break;
                case 7:
                    string m = Console.ReadLine();
                    Console.WriteLine(lista.Remover(m) ? "S" : "N");
                    break;
                case 8:
                    lista.Mostrar();
                    break;
                case 9:
                    lista.MostrarInverso();
                    break;
                case 10:
                    Console.WriteLine(lista.Pesquisar(Console.ReadLine()) ? "S" : "N");
                    break;
                case 11:
                    {
                        string anterior = lista.PesquisarAnterior(Console.ReadLine());
                        Console.WriteLine(anterior != null ? anterior : "N");
                        break;
                    }
                case 12:
                    {
                        string posterior = lista.PesquisarPosterior(Console.ReadLine());
                        Console.WriteLine(posterior != null ? posterior : "N");
                        break;
                    }
            }
        } while (op != 13);
    }
}
