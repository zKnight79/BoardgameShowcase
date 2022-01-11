using BoardgameShowcase.Common.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BoardgameShowcase.Portal.Widgets
{
    public partial class ButtonWidget
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter] public string? Title { get; set; }
        [Parameter] public string? CustomCssClass { get; set; }

        private string BaseCssClass => "px-2 py-1 w-32 rounded-xl font-medium shadow-md focus:outline-none focus:ring";
        protected string? InternalCssClass { get; set; }

        private string FinalCssClass => StringUtil.JoinNonNullOrWhiteSpace(" ", BaseCssClass, InternalCssClass, CustomCssClass);
    }
}
