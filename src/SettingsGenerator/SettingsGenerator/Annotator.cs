namespace SettingsGenerator
{
    public static class Annotator
    {
        public static void AnnotateArgument(Argument arg, string content)
        {
            string[] parts = Parser.PartsWithStrings(content);
            string type = parts[0];
            switch (type)
            {
                case "experimental":
                    arg.IsExperimental = true;
                    break;
                case "version":
                    string value = parts[1];
                    int openQuotationsIndex = value.IndexOf('{');
                    int closeQuotationsIndex = value.IndexOf('}', openQuotationsIndex + 1);
                    arg.Version = value.Substring(openQuotationsIndex + 1, closeQuotationsIndex - openQuotationsIndex - 1);
                    break;
            }
        }
    }
}
