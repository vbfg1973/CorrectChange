using System.Reflection;

namespace CorrectChange.Support
{
    /// <summary>
    ///     A reference to the CLI assembly
    /// </summary>
    public sealed class CliAssemblyReference
    {
        /// <summary>
        ///     The assembly reference
        /// </summary>
        public static readonly Assembly Assembly = typeof(CliAssemblyReference).Assembly;
    }
}