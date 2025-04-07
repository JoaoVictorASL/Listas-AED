using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string sequencia = Console.ReadLine();

        if (BemFormada(sequencia))
            Console.WriteLine("correta");
        else
            Console.WriteLine("errada");
    }

    static bool BemFormada(string s)
    {
        Stack<char> pilha = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '[')
            {
                pilha.Push(c);
            }
            else if (c == ')' || c == ']')
            {
                if (pilha.Count == 0) return false;
                char topo = pilha.Pop();
                if ((c == ')' && topo != '(') || (c == ']' && topo != '['))
                    return false;
            }
        }

        return pilha.Count == 0;
    }
}
