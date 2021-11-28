using Microsoft.AspNetCore.Components;
namespace Stains;

public class Connected : ComponentBase, IDisposable
{
    [CascadingParameter] public State.Game State { get; set; }

    protected override void OnInitialized()
    {
        State.Updated += StateHasChanged;
    }

    public void Dispose()
    {
        State.Updated -= StateHasChanged;
    }
}

public abstract class Connected<T> : ComponentBase, IDisposable
{
    [CascadingParameter] public State.Game Game { get; set; }
    protected T State;

    protected abstract T Project(State.Game game);

    protected override void OnInitialized()
    {
        Game.Updated += StateHasChanged;
        State = Project(Game);
    }

    public void Dispose()
    {
        Game.Updated -= StateHasChanged;
    }
}