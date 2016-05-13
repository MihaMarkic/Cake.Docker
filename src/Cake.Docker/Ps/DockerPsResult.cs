namespace Cake.Docker
{
    /// <summary>
    /// Result of docker ps command.
    /// </summary>
    public class DockerPsResult
    {
        /// <summary>
        /// Container Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Container image
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Command
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// Created
        /// </summary>
        public string Created { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public ContainerStatus Status { get; set; }
        /// <summary>
        /// ExitCode
        /// </summary>
        public int? ExitCode { get; set; }

        //public string Ports { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Size
        /// </summary>
        public long? Size { get; set; }
        /// <summary>
        /// VirtualSize
        /// </summary>
        public long? VirtualSize { get; set; }
    }
}
