﻿namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker compose stop.
    /// </summary>
    public sealed class DockerComposeStopSettings : DockerComposeSettings
    {
        /// <summary>
        /// Specify a shutdown timeout in seconds
        /// </summary>
        public int? Timeout { get; set; }
    }
}