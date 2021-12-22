using BoardgameShowcase.Common;

namespace BoardgameShowcase.Model.Entity
{
    public abstract class GenericEntity : GenericUiObject
    {
        public string Id { get; set; } = default!;

        public bool IsNew => string.IsNullOrWhiteSpace(Id);

        public override string ToString()
        {
            return $"[{GetType().Name}]{{ {nameof(Id)} = {Id} }}";
        }
        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            bool areEquals = false;

            if (
                obj is GenericEntity entity
                && entity.GetType() == GetType()
                && entity.IsNew == IsNew
            )
            {
                areEquals = IsNew
                            ? base.Equals(entity)
                            : Id == entity.Id;
            }

            return areEquals;
        }
    }
}
