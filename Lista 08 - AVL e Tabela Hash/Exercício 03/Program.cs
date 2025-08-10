using System;

class Paciente
{
    public int Cpf { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}

class NoAVL
{
    public Paciente Dados { get; set; }
    public int Altura { get; set; }
    public NoAVL Esquerdo { get; set; }
    public NoAVL Direito { get; set; }

    public NoAVL(Paciente dados)
    {
        Dados = dados;
        Altura = 1;
    }
}

class ArvoreAVL
{
    private NoAVL Raiz;

    private int Altura(NoAVL no) => no?.Altura ?? 0;

    private int FatorBalanceamento(NoAVL no) => no == null ? 0 : Altura(no.Esquerdo) - Altura(no.Direito);

    private NoAVL RotacaoDireita(NoAVL y)
    {
        var x = y.Esquerdo;
        var T = x.Direito;

        x.Direito = y;
        y.Esquerdo = T;

        y.Altura = Math.Max(Altura(y.Esquerdo), Altura(y.Direito)) + 1;
        x.Altura = Math.Max(Altura(x.Esquerdo), Altura(x.Direito)) + 1;

        return x;
    }

    private NoAVL RotacaoEsquerda(NoAVL x)
    {
        var y = x.Direito;
        var T = y.Esquerdo;

        y.Esquerdo = x;
        x.Direito = T;

        x.Altura = Math.Max(Altura(x.Esquerdo), Altura(x.Direito)) + 1;
        y.Altura = Math.Max(Altura(y.Esquerdo), Altura(y.Direito)) + 1;

        return y;
    }

    private NoAVL Balancear(NoAVL no)
    {
        var fator = FatorBalanceamento(no);

        if (fator > 1)
        {
            if (FatorBalanceamento(no.Esquerdo) < 0)
                no.Esquerdo = RotacaoEsquerda(no.Esquerdo);
            return RotacaoDireita(no);
        }

        if (fator < -1)
        {
            if (FatorBalanceamento(no.Direito) > 0)
                no.Direito = RotacaoDireita(no.Direito);
            return RotacaoEsquerda(no);
        }

        return no;
    }

    private NoAVL Inserir(NoAVL no, Paciente paciente)
    {
        if (no == null)
            return new NoAVL(paciente);

        if (paciente.Cpf < no.Dados.Cpf)
            no.Esquerdo = Inserir(no.Esquerdo, paciente);
        else if (paciente.Cpf > no.Dados.Cpf)
            no.Direito = Inserir(no.Direito, paciente);
        else
            throw new Exception("Paciente já cadastrado!");

        no.Altura = 1 + Math.Max(Altura(no.Esquerdo), Altura(no.Direito));

        return Balancear(no);
    }

    public void Inserir(Paciente paciente) => Raiz = Inserir(Raiz, paciente);

    private NoAVL Remover(NoAVL no, int cpf)
    {
        if (no == null)
            return null;

        if (cpf < no.Dados.Cpf)
            no.Esquerdo = Remover(no.Esquerdo, cpf);
        else if (cpf > no.Dados.Cpf)
            no.Direito = Remover(no.Direito, cpf);
        else
        {
            if (no.Esquerdo == null || no.Direito == null)
                return no.Esquerdo ?? no.Direito;

            var sucessor = Minimo(no.Direito);
            no.Dados = sucessor.Dados;
            no.Direito = Remover(no.Direito, sucessor.Dados.Cpf);
        }

        no.Altura = 1 + Math.Max(Altura(no.Esquerdo), Altura(no.Direito));

        return Balancear(no);
    }

    public void Remover(int cpf) => Raiz = Remover(Raiz, cpf);

    private NoAVL Minimo(NoAVL no)
    {
        var atual = no;
        while (atual.Esquerdo != null)
            atual = atual.Esquerdo;
        return atual;
    }

    private Paciente Buscar(NoAVL no, int cpf)
    {
        if (no == null)
            return null;

        if (cpf < no.Dados.Cpf)
            return Buscar(no.Esquerdo, cpf);
        if (cpf > no.Dados.Cpf)
            return Buscar(no.Direito, cpf);

        return no.Dados;
    }

