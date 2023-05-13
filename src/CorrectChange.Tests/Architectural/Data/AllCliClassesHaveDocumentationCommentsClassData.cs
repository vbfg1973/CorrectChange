using System.Collections;
using System.Reflection;
using CorrectChange.Domain.Support;
using CorrectChange.Support;
using Towel;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Finds all classes in CLI Assembly and returns documentation comments found in XML for each
    /// </summary>
    public class AllCliClassesHaveDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllCliClassesHaveDocumentationCommentsClassData()
        {
            // Get the appropriate assembly and XML documentation
            _assembly = CliAssemblyReference.Assembly;
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