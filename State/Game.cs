using Ink.Runtime;
namespace Stains.State;

public class Game
{
    private Story story;
    private int pseq;

    public readonly List<Paragraph> Narrative = new();
    public readonly List<(int, Paragraph)> Choices = new();
    private bool continueOnce;

    public Pulse r;
    public string rname = "R";
    public Pulse g;
    public string gname = "G";
    public Pulse b;
    public string bname = "B";

    public event Action Updated;

    public Game(string json)
    {
        story = new Story(json);
        // TODO set event handlers, particularly Story.onError

        Narrative.Add(new(pseq++, story.Continue()));
        Choices.Add(GetContinue());
    }

    public void Update(TimeSpan elapsed)
    {
        var delta = elapsed.TotalSeconds;

        r.Tick(delta);
        g.Tick(delta/2.0);
        b.Tick(delta/3.0);

        if (continueOnce)
        {
            Choices.Clear();
            continueOnce = false;

            Narrative.Add(new(pseq++, story.Continue()));

            foreach (var tag in story.currentTags)
            {
                Console.WriteLine(tag);
                switch (tag)
                {
                    case "introduce: Nigel":
                        rname = "Nigel Planet";
                        break;

                    case "introduce: Brenda":
                        gname = "Brenda Avatar";
                        break;

                    case "introduce: Cops":
                        bname = "The Cops";
                        break;
                }
            }
            
            if (story.canContinue)
            {
                Choices.Add(GetContinue());
            }
            else
            {
                foreach (var choice in story.currentChoices)
                {
                    Choices.Add((choice.index, new(pseq + choice.index, choice.text)));
                }
            }
        }

        Updated?.Invoke();
    }

    public void Choose(int index)
    {
        if (index != -1)
        {
            story.ChooseChoiceIndex(index);
        }

        if (story.canContinue)
        {
            continueOnce = true;
        }
    }

    private (int, Paragraph) GetContinue()
    {
        return (-1, new(-1, "(continue)", true));
    }
}