using System;

class Aluno
{
    public string Nome { get; set; }
    public int Nota { get; set; }

    public Aluno(string nome, int nota)
    {
        Nome = nome;
        Nota = nota;
    }
}

class Program
{
    static int PesquisaBinaria(Aluno[] alunos, string nome)
    {
        int esquerda = 0;
        int direita = alunos.Length - 1;

        while (esquerda <= direita)
        {
            int meio = (esquerda + direita) / 2;
            int comparacao = alunos[meio].Nome.CompareTo(nome);

            if (comparacao == 0)
                return meio;

            if (comparacao < 0)
                esquerda = meio + 1;
            else
                direita = meio - 1;
        }

        return -1;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Aluno[] alunos = new Aluno[n];

        for (int i = 0; i < n; i++)
        {
            string[] entrada = Console.ReadLine().Split(',');
            string nome = entrada[0];
            int nota = int.Parse(entrada[1]);
            alunos[i] = new Aluno(nome, nota);
        }

        string continuar;
        do
        {
            string nomeBusca = Console.ReadLine();
            int indice = PesquisaBinaria(alunos, nomeBusca);

            if (indice != -1)
                Console.WriteLine(alunos[indice].Nota);
            else
                Console.WriteLine("nao");

            continuar = Console.ReadLine();
        } while (continuar.ToUpper() == "S");
    }
}
