using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class UI
{
    public void Run()
    {
        DisplayWelcomeMessage();

        bool applicationRunning = true;

        while (applicationRunning)
        {
            DisplayMenu();
            int option = GetOption();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Entrada de veículo será implementada");
                    break;
                
                case 2:
                    Console.WriteLine("Saída de veículo será implementada depois.");
                    break;

                case 3:
                    Console.WriteLine("Listagem de vagas será implementada depois");  
                    break;

                case 0:
                    applicationRunning = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        DisplayGoodByeMessage();
    }

    ParkingLot parkingLot = new ParkingLot(5);

    void DisplayWelcomeMessage()
    {
        Console.WriteLine(@"
        ██████╗ ██╗ ██████╗ ██╗████████╗ █████╗ ██╗
        ██╔══██╗██║██╔════╝ ██║╚══██╔══╝██╔══██╗██║
        ██║  ██║██║██║  ███╗██║   ██║   ███████║██║
        ██║  ██║██║██║   ██║██║   ██║   ██╔══██║██║
        ██████╔╝██║╚██████╔╝██║   ██║   ██║  ██║███████╗
        ╚═════╝ ╚═╝ ╚═════╝ ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝

        ██████╗  █████╗ ██████╗ ██╗  ██╗██╗███╗   ██╗ ██████╗
        ██╔══██╗██╔══██╗██╔══██╗██║ ██╔╝██║████╗  ██║██╔════╝
        ██████╔╝███████║██████╔╝█████╔╝ ██║██╔██╗ ██║██║  ███╗
        ██╔═══╝ ██╔══██║██╔══██╗██╔═██╗ ██║██║╚██╗██║██║   ██║
        ██║     ██║  ██║██║  ██║██║  ██╗██║██║ ╚████║╚██████╔╝
        ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝ ╚═════╝");

        Console.WriteLine("\nSeja bem vindo(a) ao Digital Parking!\nGerencie vagas, veículos e cobranças.");

        Thread.Sleep(2500);
    }

    void DisplayMenu()
    {
        Console.WriteLine(@"
        Escolha uma das opções abaixo:

        1 - Estacionar veículo
        2 - Retirar veículo
        3 - Ver vagas e veículos estacionados
        0 - Sair
        ");
    }

    int GetOption()
    {
        Console.Write("Opção: ");
        string? input = Console.ReadLine();

        return int.TryParse(input, out int option) ? option : -1;
    }

    private void DisplayGoodByeMessage()
    {
        Console.WriteLine("Obrigado por utilizar o Digital Parking. Até Logo!");
    }

}