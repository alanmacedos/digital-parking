using System;
using System.Collections;
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
                    EnterVehicle();
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

    public void EnterVehicle()
    {
        Console.WriteLine("Para registrar a entrada do veículo precisamos saber:");

        Console.Write("Seu nome: ");
        string owner = Console.ReadLine()!;

        Console.Write("Placa do veículo: ");
        string plate = Console.ReadLine()!;

        Console.Write("Modelo: ");
        string model = Console.ReadLine()!;

        Vehicle vehicle = new Vehicle(owner, plate, model);

        Console.Write(@"
        Tempo contratado:
        1 - 30 minutos
        2 - 1 hora
        3 - 2 horas
        4 - 3 horas
        ");

        int option = GetOption();

        ParkingSession parkingSession;

        switch (option)
        {
            case 1:
                parkingSession = new ParkingSession(vehicle, 30, DateTime.Now);
                break;
            
            case 2:
                parkingSession = new ParkingSession(vehicle, 60, DateTime.Now);
                break;

            case 3:
                parkingSession = new ParkingSession(vehicle, 120, DateTime.Now);
                break;
            
            case 4:
                parkingSession = new ParkingSession(vehicle, 180, DateTime.Now);
                break;

            default:
                throw new InvalidOperationException("Valor inválido.");
        }

        List<int> spacesAvailable = parkingLot.ParkingSpacesAvailable();

        int? selectedSpace = parkingLot.SelectParkingSpace(spacesAvailable);

        if (selectedSpace is int space)
        {
            parkingLot.ParkVehicle(space, parkingSession);
        }

        else
        {
            Console.WriteLine("Não há vagas disponíveis.");
        }
    }

}