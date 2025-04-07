using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_05
{
    internal class Teste
    {
        static void Main(string[] args)
        {
            Time meuTime = new Time("Atlético");

            meuTime.AdicionarTitular(new Jogador(1, "João", "Goleiro"));
            meuTime.AdicionarTitular(new Jogador(2, "Carlos", "Zagueiro"));
            meuTime.AdicionarTitular(new Jogador(3, "Pedro", "Meio-campo"));

            meuTime.AdicionarReserva(new Jogador(4, "Lucas", "Atacante"));
            meuTime.AdicionarReserva(new Jogador(5, "Felipe", "Lateral"));

            Console.WriteLine("João é titular? " + meuTime.ConsultarTitular("João"));
            Console.WriteLine("Lucas é reserva? " + meuTime.ConsultarReserva("Lucas"));

            string nome = "Carlos";
            meuTime.SubistituirTitular(nome, new Jogador(6, "Rafael", "Zagueiro"));

            meuTime.ExcluirTitular("Pedro");

            meuTime.ExcluirReserva("Felipe");

            meuTime.GerarArqTime("Time_Atletico");

            Console.WriteLine("Teste finalizado!");

            Console.ReadLine();
        }
    }
}
