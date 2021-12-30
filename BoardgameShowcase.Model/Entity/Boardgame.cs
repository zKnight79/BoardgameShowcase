using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity.Enumeration;

namespace BoardgameShowcase.Model.Entity
{
    /// <summary>
    /// The entity model for a boardgame.
    /// </summary>
    public class Boardgame : GenericEntity
    {
        /// <summary>
        /// Get or set the title of the boardgame.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Get or set the minimum number of player needed to play the boardgame.
        /// </summary>
        public int MinimumPlayerCount { get; set; } = 1;
        /// <summary>
        /// Get or set the maximum number of player allowed to play the boardgame.
        /// </summary>
        public int MaximumPlayerCount { get; set; } = 99;
        /// <summary>
        /// Get or set the approximate time, in minutes, of an average game of the boardgame.
        /// </summary>
        public int ApproximateGameTimeInMinutes { get; set; } = 60;
        /// <summary>
        /// Get or set the minimum age needed to play the boardgame.
        /// </summary>
        public int MinimumPlayerAge { get; set; } = 8;
        /// <summary>
        /// Get or set the unique ID of the boardgame's author.
        /// </summary>
        public string AuthorId { get; set; } = default!;
        /// <summary>
        /// Get or set the unique ID of the boardgame's illustrator.
        /// </summary>
        public string IllustratorId { get; set; } = default!;
        /// <summary>
        /// Get or set the unique ID of the boardgame's publisher.
        /// </summary>
        public string PublisherId { get; set; } = default!;
        #region THEMES
        private readonly List<Theme> _themes = new();
        /// <summary>
        /// Get or set the themes of the boardgame.
        /// </summary>
        public IEnumerable<Theme> Themes
        {
            get => _themes;
            set => _themes.SetValues(value);
        }
        #endregion
        #region MECHANISMS
        private readonly List<Mechanism> _mechanisms = new();
        /// <summary>
        /// Get or set the mechanisms of the boardgame.
        /// </summary>
        public IEnumerable<Mechanism> Mechanisms
        {
            get => _mechanisms;
            set => _mechanisms.SetValues(value);
        }
        #endregion
        /// <summary>
        /// Get or set the category of the boardgame.
        /// </summary>
        public Category Category { get; set; }
    }
}
