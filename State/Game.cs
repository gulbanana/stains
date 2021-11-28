using Ink.Runtime;
namespace Stains.State;

public class Game
{
    public Narrative Narrative { get; }
    public Blueprint Blueprint { get; }
    public event Action Updated;

    public Game(string json)
    {
        var story = new Story(json);
        // TODO set event handlers, particularly Story.onError
        Narrative = new Narrative(story);
        Blueprint = new Blueprint();
    }

    public void Update(TimeSpan elapsed)
    {
        Narrative.Update();
        Blueprint.Update(elapsed);

        if (Narrative.Tags.Any())
        {
            foreach (var tag in Narrative.Tags)
            {
                ProcessTag(tag);
            }
            Narrative.Tags.Clear();            
        }

        if (Narrative.Moves.Any())
        {
            foreach (var move in Narrative.Moves)
            {
                Blueprint.AllRooms[move.Item2].DoMove = () => 
                {
                    Blueprint.ClearMoves();
                    Narrative.Choose(move.Item1);
                };
            }
            Narrative.Moves.Clear();
        }

        Updated?.Invoke();
    }

    private void ProcessTag(string tag)
    {
        if (tag.StartsWith("move"))
        {
            var roomName = tag[5..];
            var room = Blueprint.AllRooms[roomName];
            Blueprint.CurrentLocation = room;
            return;
        }

        Console.WriteLine("UNKNOWN TAG " + tag);
    }
}