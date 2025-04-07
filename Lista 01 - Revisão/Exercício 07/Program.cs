using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento("Estacionamento Central", 30);

            estacionamento.Estacionar("ABC-1234");
            estacionamento.Estacionar("DEF-5678");
            estacionamento.Estacionar("GHI-9012");
            estacionamento.Estacionar("JKL-3456");
            estacionamento.Estacionar("MNO-7890");

            Console.WriteLine("\nOcupação do estacionamento:\n");
            estacionamento.ExibirOcupacao();

            string placaBusca = "GHI-9012";
            int vagaEncontrada = estacionamento.BuscarNumVaga(placaBusca);
            if (vagaEncontrada != -1)
                Console.WriteLine($"\nO veículo com placa {placaBusca} está estacionado na vaga {vagaEncontrada + 1}.");
            else
                Console.WriteLine($"\nO veículo com placa {placaBusca} não foi encontrado no estacionamento.");

            estacionamento.Retirar("DEF-5678");
            Console.WriteLine("\n Ocupação após a retirada de um veículo:\n");
            estacionamento.ExibirOcupacao();

            estacionamento.Estacionar("PQR-1111");
            estacionamento.Estacionar("STU-2222");
            estacionamento.Estacionar("VWX-3333");

            Console.WriteLine("\nOcupação após estacionar mais 3 veículos:\n");
            estacionamento.ExibirOcupacao();

            Console.WriteLine($"\nQuantidade de vagas livres: {estacionamento.GetNumVagasLivres()}");
            Console.ReadLine();
        }
    }
}
