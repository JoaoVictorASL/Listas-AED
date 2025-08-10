using System;
    public class Estudante
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }

        public Estudante(int matricula, string nome, string curso)
        {
            Matricula = matricula;
            Nome = nome;
            Curso = curso;
        }

        public override string ToString()
        {
            return $"Matrícula: {Matricula}, Nome: {Nome}, Curso: {Curso}";
        }
    }
    public class NoLista
    {
        public Estudante Estudante { get; set; }
        public NoLista Proximo { get; set; }

        public NoLista(Estudante estudante)
        {
            Estudante = estudante;
            Proximo = null;
        }
    }
    public class Lista
    {
        private NoLista primeiro;

        public Lista()
        {
            primeiro = null;
        }

        public void Inserir(Estudante estudante)
        {
            NoLista novo = new NoLista(estudante);
            novo.Proximo = primeiro;
            primeiro = novo;
        }

        public Estudante Pesquisar(int matricula)
        {
            NoLista atual = primeiro;
            while (atual != null)
            {
                if (atual.Estudante.Matricula == matricula)
                    return atual.Estudante;
                atual = atual.Proximo;
            }
            return null;
        }

        public bool Remover(int matricula)
        {
            NoLista atual = primeiro, anterior = null;

            while (atual != null)
            {
                if (atual.Estudante.Matricula == matricula)
                {
                    if (anterior == null)
                        primeiro = atual.Proximo;
                    else
                        anterior.Proximo = atual.Proximo;

                    return true;
                }
                anterior = atual;
                atual = atual.Proximo;
            }

            return false;
        }

        public void Listar()
        {
            NoLista atual = primeiro;
            while (atual != null)
            {
                Console.WriteLine(atual.Estudante);
                atual = atual.Proximo;
            }
        }
    }
    public class TabelaHash
    {
        private Lista[] tabela;
        private int tamanho;

        public TabelaHash(int tamanho)
        {
            this.tamanho = tamanho;
            tabela = new Lista[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                tabela[i] = new Lista();
            }
        }

        private int Hash(int chave)
        {
            return chave % tamanho;
        }

        public void Inserir(Estudante estudante)
        {
            int posicao = Hash(estudante.Matricula);
            tabela[posicao].Inserir(estudante);
        }

        public Estudante Pesquisar(int matricula)
        {
            int posicao = Hash(matricula);
            return tabela[posicao].Pesquisar(matricula);
        }

        public bool Remover(int matricula)
        {
            int posicao = Hash(matricula);
            return tabela[posicao].Remover(matricula);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TabelaHash tabela = new TabelaHash(101);

            int opcao;
            do
            {
                Console.WriteLine("1- Inserir um estudante");
                Console.WriteLine("2- Remover um estudante");
                Console.WriteLine("3- Pesquisar um estudante");
                Console.WriteLine("4- Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Informe a matrícula: ");
                        int matricula = int.Parse(Console.ReadLine());
                        Console.Write("Informe o nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Informe o curso: ");
                        string curso = Console.ReadLine();
                        tabela.Inserir(new Estudante(matricula, nome, curso));
                        Console.WriteLine("Estudante inserido com sucesso!");
                        break;

                    case 2:
                        Console.Write("Informe a matrícula do estudante a remover: ");
                        matricula = int.Parse(Console.ReadLine());
                        if (tabela.Remover(matricula))
                            Console.WriteLine("Estudante removido com sucesso!");
                        else
                            Console.WriteLine("Estudante não encontrado.");
                        break;

                    case 3:
                        Console.Write("Informe a matrícula do estudante a pesquisar: ");
                        matricula = int.Parse(Console.ReadLine());
                        Estudante estudante = tabela.Pesquisar(matricula);
                        if (estudante != null)
                            Console.WriteLine(estudante);
                        else
                            Console.WriteLine("Estudante não cadastrado.");
                        break;

                    case 4:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 4);
        }
    }
