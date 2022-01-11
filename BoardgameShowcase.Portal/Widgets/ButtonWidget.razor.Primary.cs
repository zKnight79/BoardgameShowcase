namespace BoardgameShowcase.Portal.Widgets
{
    public class ButtonPrimaryWidget : ButtonWidget
    {
        protected override string BaseCssClass => $"{base.BaseCssClass} text-on-primary shadow-primary bg-primary hover:bg-primary-light active:bg-primary-dark focus:ring-primary-lighter";
    }
}
