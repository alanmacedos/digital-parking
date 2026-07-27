public class ParkingLot
{
    Dictionary<int, Vehicle> parkingSpaces = new();

    public ParkingLot (int quantityParkingSpaces)
    {
        parkingSpaces = new Dictionary<int, Vehicle>();

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

    public int? SelectParkingSpace(List<int> spacesAvailable)
    {
        // Verify if there is a free space to park
        if (spacesAvailable.Count == 0)
        {
            return null;
        }

        // Randomly selects a place to park
        Random random = new Random();
        int randomIndex = random.Next(spacesAvailable.Count);
        int selectedSpace = spacesAvailable[randomIndex];
        return selectedSpace;
    }

    // public void DisplayNoSpaceAvailableMessage()
    // {
    //     Console.WriteLine("Infelizmente não temos vaga disponível no momento :(");
    // }

    public void ParkVehicle (int selectedSpace, Vehicle vehicle)
    {
        parkingSpaces[selectedSpace] = vehicle;
        VehicleParkedMessage(vehicle, selectedSpace);
    }

    public void VehicleParkedMessage(Vehicle vehicle, int selectedSpace)
    {
        Console.WriteLine($"Veículo({vehicle.Plate}) estacionado na vaga {selectedSpace} ;)");
    }

    public void ExitVehicle(Vehicle vehicle)
    {
        foreach (var parkingSpace in parkingSpaces)
        {
            if (parkingSpace.Value == vehicle)
            {
                parkingSpaces[parkingSpace.Key] = null!;

                ExitVehicleMessage(vehicle);
                break;
            }

            else
            {
                Console.WriteLine("Veículo não consta no estacionamento.");
            }
        }
    }

    public void ExitVehicleMessage(Vehicle vehicle)
    {
        Console.WriteLine($"O veículo de placa: {vehicle.Plate} foi retirado do estacionamento.");
    }
}
