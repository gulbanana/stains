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