public class ParkingSession
{
    public Vehicle Vehicle { get; set; }
    public int ContractedMinutes { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    
    public DateTime ExpectedExitTime => EntryTime.AddMinutes(ContractedMinutes); 

    public ParkingSession(Vehicle vehicle, int contractedMinutes, DateTime entryTime)
    {
        Vehicle = vehicle;
        ContractedMinutes = contractedMinutes;
        EntryTime = entryTime;
    }

    public void RegisterExit(DateTime exitTime)
    {
        ExitTime = exitTime;
    }
}

