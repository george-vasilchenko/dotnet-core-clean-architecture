using System.Linq;
using System.Reflection;

namespace NutritionManager.Crosscutting
{
    public static class ReflectionHelper
    {
        public static TDestination SyncProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);

            var sourceProperties = sourceType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var destinationProperties = destinationType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var sourceProperty in sourceProperties)
            {
                var name = sourceProperty.Name;
                var value = sourceProperty.GetValue(source);

                var destinationProperty = destinationProperties.Single(dp => dp.Name == name);

                if (destinationProperty.CanWrite)
                {
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
        }
    }
}