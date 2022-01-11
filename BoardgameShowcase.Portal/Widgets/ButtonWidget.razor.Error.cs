namespace BoardgameShowcase.Portal.Widgets
{
    public class ButtonErrorWidget : ButtonWidget
    {
        public ButtonErrorWidget()
        {
            InternalCssClass = "text-on-error shadow-error bg-error hover:bg-error-light active:bg-error-dark focus:ring-error-lighter";
        }
    }
}