    public Paciente Buscar(int cpf) => Buscar(Raiz, cpf);

    private void CaminhamentoCentral(NoAVL no, Action<Paciente> acao)
    {
        if (no == null) return;

        CaminhamentoCentral(no.Esquerdo, acao);
        acao(no.Dados);
        CaminhamentoCentral(no.Direito, acao);
    }

    public void CaminhamentoCentral(Action<Paciente> acao) => CaminhamentoCentral(Raiz, acao);

    private void CaminhamentoPosOrdem(NoAVL no, Action<Paciente> acao)
    {
        if (no == null) return;

        CaminhamentoPosOrdem(no.Esquerdo, acao);
        CaminhamentoPosOrdem(no.Direito, acao);
        acao(no.Dados);
    }

    public void CaminhamentoPosOrdem(Action<Paciente> acao) => CaminhamentoPosOrdem(Raiz, acao);

    private void CaminhamentoPreOrdem(NoAVL no, Action<Paciente> acao)
    {
        if (no == null) return;

        acao(no.Dados);
        CaminhamentoPreOrdem(no.Esquerdo, acao);
        CaminhamentoPreOrdem(no.Direito, acao);
    }

    public void CaminhamentoPreOrdem(Action<Paciente> acao) => CaminhamentoPreOrdem(Raiz, acao);
}

class Program
{
    static void Main()
    {
        var arvore = new ArvoreAVL();

        while (true)
        {
            Console.WriteLine("\n1- Cadastrar um paciente");
            Console.WriteLine("2- Remover um paciente");
            Console.WriteLine("3- Pesquisar um paciente pelo CPF");
            Console.WriteLine("4- Mostrar os nomes de todos os pacientes (caminhamento central)");
            Console.WriteLine("5- Mostrar os CPFs de todos os pacientes (caminhamento pós-ordem)");
            Console.WriteLine("6- Mostrar os e-mails de todos os pacientes (caminhamento pré-ordem)");
            Console.WriteLine("7- Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out var opcao) || opcao == 7)
                break;

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o CPF: ");
                    var cpf = int.Parse(Console.ReadLine());
                    Console.Write("Digite o Nome: ");
                    var nome = Console.ReadLine();
                    Console.Write("Digite o Email: ");
                    var email = Console.ReadLine();
                    Console.Write("Digite o Telefone: ");
                    var telefone = Console.ReadLine();
                    arvore.Inserir(new Paciente { Cpf = cpf, Nome = nome, Email = email, Telefone = telefone });
                    Console.WriteLine("Paciente cadastrado com sucesso!");
                    break;

                case 2:
                    Console.Write("Digite o CPF do paciente a ser removido: ");
                    cpf = int.Parse(Console.ReadLine());
                    arvore.Remover(cpf);
                    Console.WriteLine("Paciente removido com sucesso!");
                    break;

                case 3:
                    Console.Write("Digite o CPF do paciente a ser pesquisado: ");
                    cpf = int.Parse(Console.ReadLine());
                    var paciente = arvore.Buscar(cpf);
                    if (paciente == null)
                        Console.WriteLine("Paciente não cadastrado.");
                    else
                        Console.WriteLine($"CPF: {paciente.Cpf}, Nome: {paciente.Nome}, Email: {paciente.Email}, Telefone: {paciente.Telefone}");
                    break;

                case 4:
                    Console.WriteLine("Nomes dos pacientes:");
                    arvore.CaminhamentoCentral(p => Console.WriteLine(p.Nome));
                    break;

                case 5:
                    Console.WriteLine("CPFs dos pacientes:");
                    arvore.CaminhamentoPosOrdem(p => Console.WriteLine(p.Cpf));
                    break;

                case 6:
                    Console.WriteLine("Emails dos pacientes:");
                    arvore.CaminhamentoPreOrdem(p => Console.WriteLine(p.Email));
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
