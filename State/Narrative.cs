using Ink.Runtime;

namespace Stains.State;

public class Narrative
{
    private readonly Story story;
    private int pseq;
    private bool continueOnce;

    public readonly List<Paragraph> Log = new();
    public readonly List<(int, Paragraph)> Choices = new();
    public readonly List<string> Tags = new();
    public readonly List<(int, string)> Moves = new();

    public Narrative(Story story)
    {
        this.story = story;
        continueOnce = true;
    }

    public void Update()
    {
        if (continueOnce)
        {
            continueOnce = false;
            Choices.Clear();

            Log.Add(new(pseq++, story.Continue()));

            Tags.AddRange(story.currentTags);
            
            if (story.canContinue)
            {
                Choices.Add(GetContinue());
            }
            else
            {
                foreach (var choice in story.currentChoices)
                {
                    if (choice.text.StartsWith("move:"))
                    {
                        Moves.Add((choice.index, choice.text[5..]));
                    }
                    else
                    {
                        Choices.Add((choice.index, new(pseq + choice.index, choice.text)));
                    }
                }
            }
        }
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