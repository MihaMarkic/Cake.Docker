namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerBuildSettings: AutoToolSettings
    {
        /// <summary>
        /// Set build-time variables
        /// </summary>
        public string[] BuildArg { get; set; }
        /// <summary>
        /// CPU Shares (relative weight)
        /// </summary>
        public bool? CpuShares { get; set; }
        /// <summary>
        /// =""              Optional parent cgroup for the container
        /// </summary>
        public bool? CgroupParen { get; set; }
        /// <summary>
        /// Limit the CPU CFS (Completely Fair Scheduler) period
        /// </summary>
        public int? CpuPeriod { get; set; }
        /// <summary>
        /// Limit the CPU CFS (Completely Fair Scheduler) quota
        /// </summary>
        public int? CpuQuota { get; set; }
        /// <summary>
        /// "                CPUs in which to allow execution, e.g. `0-3`, `0,1`
        /// </summary>
        public string CpusetCpus { get; set; }
        /// <summary>
        /// "                MEMs in which to allow execution, e.g. `0-3`, `0,1`
        /// </summary>
        public string CpusetMems { get; set; }
        /// <summary>
        /// nt-trust=true    Skip image verification
        /// </summary>
        public bool? DisableCont { get; set; }
        /// <summary>
        /// Name of the Dockerfile (Default is 'PATH/Dockerfile')
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// Always remove intermediate containers
        /// </summary>
        public bool? ForceRm { get; set; }
        /// <summary>
        /// Print usage
        /// </summary>
        public bool? Help { get; set; }
        /// <summary>
        /// Container isolation technology
        /// </summary>
        public string Isolation { get; set; }
        /// <summary>
        /// Set metadata for an image
        /// </summary>
        public string[] Label { get; set; }
        /// <summary>
        /// Memory limit for all build containers
        /// </summary>
        public string Memory { get; set; }
        /// <summary>
        /// "                A positive integer equal to memory plus swap. Specify -1 to enable unlimited swap.
        /// </summary>
        public string MemorySwap { get; set; }
        /// <summary>
        /// Do not use cache when building the image
        /// </summary>
        public bool? NoCache { get; set; }
        /// <summary>
        /// Always attempt to pull a newer version of the image
        /// </summary>
        public bool? Pull { get; set; }
        /// <summary>
        /// Suppress the build output and print image ID on success
        /// </summary>
        public bool? Quiet { get; set; }
        /// <summary>
        /// Remove intermediate containers after a successful build
        /// </summary>
        public string Rm { get; set; }
        /// <summary>
        /// Size of `/dev/shm`. The format is `<number><unit>`. `number` must be greater than `0`.  Unit is optional and can be `b` (bytes), `k` (kilobytes), `m` (megabytes), or `g` (gigabytes). If you omit the unit, the system uses bytes. If you omit the size entirely, the system uses `64m`.
        /// </summary>
        public string[] ShmSize { get; set; }
        /// <summary>
        /// Name and optionally a tag in the 'name:tag' format
        /// </summary>
        public string[] Tag { get; set; }
        /// <summary>
        /// Ulimit options
        /// </summary>
        public string[] Ulimit { get; set; }


    }
}
