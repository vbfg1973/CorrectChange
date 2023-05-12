using System.Collections;
using System.Reflection;
using CorrectChange.Domain.Support;
using Towel;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Finds all classes in DomainAssembly and returns documentation comments found in XML for each
    /// </summary>
    public class AllClassesHaveDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllClassesHaveDocumentationCommentsClassData()
        {
            // Get the domain assembly
            _assembly = DomainAssemblyReference.Assembly;
            _assembly.LoadXmlDocumentation();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            // Grab types from assembly
            var types = _assembly
                .GetExportedTypes();

            // Limit to those ending with Dto
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