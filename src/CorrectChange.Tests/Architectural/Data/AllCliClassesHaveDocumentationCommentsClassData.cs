using CorrectChange.Domain.Support;
using CorrectChange.Tests.Architectural.Data.Abstract;

namespace CorrectChange.Tests.Architectural.Data
{
    public class AllCliClassesHaveDocumentationCommentsClassData : AbstractAllClassesHaveDocumentationCommentsClassData
    {
        public AllCliClassesHaveDocumentationCommentsClassData()
        {
            Assembly = DomainAssemblyReference.Assembly;
        }
    }
}