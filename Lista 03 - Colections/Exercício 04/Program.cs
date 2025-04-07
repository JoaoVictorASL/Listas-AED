using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> filaDecolagem = new Queue<string>();

        while (true)
        {
            Console.WriteLine("Op:");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine(filaDecolagem.Count);
            }
            else if (opcao == 2)
            {
                if (filaDecolagem.Count > 0)
                    Console.WriteLine(filaDecolagem.Dequeue());
            }
            else if (opcao == 3)
            {
                string idAviao = Console.ReadLine();
                filaDecolagem.Enqueue(idAviao);
            }
            else if (opcao == 4)
            {
                foreach (string aviao in filaDecolagem)
                    Console.WriteLine(aviao);
            }
            else if (opcao == 5)
            {
                if (filaDecolagem.Count > 0)
                    Console.WriteLine(filaDecolagem.Peek());
            }
            else if (opcao == 6)
            {
                break;
            }
        }
    }
}
