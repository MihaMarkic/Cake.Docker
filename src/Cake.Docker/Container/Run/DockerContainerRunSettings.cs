using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker run [OPTIONS] IMAGE [COMMAND] [ARG...].
	/// Run a command in a new container
	/// </summary>
	public sealed class DockerContainerRunSettings : AutoToolSettings
	{
		/// <summary>
		/// --add-host
		/// Add a custom host-to-IP mapping (host:ip)
		/// </summary>
		public string[] AddHost { get; set; }
		/// <summary>
		/// --attach, -a
		/// Attach to STDIN, STDOUT or STDERR
		/// </summary>
		public string[] Attach { get; set; }
		/// <summary>
		/// --blkio-weight-device
		/// Block IO weight (relative device weight)
		/// </summary>
		public UInt64? BlkioWeightDevice { get; set; }
		/// <summary>
		/// --cap-add
		/// Add Linux capabilities
		/// </summary>
		public string[] CapAdd { get; set; }
		/// <summary>
		/// --cap-drop
		/// Drop Linux capabilities
		/// </summary>
		public string[] CapDrop { get; set; }
		/// <summary>
		/// --cgroup-parent
		/// Optional parent cgroup for the container
		/// </summary>
		public string CgroupParent { get; set; }
		/// <summary>
		/// --cidfile
		/// Write the container ID to the file
		/// </summary>
		public string Cidfile { get; set; }
		/// <summary>
		/// --cpu-count
		/// default: 0
		/// CPU count (Windows only)
		/// </summary>
		public Int64? CpuCount { get; set; }
		/// <summary>
		/// --cpu-percent
		/// default: 0
		/// CPU percent (Windows only)
		/// </summary>
		public Int64? CpuPercent { get; set; }
		/// <summary>
		/// --cpu-period
		/// default: 0
		/// Limit CPU CFS (Completely Fair Scheduler) period
		/// </summary>
		public Int64? CpuPeriod { get; set; }
		/// <summary>
		/// --cpu-quota
		/// default: 0
		/// Limit CPU CFS (Completely Fair Scheduler) quota
		/// </summary>
		public Int64? CpuQuota { get; set; }
		/// <summary>
		/// --cpu-rt-period
		/// default: 0
		/// Limit CPU real-time period in microseconds
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public Int64? CpuRtPeriod { get; set; }
		/// <summary>
		/// --cpu-rt-runtime
		/// default: 0
		/// Limit CPU real-time runtime in microseconds
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public Int64? CpuRtRuntime { get; set; }
		/// <summary>
		/// --cpus
		/// Number of CPUs
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public UInt64? Cpus { get; set; }
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
		/// --detach, -d
		/// default: false
		/// Run container in background and print container ID
		/// </summary>
		public bool? Detach { get; set; }
		/// <summary>
		/// --detach-keys
		/// Override the key sequence for detaching a container
		/// </summary>
		public string DetachKeys { get; set; }
		/// <summary>
		/// --device
		/// Add a host device to the container
		/// </summary>
		public string[] Device { get; set; }
		/// <summary>
		/// --device-cgroup-rule
		/// Add a rule to the cgroup allowed devices list
		/// </summary>
		public string[] DeviceCgroupRule { get; set; }
		/// <summary>
		/// --device-read-bps
		/// Limit read rate (bytes per second) from a device
		/// </summary>
		public UInt64? DeviceReadBps { get; set; }
		/// <summary>
		/// --device-read-iops
		/// Limit read rate (IO per second) from a device
		/// </summary>
		public UInt64? DeviceReadIops { get; set; }
		/// <summary>
		/// --device-write-bps
		/// Limit write rate (bytes per second) to a device
		/// </summary>
		public UInt64? DeviceWriteBps { get; set; }
		/// <summary>
		/// --device-write-iops
		/// Limit write rate (IO per second) to a device
		/// </summary>
		public UInt64? DeviceWriteIops { get; set; }
		/// <summary>
		/// --disable-content-trust
		/// default: true
		/// Skip image verification
		/// </summary>
		public bool? DisableContentTrust { get; set; }
		/// <summary>
		/// --dns
		/// Set custom DNS servers
		/// </summary>
		public string[] Dns { get; set; }
		/// <summary>
		/// --dns-option
		/// Set DNS options
		/// </summary>
		public string[] DnsOption { get; set; }
		/// <summary>
		/// --dns-search
		/// Set custom DNS search domains
		/// </summary>
		public string[] DnsSearch { get; set; }
		/// <summary>
		/// --entrypoint
		/// Overwrite the default ENTRYPOINT of the image
		/// </summary>
		public string Entrypoint { get; set; }
		/// <summary>
		/// --env, -e
		/// Set environment variables
		/// </summary>
		public string[] Env { get; set; }
		/// <summary>
		/// --env-file
		/// Read in a file of environment variables
		/// </summary>
		public string[] EnvFile { get; set; }
		/// <summary>
		/// --expose
		/// Expose a port or a range of ports
		/// </summary>
		public string[] Expose { get; set; }
		/// <summary>
		/// --group-add
		/// Add additional groups to join
		/// </summary>
		public string[] GroupAdd { get; set; }
		/// <summary>
		/// --health-cmd
		/// Command to run to check health
		/// </summary>
		public string HealthCmd { get; set; }
		/// <summary>
		/// --health-interval
		/// default: 0
		/// Time between running the check (ms|s|m|h) (default 0s)
		/// </summary>
		public string HealthInterval { get; set; }
		/// <summary>
		/// --health-retries
		/// default: 0
		/// Consecutive failures needed to report unhealthy
		/// </summary>
		public int? HealthRetries { get; set; }
		/// <summary>
		/// --health-start-period
		/// default: 0
		/// Start period for the container to initialize before starting health-retries countdown (ms|s|m|h) (default 0s)
		/// </summary>
		/// <remarks>
		/// Version: 1.29
		/// </remarks>
		public string HealthStartPeriod { get; set; }
		/// <summary>
		/// --health-timeout
		/// default: 0
		/// Maximum time to allow one check to run (ms|s|m|h) (default 0s)
		/// </summary>
		public string HealthTimeout { get; set; }
		/// <summary>
		/// --hostname, -h
		/// Container host name
		/// </summary>
		public string Hostname { get; set; }
		/// <summary>
		/// --init
		/// default: false
		/// Run an init inside the container that forwards signals and reaps processes
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public bool? Init { get; set; }
		/// <summary>
		/// --interactive, -i
		/// default: false
		/// Keep STDIN open even if not attached
		/// </summary>
		public bool? Interactive { get; set; }
		/// <summary>
		/// --io-maxbandwidth
		/// Maximum IO bandwidth limit for the system drive (Windows only)
		/// </summary>
		public UInt64? IoMaxbandwidth { get; set; }
		/// <summary>
		/// --io-maxiops
		/// </summary>
		public UInt64? IoMaxiops { get; set; }
		/// <summary>
		/// --ip
		/// IPv4 address (e.g., 172.30.100.104)
		/// </summary>
		public string Ip { get; set; }
		/// <summary>
		/// --ip6
		/// IPv6 address (e.g., 2001:db8::33)
		/// </summary>
		public string Ip6 { get; set; }
		/// <summary>
		/// --ipc
		/// IPC mode to use
		/// </summary>
		public string Ipc { get; set; }
		/// <summary>
		/// --isolation
		/// Container isolation technology
		/// </summary>
		public string Isolation { get; set; }
		/// <summary>
		/// --kernel-memory
		/// Kernel memory limit
		/// </summary>
		public UInt64? KernelMemory { get; set; }
		/// <summary>
		/// --label, -l
		/// Set meta data on a container
		/// </summary>
		public string[] Label { get; set; }
		/// <summary>
		/// --label-file
		/// Read in a line delimited file of labels
		/// </summary>
		public string[] LabelFile { get; set; }
		/// <summary>
		/// --link
		/// Add link to another container
		/// </summary>
		public string[] Link { get; set; }
		/// <summary>
		/// --link-local-ip
		/// Container IPv4/IPv6 link-local addresses
		/// </summary>
		public string[] LinkLocalIp { get; set; }
		/// <summary>
		/// --log-driver
		/// Logging driver for the container
		/// </summary>
		public string LogDriver { get; set; }
		/// <summary>
		/// --log-opt
		/// Log driver options
		/// </summary>
		public string[] LogOpt { get; set; }
		/// <summary>
		/// --mac-address
		/// Container MAC address (e.g., 92:d0:c6:0a:29:33)
		/// </summary>
		public string MacAddress { get; set; }
		/// <summary>
		/// --memory, -m
		/// Memory limit
		/// </summary>
		public UInt64? Memory { get; set; }
		/// <summary>
		/// --memory-reservation
		/// Memory soft limit
		/// </summary>
		public UInt64? MemoryReservation { get; set; }
		/// <summary>
		/// --memory-swap
		/// Swap limit equal to memory plus swap: &#39;-1&#39; to enable unlimited swap
		/// </summary>
		public UInt64? MemorySwap { get; set; }
		/// <summary>
		/// --memory-swappiness
		/// default: -1
		/// Tune container memory swappiness (0 to 100)
		/// </summary>
		public Int64? MemorySwappiness { get; set; }
		/// <summary>
		/// --mount
		/// Attach a filesystem mount to the container
		/// </summary>
		public string[] Mount { get; set; }
		/// <summary>
		/// --name
		/// Assign a name to the container
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// --network
		/// default: default
		/// Connect a container to a network
		/// </summary>
		public string Network { get; set; }
		/// <summary>
		/// --network-alias
		/// Add network-scoped alias for the container
		/// </summary>
		public string[] NetworkAlias { get; set; }
		/// <summary>
		/// --no-healthcheck
		/// default: false
		/// Disable any container-specified HEALTHCHECK
		/// </summary>
		public bool? NoHealthcheck { get; set; }
		/// <summary>
		/// --oom-kill-disable
		/// default: false
		/// Disable OOM Killer
		/// </summary>
		public bool? OomKillDisable { get; set; }
		/// <summary>
		/// --oom-score-adj
		/// default: 0
		/// Tune host&#39;s OOM preferences (-1000 to 1000)
		/// </summary>
		public int? OomScoreAdj { get; set; }
		/// <summary>
		/// --pid
		/// PID namespace to use
		/// </summary>
		public string Pid { get; set; }
		/// <summary>
		/// --pids-limit
		/// default: 0
		/// Tune container pids limit (set -1 for unlimited)
		/// </summary>
		public Int64? PidsLimit { get; set; }
	    /// <summary>
	    /// --platform
	    /// default: 
	    /// Set platform if server is multi-platform capable
	    /// </summary>
	    public string Platform { get; set; }
		/// <summary>
		/// --privileged
		/// default: false
		/// Give extended privileges to this container
		/// </summary>
		public bool? Privileged { get; set; }
		/// <summary>
		/// --publish, -p
		/// Publish a container&#39;s port(s) to the host
		/// </summary>
		public string[] Publish { get; set; }
		/// <summary>
		/// --publish-all, -P
		/// default: false
		/// Publish all exposed ports to random ports
		/// </summary>
		public bool? PublishAll { get; set; }
		/// <summary>
		/// --read-only
		/// default: false
		/// Mount the container&#39;s root filesystem as read only
		/// </summary>
		public bool? ReadOnly { get; set; }
		/// <summary>
		/// --restart
		/// default: no
		/// Restart policy to apply when a container exits
		/// </summary>
		public string Restart { get; set; }
		/// <summary>
		/// --rm
		/// default: false
		/// Automatically remove the container when it exits
		/// </summary>
		public bool? Rm { get; set; }
		/// <summary>
		/// --runtime
		/// Runtime to use for this container
		/// </summary>
		public string Runtime { get; set; }
		/// <summary>
		/// --security-opt
		/// Security Options
		/// </summary>
		public string[] SecurityOpt { get; set; }
		/// <summary>
		/// --shm-size
		/// Size of /dev/shm
		/// </summary>
		public UInt64? ShmSize { get; set; }
		/// <summary>
		/// --sig-proxy
		/// default: true
		/// Proxy received signals to the process
		/// </summary>
		public bool? SigProxy { get; set; }
		/// <summary>
		/// --stop-signal
		/// default: signal.DefaultStopSignal
		/// Signal to stop a container
		/// </summary>
		public string StopSignal { get; set; }
		/// <summary>
		/// --stop-timeout
		/// default: 0
		/// Timeout (in seconds) to stop a container
		/// </summary>
		/// <remarks>
		/// Version: 1.25
		/// </remarks>
		public int? StopTimeout { get; set; }
		/// <summary>
		/// --storage-opt
		/// Storage driver options for the container
		/// </summary>
		public string[] StorageOpt { get; set; }
		/// <summary>
		/// --sysctl
		/// Sysctl options
		/// </summary>
		public string[] Sysctl { get; set; }
		/// <summary>
		/// --tmpfs
		/// Mount a tmpfs directory
		/// </summary>
		public string[] Tmpfs { get; set; }
		/// <summary>
		/// --tty, -t
		/// default: false
		/// Allocate a pseudo-TTY
		/// </summary>
		public bool? Tty { get; set; }
		/// <summary>
		/// --ulimit
		/// Ulimit options
		/// </summary>
		public string[] Ulimit { get; set; }
		/// <summary>
		/// --user, -u
		/// Username or UID (format: &lt;name|uid&gt;[:&lt;group|gid&gt;])
		/// </summary>
		public string User { get; set; }
		/// <summary>
		/// --userns
		/// User namespace to use
		/// </summary>
		public string Userns { get; set; }
		/// <summary>
		/// --uts
		/// UTS namespace to use
		/// </summary>
		public string Uts { get; set; }
		/// <summary>
		/// --volume, -v
		/// Bind mount a volume
		/// </summary>
		public string[] Volume { get; set; }
		/// <summary>
		/// --volume-driver
		/// Optional volume driver for the container
		/// </summary>
		public string VolumeDriver { get; set; }
		/// <summary>
		/// --volumes-from
		/// Mount volumes from the specified container(s)
		/// </summary>
		public string[] VolumesFrom { get; set; }
		/// <summary>
		/// --workdir, -w
		/// Working directory inside the container
		/// </summary>
		public string Workdir { get; set; }
	}
}