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
        [ClassData(typeof(AllDomainClassesHaveDocumentationCommentsClassData))]
        [ClassData(typeof(AllCliClassesHaveDocumentationCommentsClassData))]
        public void All_Classes_Have_Documentation_Comments(string typeName, string ns, string xmlDocumentation)
        {
            #region WarningSuppression

            // suppress unused warning from xunit and resulting self assignment warning.
            // Normally dangerous and to be heeded, but in this case only present for context in the test runner.
#pragma warning disable CS1717
            typeName = typeName;
            ns = ns;
#pragma warning restore CS1717

            #endregion

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
        [ClassData(typeof(AllCliClassesPropertyDocumentationCommentsClassData))]
        [ClassData(typeof(AllDomainClassesPropertyDocumentationCommentsClassData))]
        public void All_Class_Properties_Have_Documentation_Comments(string typeName, string propertyName, string ns,
            string xmlDocumentation)
        {
            #region WarningSuppression

            // suppress unused warning from xunit and resulting self assignment warning.
            // Normally dangerous and to be heeded, but in this case only present for context in the test runner.
#pragma warning disable CS1717
            typeName = typeName;
            propertyName = propertyName;
            ns = ns;
#pragma warning restore CS1717

            #endregion

            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }

        /// <summary>
        ///     Tests class methods for XML Documentation Comments
        /// </summary>
        /// <remarks>
        ///     typename, ns (namespace) and methodName are not used in the test directly but are provided for context when
        ///     reading test runner output.
        /// </remarks>
        /// <param name="typeName"></param>
        /// <param name="ns"></param>
        /// <param name="methodName"></param>
        /// <param name="xmlDocumentation"></param>
        [Theory]
        [ClassData(typeof(AllCliClassesMethodDocumentationCommentsClassData))]
        [ClassData(typeof(AllDomainClassesMethodDocumentationCommentsClassData))]
        public void All_Class_Methods_Have_Documentation_Comments(string typeName, string methodName, string ns,
            string xmlDocumentation)
        {
            #region WarningSuppression

            // suppress unused warning from xunit and resulting self assignment warning.
            // Normally dangerous and to be heeded, but in this case only present for context in the test runner.
#pragma warning disable CS1717
            typeName = typeName;
            methodName = methodName;
            ns = ns;
#pragma warning restore CS1717

            #endregion

            xmlDocumentation
                .Should()
                .NotBeNullOrEmpty();
        }
    }
}