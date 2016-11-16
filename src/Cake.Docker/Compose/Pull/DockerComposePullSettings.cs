namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerComposePullSettings: AutoToolSettings
    {
        /// <summary>
        /// Pull what it can and ignores images with pull failures.
        /// </summary>
        public bool IgnorePullFailures { get; set; }


    }
}
