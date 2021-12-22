using BoardgameShowcase.Common.Utility;

namespace BoardgameShowcase.Common
{
    public abstract class GenericUiObject
    {
        public string UiId { get; } = StringUtil.NewGuid();

        public override int GetHashCode()
        {
            return UiId.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return obj is GenericUiObject uiObject
                   && uiObject.GetType() == GetType()
                   && uiObject.UiId == UiId;
        }
    }
}
