namespace BoardgameShowcase.Model.Entity
{
    /// <summary>
    /// The entity model for an illustrator.
    /// </summary>
    public class Illustrator : GenericEntity
    {
        /// <summary>
        /// Get or set the name of the illustrator.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
