public class ParkingLot
{
    Dictionary<int, string> parkingSpaces = new();

    public ParkingLot (int quantityParkingSpaces)
    {
        parkingSpaces = new Dictionary<int, string>();

        for (int i = 1; i <= quantityParkingSpaces; i++)
        {
            parkingSpaces.Add(i, null!);
        }
    }

    public List<int> ParkingSpacesAvailable()
    {
        List<int> spacesAvailable = new List<int>();

        foreach (var space in parkingSpaces)
        {
            if (space.Value == null)
            {
                spacesAvailable.Add(space.Key);
            }
        }

        return spacesAvailable;
    }

    public int SelectParkingSpace(List<int> spacesAvailable)
    {
        // Verify if there is a free space to park
        if (spacesAvailable.Count == 0)
        {
            Console.WriteLine("Não temos vagas disponíveis no momento :(");
        }

        // Select a place to park
        Random random = new Random();
        int randomIndex = random.Next(spacesAvailable.Count);
        int selectedSpace = spacesAvailable[randomIndex];
        return selectedSpace;
    }

    public string DisplayNoSpaceAvailableMessage()
    {
        return "Infelizmente não temos vaga disponível no momento :(";
    }

    public void ParkCar (int selectedSpace, string plate)
    {
        parkingSpaces[selectedSpace] = plate;

        Console.WriteLine($"O carro de placa '{plate}' foi estacionado na vaga {parkingSpaces[selectedSpace]}");
    }
}

