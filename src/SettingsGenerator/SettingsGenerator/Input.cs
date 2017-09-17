namespace SettingsGenerator
{
    public class Input
    {
        public readonly string Path;
        public readonly string GoCommandName;
        public readonly string OriginalCommandName;
        public readonly string AdditionalOptionsUrl;
        public readonly string AdditionalOptionsTypeName;

        public Input(string path, string goCommandName = null, string additionalOptionsUrl = null, string additionalOptionsTypeName = null)
        {
            string[] parts = path.Split(new[] { System.IO.Path.DirectorySeparatorChar });
            Path = path;
            OriginalCommandName = parts[parts.Length - 1];
            GoCommandName = goCommandName != null ? goCommandName : OriginalCommandName;
            AdditionalOptionsUrl = additionalOptionsUrl;
            AdditionalOptionsTypeName = additionalOptionsTypeName;
        }
    }
}
