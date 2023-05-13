using System.Collections;
using System.Reflection;
using Towel;

namespace CorrectChange.Tests.Architectural.Data.Abstract
{
    /// <summary>
    ///     Finds all classes in CLI Assembly and returns documentation comments found in XML for each
    /// </summary>
    public abstract class AbstractAllClassesHaveDocumentationCommentsClassData : IEnumerable<object[]>
    {
        protected Assembly? Assembly;

        public IEnumerator<object[]> GetEnumerator()
        {
            Assembly?.LoadXmlDocumentation();
            // Grab types from assembly
            var types = Assembly?
                .GetExportedTypes();

            foreach (var type in types!)
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