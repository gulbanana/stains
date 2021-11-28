namespace Stains.State;

public record Room(string Name, string Path)
{
    public bool IsVisible { get; private set; }

    public void Enable() => IsVisible = true;
}