namespace BoardgameShowcase.Model.Entity
{
    /// <summary>
    /// The entity model for an author.
    /// </summary>
    public class Author : GenericEntity
    {
        /// <summary>
        /// Get or set the name of the author.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
