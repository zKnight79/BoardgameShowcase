namespace BoardgameShowcase.Model.Entity
{
    public abstract class GenericEntity
    {
        public string Id { get; set; } = default!;

        public bool IsNew => string.IsNullOrWhiteSpace(Id);
    }
}
