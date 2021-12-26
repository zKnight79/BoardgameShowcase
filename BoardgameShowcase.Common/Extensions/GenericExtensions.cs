using System.Reflection;

namespace BoardgameShowcase.Common.Extensions
{
    public static class GenericExtensions
    {
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
