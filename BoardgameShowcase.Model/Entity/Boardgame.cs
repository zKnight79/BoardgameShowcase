using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity.Enumeration;

namespace BoardgameShowcase.Model.Entity
{
    public class Boardgame : GenericEntity
    {
        public string Title { get; set; } = string.Empty;
        public int MinimumPlayerCount { get; set; } = 1;
        public int MaximumPlayerCount { get; set; } = 99;
        public int ApproximateGameTimeInMinutes { get; set; } = 60;
        public int MinimumPlayerAge { get; set; } = 8;
        public string AuthorId { get; set; } = default!;
        public string IllustratorId { get; set; } = default!;
        public string PublisherId { get; set; } = default!;
        #region THEMES
        private readonly List<Theme> _themes = new();
        public IEnumerable<Theme> Themes
        {
            get => _themes;
            set => _themes.SetValues(value);
        }
        #endregion
        #region MECHANISMS
        private readonly List<Mechanism> _mechanisms = new();
        public IEnumerable<Mechanism> Mechanisms
        {
            get => _mechanisms;
            set => _mechanisms.SetValues(value);
        }
        #endregion
        public Category Category { get; set; }
    }
}
