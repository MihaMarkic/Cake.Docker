namespace Cake.Docker
{
    /// <summary>
    /// Represents an agnostic argument.
    /// </summary>
    public struct DockerArgument
    {
        /// <summary>
        /// Key part of the argument
        /// </summary>
        public string? Key { get; }
        /// <summary>
        /// Value part of the argument.
        /// </summary>
        public string? Value { get; }
        /// <summary>
        /// The required quoting mode.
        /// </summary>
        public DockerArgumentQuoting Quoting { get; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="quoting"></param>
        public DockerArgument(string? key, string? value, DockerArgumentQuoting quoting)
        {
            Key = key;
            Value = value;
            Quoting = quoting;
        }
    }
    /// <summary>
    /// Quoting mode
    /// </summary>
    public enum DockerArgumentQuoting
    {
        /// <summary>
        /// No quoting
        /// </summary>
        Unquoted,
        /// <summary>
        /// Quotes.
        /// </summary>
        Quoted,
        /// <summary>
        /// A quoted secret 
        /// </summary>
        QuotedSecret
    }
}
