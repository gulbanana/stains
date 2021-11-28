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

        foreach (var tag in Narrative.Tags)
        {
            switch (tag)
            {
                case "introduce: Nigel":
                    Blueprint.rname = "Nigel Planet";
                    break;

                case "introduce: Brenda":
                    Blueprint.gname = "Brenda Avatar";
                    break;

                case "introduce: Cops":
                    Blueprint.bname = "The Cops";
                    break;
            }
        }

        Updated?.Invoke();
    }
}