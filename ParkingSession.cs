public class ParkingSession
{
    public Vehicle Vehicle { get; set; }
    public TimeSpan ContractedMinutes { get; set; }
    public DateTime EntryTime { get; set; }
    public DateTime ExitTime { get; set; } 
    // session.ExitTime = timeInformedByUser
}

