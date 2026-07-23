// functions

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
}

int DisplayMenu()
{
    Console.WriteLine(@"Escolha uma das opções abaixo:
    1- Quero estacionar meu veículo
    2- Quero retirar meu veículo
    ");

    return int.Parse(Console.ReadLine()!);
}

Vehicle CreateVehicle()
{
    Console.WriteLine("\nQual seu nome?\n");
    string owner = Console.ReadLine()!;
    
    Console.WriteLine("\nQual a placa do seu veículo?\n");
    string plate = Console.ReadLine()!;

    Console.WriteLine("\nQual o modelo do veículo?\n");
    string model = Console.ReadLine()!;

    return new Vehicle(owner, plate, model);
}

// calling functions
new ParkingLot(5);
DisplayWelcomeMessage();
int menuOption = DisplayMenu();

switch(menuOption)
{
    case 1 :
        CreateVehicle();
        break;

    case 2 :
        // ExitVheicle();
        break;


    case 3 :
        // ShowParkedVehicles();
        break;

}

