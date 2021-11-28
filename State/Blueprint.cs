namespace Stains.State;

public class Blueprint
{    
    public Room Lobby { get; }
    public Room CovenRoom { get; }
    public Room CurrentLocation { get; set; }

    public Blueprint()
    {
        Lobby = new Room("Lobby", "M 525 500 h 150 l 25 25 v 75 h -200 v -75 z");
        Lobby.Enable();
        CovenRoom = new Room("Coven Room", "M 550 300 h 100 v 150 h -100 z");
        CurrentLocation = Lobby;
    }
    
    public void Update(TimeSpan elapsed)
    {        
        var delta = elapsed.TotalSeconds;
    }

    public IEnumerable<Room> GetAllRooms()
    {
        yield return Lobby;
        yield return CovenRoom;
    }

    public IEnumerable<Room> GetVisibleRooms()
    {
        yield return Lobby;
        yield return CovenRoom;
    }
}