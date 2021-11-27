namespace Stains.State;

public class Paragraph
{
    public int Seq;
    public readonly string Text;
    public readonly bool Center;
    public bool Seen;

    public Paragraph(int seq, string text, bool center = false)
    {
        Seq = seq;
        Text = text;
        Center = center;
    }
}