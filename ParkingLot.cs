public class ParkingLot
{
    Dictionary<int, string> parkingSpaces = new();

    // int quantityParkingSpaces = 5;

    public ParkingLot (int quantityParkingSpaces)
    {
        parkingSpaces = new Dictionary<int, string>();

        for (int i = 0; i <= quantityParkingSpaces; i++)
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

    public void ParkCar (string plate)
    {
        List<int> spacesAvailable = ParkingSpacesAvailable();

        if (spacesAvailable.Count == 0)
        {
            Console.WriteLine("Não temos vagas disponíveis no momento :(");
            return;
        }

        Random random = new Random();
        int randomIndex = random.Next(spacesAvailable.Count);
        int selectedSpace = spacesAvailable[randomIndex];

        parkingSpaces[selectedSpace] = plate;

        Console.WriteLine($"O carro de placa '{plate}' foi estacionado na vaga {parkingSpaces[selectedSpace]}");
    }
}
