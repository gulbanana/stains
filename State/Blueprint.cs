namespace Stains.State;

public class Blueprint
{    
    public readonly Dictionary<string, Room> AllRooms = new(StringComparer.OrdinalIgnoreCase);
    public readonly List<string> AllDoors = new();
    public Room CurrentLocation { get; set; }

    public Blueprint()
    {
        AllRooms["lobby"] = new Room("Lobby", "M 525 500 h 150 l 25 25 v 75 h -200 v -75 z");
        AllRooms["coven_room"] = new Room("Coven Room", "M 550 300 h 100 v 150 h -100 z");
        AllRooms["bathroom"] = new Room("Bathroom", "M 750 500 h 100 v 100 h -100 z");
        AllRooms["locked_room"] = new Room("Locked Room", "M 350 500 h 100 v 100 h -100 z");

        AllDoors.Add("M 600 500 v -50");
        AllDoors.Add("M 700 550 h 50");

        CurrentLocation = AllRooms["lobby"];
    }
    
    public void Update(TimeSpan elapsed)
    {        
        var delta = elapsed.TotalSeconds;
    }

    public void ClearMoves()
    {
        foreach (var room in AllRooms.Values)
        {
            room.DoMove = null;
        };
    }
}