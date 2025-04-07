using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<string> listaMusicas = new LinkedList<string>();

        while (true)
        {
            Console.WriteLine("Op:");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                string musica = Console.ReadLine();
                listaMusicas.AddLast(musica);
            }
            else if (opcao == 2)
            {
                string musica = Console.ReadLine();
                listaMusicas.AddFirst(musica);
            }
            else if (opcao == 3)
            {
                string novaMusica = Console.ReadLine();
                string referencia = Console.ReadLine();
                var no = listaMusicas.Find(referencia);
                if (no != null)
                    listaMusicas.AddAfter(no, novaMusica);
            }
            else if (opcao == 4)
            {
                if (listaMusicas.Count > 0)
                    listaMusicas.RemoveFirst();
            }
            else if (opcao == 5)
            {
                if (listaMusicas.Count > 0)
                    listaMusicas.RemoveLast();
            }
            else if (opcao == 6)
            {
                string musica = Console.ReadLine();
                listaMusicas.Remove(musica);
            }
            else if (opcao == 7)
            {
                foreach (string musica in listaMusicas)
                    Console.WriteLine(musica);
            }
            else if (opcao == 8)
            {
                string musica = Console.ReadLine();
                Console.WriteLine(listaMusicas.Contains(musica) ? "sim" : "não");
            }
            else if (opcao == 9)
            {
                break;
            }
        }
    }
}
