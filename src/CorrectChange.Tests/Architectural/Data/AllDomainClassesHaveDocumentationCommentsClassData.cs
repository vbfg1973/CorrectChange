using System.Collections;
using System.Reflection;
using CorrectChange.Domain.Support;
using Towel;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Finds all classes in DomainAssembly and returns documentation comments found in XML for each
    /// </summary>
    public class AllDomainClassesHaveDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllDomainClassesHaveDocumentationCommentsClassData()
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

            foreach (var type in types)
                yield return new object[]
                {
                    type.Name,
                    type.Namespace ?? "No namespace",
                    type.GetDocumentation()?.Trim()!
                };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}