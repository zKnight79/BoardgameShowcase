namespace BoardgameShowcase.Portal.Shared
{
    public partial class NavMenu
    {
        private bool CollapseNavMenu { get; set; } = true;

        private void ToggleNavMenu()
        {
            CollapseNavMenu = !CollapseNavMenu;
        }
    }
}
