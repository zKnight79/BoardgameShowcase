using BoardgameShowcase.Common.Utility;

namespace BoardgameShowcase.Common
{
    /// <summary>
    /// This abstract class contains a random instance identifier
    /// that allows to know if 2 equal derived objects
    /// correspond to the same instance or not.
    /// </summary>
    public abstract class GenericUiObject
    {
        /// <summary>
        /// The random instance identifier.
        /// </summary>
        public string UiId { get; } = StringUtil.NewGuid();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>
        /// <inheritdoc/><br/>
        /// The hash code of the <seealso cref="UiId"/>
        /// </returns>
        public override int GetHashCode()
        {
            return UiId.GetHashCode();
        }
        /// <summary>
        /// <inheritdoc/><br/>
        /// The equality is based on the <seealso cref="UiId"/>,
        /// and on the instance type of the objects.
        /// </summary>
        /// <param name="obj"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public override bool Equals(object? obj)
        {
            return obj is GenericUiObject uiObject
                   && uiObject.GetType() == GetType()
                   && uiObject.UiId == UiId;
        }
    }
}
