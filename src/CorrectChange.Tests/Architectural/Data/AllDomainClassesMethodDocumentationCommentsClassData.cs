using CorrectChange.Domain.Support;
using CorrectChange.Tests.Architectural.Data.Abstract;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Uses reflection to return classes, properties and their XML documentation
    /// </summary>
    public class AllDomainClassesMethodDocumentationCommentsClassData :
        AbstractAllClassesMethodDocumentationCommentsClassData
    {
        public AllDomainClassesMethodDocumentationCommentsClassData()
        {
            Assembly = DomainAssemblyReference.Assembly;
        }
    }
}