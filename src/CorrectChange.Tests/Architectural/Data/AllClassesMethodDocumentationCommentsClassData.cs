using System.Collections;
using System.Reflection;
using CorrectChange.Domain.Support;
using Towel;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Uses reflection to return classes, properties and their XML documentation
    /// </summary>
    public class AllClassesMethodDocumentationCommentsClassData : IEnumerable<object[]>
    {
        private readonly Assembly _assembly;

        public AllClassesMethodDocumentationCommentsClassData()
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

            var syntacticalSugarredRecordMethods = new HashSet<string>()
            {
                "GetHashCode", "Equals", "PrintMembers", "ToString", "<Clone>$"
            };

            // Limit to classes that are not exceptions (many internal public properties beyond our control)
            foreach (var type in types.Where(t =>
                         !t.IsAssignableFrom(typeof(Exception)) && !t.Name.EndsWith("Exception")))
            {
                var methods = type.GetMethods(
                            BindingFlags.Public |
                            BindingFlags.NonPublic |
                            BindingFlags.Instance |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly
                        )
                        // .Where(method => !method.IsVirtual)
                        .Where(method => !method.IsSpecialName)
                        .Where(method => method.MethodImplementationFlags != MethodImplAttributes.InternalCall)
                        .Where(method => !syntacticalSugarredRecordMethods.Contains(method.Name))
                    ;

                // Typename, method and any documentation comment Towel finds 
                foreach (var methodInfo in methods)
                    yield return new object[]
                    {
                        type.Name,
                        methodInfo.Name,
                        type.Namespace ?? string.Empty,
                        methodInfo.GetDocumentation()?.Trim()!
                    };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}