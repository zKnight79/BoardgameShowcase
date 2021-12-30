namespace BoardgameShowcase.Model.Entity
{
    /// <summary>
    /// The entity model for a publisher.
    /// </summary>
    public class Publisher : GenericEntity
    {
        /// <summary>
        /// Get or set the name of the publisher.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
