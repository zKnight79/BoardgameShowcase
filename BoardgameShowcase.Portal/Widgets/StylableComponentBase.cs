using BoardgameShowcase.Common.Utility;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public abstract class StylableComponentBase : ComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string? CustomCssClass { get; set; }

        protected virtual string? BaseCssClass { get; }

        protected string FinalCssClass => StringUtil.JoinNonNullOrWhiteSpace(" ", BaseCssClass, CustomCssClass);
    }
}
