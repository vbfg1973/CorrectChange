using System.Collections;
using System.Reflection;
using Towel;

namespace CorrectChange.Tests.Architectural.Data.Abstract
{
    /// <summary>
    ///     Uses reflection to return classes, properties and their XML documentation
    /// </summary>
    public abstract class AbstractAllClassesPropertyDocumentationCommentsClassData : IEnumerable<object[]>
    {
        protected Assembly? Assembly;

        public IEnumerator<object[]> GetEnumerator()
        {
            Assembly?.LoadXmlDocumentation();

            // Grab types from assembly 
            var types = Assembly?
                .GetExportedTypes();

            // Limit to classes that are not exceptions (many internal public properties beyond our control)
            foreach (var type in types!.Where(t =>
                         !t.IsAssignableFrom(typeof(Exception)) && !t.Name.EndsWith("Exception")))
            {
                var properties = type.GetProperties();

                // Typename, property and any documentation comment Towel finds 
                foreach (var propertyInfo in properties)
                    yield return new object[]
                    {
                        type.Name,
                        propertyInfo.Name,
                        type.Namespace ?? string.Empty,
                        propertyInfo.GetDocumentation()?.Trim()!
                    };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}