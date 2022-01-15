using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public abstract class StylableContainerBase : StylableComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}
