using CorrectChange.Domain.Support;
using CorrectChange.Tests.Architectural.Data.Abstract;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Uses reflection to return classes, properties and their XML documentation
    /// </summary>
    public class
        AllDomainClassesPropertyDocumentationCommentsClassData :
            AbstractAllClassesPropertyDocumentationCommentsClassData
    {
        public AllDomainClassesPropertyDocumentationCommentsClassData()
        {
            // Get the appropriate assembly and XML documentation
            Assembly = DomainAssemblyReference.Assembly;
        }
    }
}