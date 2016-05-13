namespace Cake.Docker
{
    /// <summary>
    /// Container status
    /// </summary>
    public enum ContainerStatus
    {
        /// <summary>
        /// Created
        /// </summary>
        Created,
        /// <summary>
        /// Running
        /// </summary>
        Running,
        /// <summary>
        /// Restarting
        /// </summary>
        Restarting,
        /// <summary>
        /// Paused
        /// </summary>
        Paused,
        /// <summary>
        /// Exited
        /// </summary>
        Exited
    }
}
