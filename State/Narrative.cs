using Ink.Runtime;

namespace Stains.State;

public class Narrative
{
    private Story story;
    private int pseq;

    public readonly List<Paragraph> Log = new();
    public readonly List<(int, Paragraph)> Choices = new();
    public readonly List<string> Tags = new();
    private bool continueOnce;

    public Narrative(Story story)
    {
        this.story = story;
        Log.Add(new(pseq++, story.Continue()));
        Choices.Add(GetContinue());
    }

    public void Update()
    {
        Tags.Clear();            

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
                    Choices.Add((choice.index, new(pseq + choice.index, choice.text)));
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