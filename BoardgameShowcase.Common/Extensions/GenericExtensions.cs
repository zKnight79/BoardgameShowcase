using System.Reflection;

namespace BoardgameShowcase.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for almost any type.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Call every private, unherited, parameterless method of an object instance,
        /// returning a given type.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="instance">The instance of the object.</param>
        /// <param name="returnType">The return type of the methods to call.</param>
        public static void CallPrivateUnheritedParameterlessMethodsReturning<TInstance>(this TInstance instance, Type returnType)
        {
            if (instance is not null)
            {
                Type objType = instance.GetType();
                IEnumerable<MethodInfo> methods = objType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(
                        x => x.DeclaringType == objType
                        && x.IsPrivate
                        && x.ReturnType == returnType
                        && x.GetParameters().Length == 0
                    );
                foreach (MethodInfo method in methods)
                {
                    _ = method.Invoke(instance, null);
                }
            }
        }
    }
}
