using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class FormBottomContainer
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}
