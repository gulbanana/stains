namespace Stains.State;

public record Room(string Name, string Path)
{
    public Action DoMove { get; set; }
}