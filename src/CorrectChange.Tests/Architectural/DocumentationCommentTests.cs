using CorrectChange.Tests.Architectural.Data;
using FluentAssertions;

namespace CorrectChange.Tests.Architectural
{
    public class DocumentationCommentTests
    {
        /// <summary>
        ///     Tests classes for XML Documentation Comments
        /// </summary>
        /// <remarks>
        ///     typename and ns (namespace) are not used in the test directly but are provided for context when reading test runner
        ///     output.
        /// </remarks>
        /// <param name="typeName"></param>
        /// <param name="ns"></param>
        /// <param name="xmlDocumentation"></param>
        [Theory]
        [ClassData(typeof(AllClassesHaveDocumentationCommentsClassData))]
        public void All_Classes_Have_Documentation_Comments(string typeName, string ns, string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }

        /// <summary>
        ///     Tests class properties for XML Documentation Comments
        /// </summary>
        /// <remarks>
        ///     typename, ns (namespace) and propertyName are not used in the test directly but are provided for context when
        ///     reading test runner output.
        /// </remarks>
        /// <param name="typeName"></param>
        /// <param name="ns"></param>
        /// <param name="propertyName"></param>
        /// <param name="xmlDocumentation"></param>
        [Theory]
        [ClassData(typeof(AllClassesPropertyDocumentationCommentsClassData))]
        public void All_Class_Properties_Have_Documentation_Comments(string typeName, string ns, string propertyName,
            string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }
        
        /// <summary>
        ///     Tests class methods for XML Documentation Comments
        /// </summary>
        /// <remarks>
        ///     typename, ns (namespace) and propertyName are not used in the test directly but are provided for context when
        ///     reading test runner output.
        /// </remarks>
        /// <param name="typeName"></param>
        /// <param name="ns"></param>
        /// <param name="methodName"></param>
        /// <param name="xmlDocumentation"></param>
        [Theory]
        [ClassData(typeof(AllClassesMethodDocumentationCommentsClassData))]
        public void All_Class_Methods_Have_Documentation_Comments(string typeName, string ns, string methodName,
            string xmlDocumentation)
        {
            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }
    }
}