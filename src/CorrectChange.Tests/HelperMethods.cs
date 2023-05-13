using System.Reflection;
using Towel;

namespace CorrectChange.Tests
{
    public static class HelperMethods
    {
        /// <summary>
        ///     Uses the Towel library to read XML Documentation Comments. Production of XML Documentation needs to be enabled for
        ///     each assembly where tests using this methodology are applied
        /// </summary>
        /// <param name="assembly"></param>
        public static void LoadXmlDocumentation(this Assembly assembly)
        {
            var directoryPath = assembly.GetDirectoryPath();

            if (directoryPath == null) return;

            var xmlFilePath = Path.Combine(directoryPath, assembly.GetName().Name + ".xml");

            if (!File.Exists(xmlFilePath)) return;

            Meta.LoadXmlDocumentation(File.ReadAllText(xmlFilePath));
        }
    }
}