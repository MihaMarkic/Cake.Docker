using System;

namespace SettingsGenerator
{
    public class Input
    {
        public readonly string Path;
        public readonly string GoCommandName;
        public readonly string OriginalCommandName;
        public readonly InputTypeOptions? InputTypeOptions;
        public readonly Option Options;

        public Input(string path, string goCommandName = null, InputTypeOptions? inputTypeOptions = null, Option options = Option.None)
        {
            string[] parts = path.Split(new[] { System.IO.Path.DirectorySeparatorChar });
            Path = path;
            OriginalCommandName = parts[parts.Length - 1];
            GoCommandName = goCommandName != null ? goCommandName : OriginalCommandName;
            InputTypeOptions = inputTypeOptions;
            Options = options;
        }
    }

    public enum InputTypeOptions
    {
        Container,
        Swarm,
        SwarmConsts,
    }

    [Flags]
    public enum Option
    {
        None = 0,
        TypeContainsBlankLines = 1
    }
}
