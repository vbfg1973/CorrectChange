using CorrectChange.Support;
using CorrectChange.Tests.Architectural.Data.Abstract;

namespace CorrectChange.Tests.Architectural.Data
{
    public class AllDomainClassesHaveDocumentationCommentsClassData : AbstractAllClassesHaveDocumentationCommentsClassData
    {
        public AllDomainClassesHaveDocumentationCommentsClassData()
        {
            Assembly = CliAssemblyReference.Assembly;
        }
    }
}