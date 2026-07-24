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


// calling functions
ParkingLot parkingLot = new ParkingLot(5);
DisplayWelcomeMessage();
int menuOption = DisplayMenu();

switch(menuOption)
{
    case 1 :
        // CreateVehicle();
        break;

    case 2 :
        // ExitVheicle();
        break;


    case 3 :
        // ShowParkedVehicles();
        break;

}

Vehicle veiculo = new Vehicle("flexa", "IOF5678", "New Fiesta");
veiculo.CreateVehicle();

List<int> spacesAvailable = parkingLot.ParkingSpacesAvailable();

foreach (int space in spacesAvailable)
{
    Console.WriteLine($"A vaga {space} está disponível.");
}

