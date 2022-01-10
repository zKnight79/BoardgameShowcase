using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class ErrorMessageWidget
    {
        [Parameter, EditorRequired] public string? ErrorMessage { get; set; }
    }
}
