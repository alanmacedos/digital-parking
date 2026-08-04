public class ParkingLot
{
    private readonly Dictionary<int, ParkingSession?> parkingSpaces = new();

    public ParkingLot (int quantityParkingSpaces)
    {
        for (int space = 1; space <= quantityParkingSpaces; space++)
        {
            parkingSpaces.Add(space, null);
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

    public void ParkVehicle (int selectedSpace, ParkingSession session)
    {
        if (VehicleIsAlreadyParked(session.Vehicle.Plate))
        {
            Console.WriteLine($"Este veículo ({session.Vehicle.Plate})já está estacionado.");
            return;
        }

        if (!ParkingSpaceExists(selectedSpace))
        {
            Console.WriteLine($"A vaga {selectedSpace} não existe");
            return;
        }

        if (!ParkingSpaceIsAvailable(selectedSpace))
        {
            Console.WriteLine($"A vaga {selectedSpace} está ocupada.");
            return;
        }

        parkingSpaces[selectedSpace] = session;
    }

    private bool VehicleIsAlreadyParked(string plate)
    {
        foreach (ParkingSession? session in parkingSpaces.Values)
        {
            if (session != null && session.Vehicle.Plate == plate)
            {
                return true;
            }
        }

        return false;
    }

    private bool ParkingSpaceExists (int selectedSpace)
    {
        return parkingSpaces.ContainsKey(selectedSpace);
    }

    private bool ParkingSpaceIsAvailable (int selectedSpace)
    {
        return parkingSpaces[selectedSpace] == null;
    }

    public void ExitVehicle(Dictionary<int, ParkingSession?> parkingSpaces, ParkingSession session)
    {
        foreach (var item in parkingSpaces)
        {
            if (item.Value == session)
            {
                parkingSpaces[item.Key] = null;
                break;
            }
        }
    }

    public void ExpectedExitTime(Dictionary<int, ParkingSession?> parkingSpaces)
    {
        var exits = new List<(int space, DateTime expectedExit)>();

        foreach (var space in parkingSpaces)
        {
            if (space.Value != null)
            {
                DateTime exit = space.Value.EntryTime.AddMinutes(space.Value.ContractedMinutes);

                exits.Add((space.Key, exit));
            }
        }

        var orderedExits = exits.OrderBy(exit => exit.expectedExit).ToList();

        foreach (var exit in orderedExits)
        {
            Console.WriteLine($"Vaga {exit.space} - Liberação prevista: {exit.expectedExit:HH:mm}");
        }
    }
}
