using CorrectChange.Verbs.Abstract;

namespace CorrectChange.Verbs.Change
{
    /// <summary>
    ///     Interface for the "Change" functionality verb
    /// </summary>
    public interface IChangeVerb : IVerb
    {
        /// <summary>
        ///     Calculate the change
        /// </summary>
        /// <param name="verbOptions"></param>
        void Run(IChangeVerbOptions verbOptions);
    }
}