namespace CorrectChange.Domain.Common
{
    public static class LogFmt
    {
        private const string MessageTag = "Message";

        public static string Message(string message)
        {
            return $"{MessageTag}={message}";
        }
    }
}