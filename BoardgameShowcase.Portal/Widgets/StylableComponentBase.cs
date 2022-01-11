using BoardgameShowcase.Common.Utility;
using Microsoft.AspNetCore.Components;

namespace BoardgameShowcase.Portal.Widgets
{
    public abstract class StylableComponentBase : ComponentBase
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string? CustomCssClass { get; set; }
        [Parameter] public bool SkipBaseCssClass { get; set; }

        protected virtual string? BaseCssClass { get; }

        protected string FinalCssClass => StringUtil.JoinNonNullOrWhiteSpace(" ", SkipBaseCssClass ? null : BaseCssClass, CustomCssClass);
    }
}
