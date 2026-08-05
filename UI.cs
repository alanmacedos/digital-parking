using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

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
                    ExitVehicle();
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

        Console.Write("\nPlaca(4 letras + 3 n°) do veículo: ");
        string plate = Console.ReadLine()!;

        while (!IsPlateValid(plate))
        {
            Console.WriteLine("Placa inválida. Digite novamente (4 letras + 3 n°): ");
            plate = Console.ReadLine()!;
        }

        Console.Write("\nModelo: ");
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

    public void ExitVehicle()
    {
        Console.Write("\nPlaca(4 letras + 3 n°) do veículo: ");
        string plate = Console.ReadLine()!;

        while (!IsPlateValid(plate))
        {
            Console.WriteLine("Placa inválida. Digite novamente (4 letras + 3 n°): ");
            plate = Console.ReadLine()!;
        }

        Console.WriteLine("\nData e horário de saída (dd/MM/yyyy HH:mm): ");
        DateTime exitTime;

        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out exitTime))
        {
            Console.WriteLine("\nData inválida. Digite novamente (dd/MM/yyyy HH:mm): ");
        }

        ParkingSession? session = parkingLot.ExitVehicle(plate, exitTime);

        if (session == null)
        {
            Console.WriteLine("Não há veículo estacionado com essa placa.");
            return;
        }

        Console.WriteLine("Veículo encontrado!");

        PaymentService paymentService = new PaymentService();
        decimal amount = paymentService.CalculateParkingFee(session!);

        string mehtod = PaymentMethod(amount);

        if (mehtod == "Pix" || mehtod == "Dinheiro")
        {
            amount = (amount / 100) * 95;
        }

        DateTime paidAt = exitTime.AddMinutes(2);

        Payment payment = new Payment(amount, mehtod, paidAt);

        PaymentSummary(payment, session);
    }

    private bool IsPlateValid(string plate)
    {
        if (plate.Length != 7)
        {
            return false;
        }

        for (int i = 0; i < 4; i++)
        {
            if (!char.IsLetter(plate[i]))
            {
                return false;
            }
        }

        for (int i = 4; i < 7; i++)
        {
            if (!char.IsDigit(plate[i]))
            {
                return false;
            }
        }

        return true;
    }

    private string PaymentMethod(decimal amount)
    {
        Console.WriteLine($@"O valor da permanência foi de R${amount}.
        
        Métodos de pagamento:
        1 - Pix / 5% de desconto
        2 - Dinheiro / 5% de desconto
        3 - Débito
        4 - Crédito (à vista)
        ");

        int option = GetOption();

        switch (option)
        {
            case 1:
                return "Pix";

            case 2:
                return "Dinheiro";

            case 3:
                return "Débito";

            case 4:
                return "Crédito";

            default:
                throw new InvalidOperationException("Valor inválido.");
        }
    }

    // display payment summary before pay for real
    private void DisplayPaymentSummary(PaymentSummary summary)
    {
        Console.WriteLine($@"
        ==================================================
                          PAYMENT SUMMARY
        ==================================================

        Placa do veículo:      {pa}
        Proprietário:          {session.Vehicle.Owner}
        Modelo:                {session.Vehicle.Model}              

        Horário de Entrada:    {session.EntryTime:dd/MM/yyyy HH:mm}
        Horário de Saída:      {session.ExitTime:dd/MM/yyyy HH:mm}

        Tempo Contratado:      {FormatDurarition(contractedTime)}
        Tempo Estacionado:     {FormatDurarition(timeParked)}
        Tempo Adicional:       {FormatDurarition(additionalTime)}

        --------------------------------------------------
        Valor total:           R$ {payment.Amount:C2}
        --------------------------------------------------

        Método de pagamento:   {payment.Method}
        Data/Hora:             {payment.PaidAt}

        Pressione ENTER para confirmar o pagamento...");

        PayConfirmation();
    }

    private string FormatDurarition(TimeSpan duration)
    {
        return $"{(int)duration.TotalHours}h {duration.Minutes:00}min";
    }

    private void PayConfirmation()
    {
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            
        }

        Console.WriteLine("Pagamento confirmado com sucesso.");
        Console.WriteLine("Volte sempre!");
    }

}