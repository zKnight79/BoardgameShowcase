using BoardgameShowcase.Common;

namespace BoardgameShowcase.Model.Entity
{
    /// <summary>
    /// The generic entity model for all the models.
    /// </summary>
    public abstract class GenericEntity : GenericUiObject, ICloneable
    {
        /// <summary>
        /// Get or set the unique ID of the entity.<br/>
        /// A <see langword="null"/>, <see cref="string.Empty"/> or white-space characters value means a new entity.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Get if the entity is a new entity or not.
        /// </summary>
        public bool IsNew => string.IsNullOrWhiteSpace(Id);

        public override string ToString()
        {
            return $"[{GetType().Name}]{{ {nameof(Id)} = {Id} }}";
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>
        /// If not new : The hash code of the unique ID.<br/>
        /// If new : <inheritdoc/>
        /// </returns>
        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? base.GetHashCode();
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object.<br/>
        /// The equality is based on the instance type of the objects,
        /// and :<br/>
        /// - If not new : on the <seealso cref="Id"/>.<br/>
        /// - If new : on the <seealso cref="GenericUiObject.UiId"/>
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
