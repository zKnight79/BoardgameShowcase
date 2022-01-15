using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class LinkWidget
    {
        [Parameter] public string? HRef { get; set; } 
        
        protected override string? BaseCssClass => "text-primary hover:text-secondary font-semibold underline";
    }
}
