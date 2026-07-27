using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class UI
{
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

        Console.WriteLine("\nSeja bem vindo(a) ao Digital Parking!\nGerencie vagas, veículos e cobranças de estacionamento de forma simples e eficiente.");

        Thread.Sleep(2500);
    }

    void DisplayMenu()
    {
        Console.WriteLine(@"Escolha uma das opções abaixo:
        1- Quero estacionar meu veículo
        2- Quero retirar meu veículo
        ");

        GetOption();
    }

    int GetOption()
    {
        return int.Parse(Console.ReadLine()!);
    }

    


    //     Console.WriteLine("\nQual seu nome?");
    //     string owner = Console.ReadLine()!;

    //     Console.WriteLine("\nQual a placa do seu veículo?");
    //     string plate = Console.ReadLine()!;

    //     Console.WriteLine("\nQual o modelo do veículo?");
    //     string model = Console.ReadLine()!;

    //     Console.WriteLine();

    // return new Vehicle(owner, plate, model);

    // public void Run()
    // {
    //     switch
    // }
}