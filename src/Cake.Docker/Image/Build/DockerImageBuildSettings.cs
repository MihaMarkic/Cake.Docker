using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker build [OPTIONS] PATH | URL | -.
	/// Build an image from a Dockerfile
	/// </summary>
	public sealed partial class DockerImageBuildSettings : AutoToolSettings
	{
		/// <summary>
		/// --add-host
		/// Add a custom host-to-IP mapping (host:ip)
		/// </summary>
		public string[] AddHost { get; set; }
		/// <summary>
		/// --build-arg
		/// Set build-time variables
		/// </summary>
		public string[] BuildArg { get; set; }
		/// <summary>
		/// --cache-from
		/// default: 
		/// Images to consider as cache sources
		/// </summary>
		public string[] CacheFrom { get; set; }
		/// <summary>
		/// --cgroup-parent
		/// Optional parent cgroup for the container
		/// </summary>
		public string CgroupParent { get; set; }
		/// <summary>
		/// --compress
		/// default: false
		/// Compress the build context using gzip
		/// </summary>
		public bool? Compress { get; set; }
		/// <summary>
		/// --cpu-period
		/// default: 0
		/// Limit the CPU CFS (Completely Fair Scheduler) period
		/// </summary>
		public Int64? CpuPeriod { get; set; }
		/// <summary>
		/// --cpu-quota
		/// default: 0
		/// Limit the CPU CFS (Completely Fair Scheduler) quota
		/// </summary>
		public Int64? CpuQuota { get; set; }
		/// <summary>
		/// --cpuset-cpus
		/// CPUs in which to allow execution (0-3, 0,1)
		/// </summary>
		public string CpusetCpus { get; set; }
		/// <summary>
		/// --cpuset-mems
		/// MEMs in which to allow execution (0-3, 0,1)
		/// </summary>
		public string CpusetMems { get; set; }
		/// <summary>
		/// --cpu-shares, -c
		/// default: 0
		/// CPU shares (relative weight)
		/// </summary>
		public Int64? CpuShares { get; set; }
        /// <summary>
        /// --disable-content-trust
        /// default: true
        /// Skip image verification
        /// </summary>
        [AutoProperty(Format = Constants.BoolWithTrueDefaultFormat)]
        public bool? DisableContentTrust { get; set; }
		/// <summary>
		/// --file, -f
		/// Name of the Dockerfile (Default is &#39;PATH/Dockerfile&#39;)
		/// </summary>
		public string File { get; set; }
		/// <summary>
		/// --force-rm
		/// default: false
		/// Always remove intermediate containers
		/// </summary>
		public bool? ForceRm { get; set; }
		/// <summary>
		/// --iidfile
		/// Write the image ID to the file
		/// </summary>
		public string Iidfile { get; set; }
		/// <summary>
		/// --isolation
		/// Container isolation technology
		/// </summary>
		public string Isolation { get; set; }
		/// <summary>
		/// --label
		/// Set metadata for an image
		/// </summary>
		public string[] Label { get; set; }
		/// <summary>
		/// --memory, -m
		/// Memory limit
		/// </summary>
		public string Memory { get; set; }
		/// <summary>
		/// --memory-swap
		/// Swap limit equal to memory plus swap: &#39;-1&#39; to enable unlimited swap
		/// </summary>
		public string MemorySwap { get; set; }
		/// <summary>
		/// --network
		/// default: default
		/// Set the networking mode for the RUN instructions during build
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public string Network { get; set; }
		/// <summary>
		/// --no-cache
		/// default: false
		/// Do not use cache when building the image
		/// </summary>
		public bool? NoCache { get; set; }
		/// <summary>
		/// --platform
		/// Set platform if server is multi-platform capable
		/// </summary>
		public string Platform { get; set; }
		/// <summary>
		/// Set type of progress output ("auto", "plain", "tty"). Use plain to show container output (default "auto")
		/// </summary>
		public string Progress { get; set; }
		/// <summary>
		/// --pull
		/// default: false
		/// Always attempt to pull a newer version of the image
		/// </summary>
		public bool? Pull { get; set; }
		/// <summary>
		/// --quiet, -q
		/// default: false
		/// Suppress the build output and print image ID on success
		/// </summary>
		public bool? Quiet { get; set; }
		/// <summary>
		/// --rm
		/// default: true
		/// Remove intermediate containers after a successful build
		/// </summary>
        [AutoProperty(Format = Constants.BoolWithTrueDefaultFormat)]
		public bool? Rm { get; set; }
		/// <summary>
		/// --security-opt
		/// default: 
		/// Security options
		/// </summary>
		public string[] SecurityOpt { get; set; }
		/// <summary>
		/// --shm-size
		/// Size of /dev/shm
		/// </summary>
		public string ShmSize { get; set; }
		/// <summary>
		/// --squash
		/// default: false
		/// Squash newly built layers into a single new layer
		/// </summary>
		/// <remarks>
		/// Experimental
		/// Version: 1.25
		/// </remarks>
		public bool? Squash { get; set; }
		/// <summary>
		/// --stream
		/// default: false
		/// Stream attaches to server to negotiate build context
		/// </summary>
		/// <remarks>
		/// Experimental
		/// Version: 1.31
		/// </remarks>
		public bool? Stream { get; set; }
		/// <summary>
		/// --tag, -t
		/// Name and optionally a tag in the &#39;name:tag&#39; format
		/// </summary>
		public string[] Tag { get; set; }
		/// <summary>
		/// --target
		/// Set the target build stage to build.
		/// </summary>
		public string Target { get; set; }
		/// <summary>
		/// --ulimit
		/// Ulimit options
		/// </summary>
		public string[] Ulimit { get; set; }
	}
}
