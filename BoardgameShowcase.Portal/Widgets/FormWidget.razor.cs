using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class FormWidget
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
    }
}
