using System.Collections;
using System.Reflection;
using CorrectChange.Domain.Support;
using Towel;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Uses reflection to return classes, properties and their XML documentation
    /// </summary>
    public class AllDomainClassesPropertyDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllDomainClassesPropertyDocumentationCommentsClassData()
        {
            // Get the appropriate assembly and XML documentation
            _assembly = DomainAssemblyReference.Assembly;
            _assembly.LoadXmlDocumentation();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            // Grab types from assembly 
            var types = _assembly
                .GetExportedTypes();

            // Limit to classes that are not exceptions (many internal public properties beyond our control)
            foreach (var type in types.Where(t =>
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