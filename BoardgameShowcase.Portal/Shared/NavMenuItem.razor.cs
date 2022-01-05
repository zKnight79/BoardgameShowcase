using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BoardgameShowcase.Portal.Shared
{
    public partial class NavMenuItem
    {
        [Parameter, EditorRequired] public string HRef { get; set; } = string.Empty;
        [Parameter, EditorRequired] public string Label { get; set; } = string.Empty;
        [Parameter, EditorRequired] public string FAIconClass { get; set; } = string.Empty;
        [Parameter] public NavLinkMatch LinkMatch { get; set; }
    }
}
