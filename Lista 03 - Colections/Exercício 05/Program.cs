using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string frase = Console.ReadLine().ToLower();
        string[] palavras = frase.Split(' ');
        Dictionary<string, int> ocorrencias = new Dictionary<string, int>();

        foreach (string palavra in palavras)
        {
            if (ocorrencias.ContainsKey(palavra))
                ocorrencias[palavra]++;
            else
                ocorrencias[palavra] = 1;
        }

        foreach (var par in ocorrencias)
        {
            Console.WriteLine($"{par.Key} {par.Value}");
        }
    }
}