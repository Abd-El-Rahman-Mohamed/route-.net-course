namespace MovieTicketBookingSystem;

public class Projector
{
    private bool _isCurrentlyWorking { get; set; }

    public Projector()
    {
    }

    public void StarProjector()
    {
        _isCurrentlyWorking = true;
    }
    
    public void StopProjector()
    {
        _isCurrentlyWorking = false;
    }
}