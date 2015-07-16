using System.Collections.Specialized;

namespace GPStudio.Tools.ReaderMe.module.error
{
    public static class ExceptionMessageManager
    {
        private static StringDictionary messageDict = new StringDictionary();

        static ExceptionMessageManager()
        {
            messageDict.Add("", "");
        }

        public static string GetMessage(string errorCode)
        {
            string message = string.Empty;
            if (!string.IsNullOrEmpty(errorCode) &&
                messageDict.ContainsKey(errorCode))
            {
                message = messageDict[errorCode];
            }
            return message;
        }
    }
}
