using CorrectChange.Support;
using CorrectChange.Tests.Architectural.Data.Abstract;

namespace CorrectChange.Tests.Architectural.Data
{
    /// <summary>
    ///     Uses reflection to return classes, properties and their XML documentation
    /// </summary>
    public class AllCliClassesMethodDocumentationCommentsClassData :
        AbstractAllClassesMethodDocumentationCommentsClassData
    {
        public AllCliClassesMethodDocumentationCommentsClassData()
        {
            Assembly = CliAssemblyReference.Assembly;
        }
    }
}