using System;

namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker push.
    /// </summary>
    public sealed class DockerRunSettings : AutoToolSettings
    {
        /// <summary>
        /// Add a custom host-to-IP mapping (host:ip) (default [])
        /// </summary>
        public string[] AddHost { get; set; }
        /// <summary>
        /// Attach to STDIN, STDOUT or STDERR (default [])
        /// </summary>
        public string[] Attach { get; set; }
        /// <summary>
        /// Block IO (relative weight), between 10 and 1000
        /// </summary>
        public int BlkioWeight { get; set; }
        /// <summary>
        /// Block IO weight (relative device weight) (default [])
        /// </summary>
        public int[] BlkioWeightDevice { get; set; }
        /// <summary>
        /// Add Linux capabilities (default [])
        /// </summary>
        public string[] CapAdd { get; set; }
        /// <summary>
        /// Drop Linux capabilities (default [])
        /// </summary>
        public string[] CapDrop { get; set; }
        /// <summary>
        /// Optional parent cgroup for the container
        /// </summary>
        public string CgroupParent { get; set; }
        /// <summary>
        /// Write the container ID to the file
        /// </summary>
        public string Cidfile { get; set; }
        /// <summary>
        /// CPU percent (Windows only)
        /// </summary>
        public int CpuPercent { get; set; }
        /// <summary>
        /// Limit CPU CFS (Completely Fair Scheduler) period
        /// </summary>
        public int CpuPeriod { get; set; }
        /// <summary>
        /// Limit CPU CFS (Completely Fair Scheduler) quota
        /// </summary>
        public int CpuQuota { get; set; }
        /// <summary>
        /// CPU shares (relative weight)
        /// </summary>
        public int CpuShares { get; set; }
        /// <summary>
        /// CPUs in which to allow execution (0-3, 0,1)
        /// </summary>
        public string CpusetCpus { get; set; }
        /// <summary>
        /// MEMs in which to allow execution (0-3, 0,1)
        /// </summary>
        public string CpusetMems { get; set; }
        /// <summary>
        /// Run container in background and print container ID
        /// </summary>
        public bool Detach { get; set; }
        /// <summary>
        /// Override the key sequence for detaching a container
        /// </summary>
        public string DetachKeys { get; set; }
        /// <summary>
        /// Add a host device to the container (default [])
        /// </summary>
        public string[] Device { get; set; }
        /// <summary>
        /// Limit read rate (bytes per second) from a device (default [])
        /// </summary>
        public int[] DeviceReadBps { get; set; }
        /// <summary>
        /// Limit read rate (IO per second) from a device (default [])
        /// </summary>
        public int[] DeviceReadIops { get; set; }
        /// <summary>
        /// Limit write rate (bytes per second) to a device (default [])
        /// </summary>
        public int[] DeviceWriteBps { get; set; }
        /// <summary>
        /// Limit write rate (IO per second) to a device (default [])
        /// </summary>
        public int[] DeviceWriteIops { get; set; }
        /// <summary>
        /// Skip image verification (default true)
        /// </summary>
        public bool DisableContentTrust { get; set; }
        /// <summary>
        /// Set custom DNS servers (default [])
        /// </summary>
        public string[] Dns { get; set; }
        /// <summary>
        /// Set DNS options (default [])
        /// </summary>
        public string[] DnsOpt { get; set; }
        /// <summary>
        /// Set custom DNS search domains (default [])
        /// </summary>
        public string[] DnsSearch { get; set; }
        /// <summary>
        /// Overwrite the default ENTRYPOINT of the image
        /// </summary>
        public string Entrypoint { get; set; }
        /// <summary>
        /// Set environment variables (default [])
        /// </summary>
        public string[] Env { get; set; }
        /// <summary>
        /// Read in a file of environment variables (default [])
        /// </summary>
        public string[] EnvFile { get; set; }
        /// <summary>
        /// Expose a port or a range of ports (default [])
        /// </summary>
        public string[] Expose { get; set; }
        /// <summary>
        /// Add additional groups to join (default [])
        /// </summary>
        public string[] GroupAdd { get; set; }
        /// <summary>
        /// Command to run to check health
        /// </summary>
        public string HealthCmd { get; set; }
        /// <summary>
        /// Time between running the check
        /// </summary>
        public TimeSpan? HealthInterval { get; set; }
        /// <summary>
        /// Consecutive failures needed to report unhealthy
        /// </summary>
        public int HealthRetries { get; set; }
        /// <summary>
        /// Maximum time to allow one check to run
        /// </summary>
        public TimeSpan? HealthTimeout { get; set; }
        /// <summary>
        /// Container host name
        /// </summary>
        public string Hostname { get; set; }
        /// <summary>
        /// Keep STDIN open even if not attached
        /// </summary>
        public bool Interactive { get; set; }
        /// <summary>
        /// Maximum IO bandwidth limit for the system drive (Windows only)
        ///   (Windows only). The format is `<number><unit>`.
        ///   Unit is optional and can be `b` (bytes per second),
        ///   `k` (kilobytes per second), `m` (megabytes per second),
        ///   or `g` (gigabytes per second). If you omit the unit,
        ///   the system uses bytes per second.
        /// </summary>
        public string IoMaxbandwidth { get; set; }
        /// <summary>
        /// Maximum IOps limit for the system drive (Windows only)
        /// </summary>
        public int IoMaxiops { get; set; }
        /// <summary>
        /// Container IPv4 address (e.g. 172.30.100.104)
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Container IPv6 address (e.g. 2001:db8::33)
        /// </summary>
        public string Ip6 { get; set; }
        /// <summary>
        /// IPC namespace to use
        /// </summary>
        public string Ipc { get; set; }
        /// <summary>
        /// Container isolation technology
        /// </summary>
        public string Isolation { get; set; }
        /// <summary>
        /// Kernel memory limit
        /// </summary>
        public string KernelMemory { get; set; }
        /// <summary>
        /// Set meta data on a container (default [])
        /// </summary>
        public string[] Label { get; set; }
        /// <summary>
        /// Read in a line delimited file of labels (default [])
        /// </summary>
        public string[] LabelFile { get; set; }
        /// <summary>
        /// Add link to another container (default [])
        /// </summary>
        public string[] Link { get; set; }
        /// <summary>
        /// Container IPv4/IPv6 link-local addresses (default [])
        /// </summary>
        public string[] LinkLocalIp { get; set; }
        /// <summary>
        /// Logging driver for the container
        /// </summary>
        public string LogDriver { get; set; }
        /// <summary>
        /// Log driver options (default [])
        /// </summary>
        public string[] LogOpt { get; set; }
        /// <summary>
        /// Container MAC address (e.g. 92:d0:c6:0a:29:33)
        /// </summary>
        public string MacAddress { get; set; }
        /// <summary>
        /// Memory limit
        /// </summary>
        public string Memory { get; set; }
        /// <summary>
        /// Memory soft limit
        /// </summary>
        public string MemoryReservation { get; set; }
        /// <summary>
        /// Swap limit equal to memory plus swap: '-1' to enable unlimited swap
        /// </summary>
        public string MemorySwap { get; set; }
        /// <summary>
        /// Tune container memory swappiness (0 to 100) (default -1).
        /// </summary>
        public int MemorySwappiness { get; set; }
        /// <summary>
        /// Assign a name to the container
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Add network-scoped alias for the container (default [])
        /// </summary>
        public string[] NetworkAlias { get; set; }
        /// <summary>
        /// Connect a container to a network
        ///   'bridge': create a network stack on the default Docker bridge
        ///   'none': no networking
        ///   'container:<name|id>': reuse another container's network stack
        ///   'host': use the Docker host network stack
        ///   '<network-name>|<network-id>': connect to a user-defined network
        /// </summary>
        public string Network { get; set; }
        /// <summary>
        /// Disable any container-specified HEALTHCHECK
        /// </summary>
        public bool NoHealthcheck { get; set; }
        /// <summary>
        /// Disable OOM Killer
        /// </summary>
        public bool OomKillDisable { get; set; }
        /// <summary>
        /// Tune host's OOM preferences (-1000 to 1000)
        /// </summary>
        public int OomScoreAdj { get; set; }
        /// <summary>
        /// PID namespace to use
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// Tune container pids limit (set -1 for unlimited)
        /// </summary>
        public int PidsLimit { get; set; }
        /// <summary>
        /// Give extended privileges to this container
        /// </summary>
        public bool Privileged { get; set; }
        /// <summary>
        /// Publish a container's port(s) to the host (default [])
        /// </summary>
        public string[] Publish { get; set; }
        /// <summary>
        /// Publish all exposed ports to random ports
        /// </summary>
        public bool PublishAll { get; set; }
        /// <summary>
        /// Mount the container's root filesystem as read only
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// Restart policy to apply when a container exits (default "no")
        ///   Possible values are : no, on-failure[:max-retry], always, unless-stopped
        /// </summary>
        public string Restart { get; set; }
        /// <summary>
        /// Automatically remove the container when it exits
        /// </summary>
        public bool Rm { get; set; }
        /// <summary>
        /// Runtime to use for this container
        /// </summary>
        public string Runtime { get; set; }
        /// <summary>
        /// Security Options (default [])
        /// </summary>
        public string[] SecurityOpt { get; set; }
        /// <summary>
        /// Size of /dev/shm, default value is 64MB.
        ///   The format is `<number><unit>`. `number` must be greater than `0`.
        ///   Unit is optional and can be `b` (bytes), `k` (kilobytes), `m` (megabytes),
        ///   or `g` (gigabytes). If you omit the unit, the system uses bytes.
        /// </summary>
        public string ShmSize { get; set; }
        /// <summary>
        /// Proxy received signals to the process (default true)
        /// </summary>
        public bool SigProxy { get; set; }
        /// <summary>
        /// Signal to stop a container, SIGTERM by default (default "SIGTERM")
        /// </summary>
        public string StopSignal { get; set; }
        /// <summary>
        /// Storage driver options for the container (default [])
        /// </summary>
        public string[] StorageOpt { get; set; }
        /// <summary>
        /// Sysctl options (default map[])
        /// </summary>
        public string[] Sysctl { get; set; }
        /// <summary>
        /// Mount a tmpfs directory (default [])
        /// </summary>
        public string[] Tmpfs { get; set; }
        /// <summary>
        /// Allocate a pseudo-TTY
        /// </summary>
        public bool Tty { get; set; }
        /// <summary>
        /// Ulimit options (default [])
        /// </summary>
        public string[] Ulimit { get; set; }
        /// <summary>
        /// Username or UID (format: <name|uid>[:<group|gid>])
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// User namespace to use
        ///   'host': Use the Docker host user namespace
        ///   '': Use the Docker daemon user namespace specified by `--userns-remap` option.
        /// </summary>
        public string Userns { get; set; }
        /// <summary>
        /// UTS namespace to use
        /// </summary>
        public string Uts { get; set; }
        /// <summary>
        /// Bind mount a volume (default []). The format
        ///   is `[host-src:]container-dest[:<options>]`.
        ///   The comma-delimited `options` are [rw|ro],
        ///   [z|Z], [[r]shared|[r]slave|[r]private], and
        ///   [nocopy]. The 'host-src' is an absolute path
        ///   or a name value.
        /// </summary>
        public string[] Volume { get; set; }
        /// <summary>
        /// Optional volume driver for the container
        /// </summary>
        public string VolumeDriver { get; set; }
        /// <summary>
        /// Mount volumes from the specified container(s) (default [])
        /// </summary>
        public string[] VolumesFrom { get; set; }
        /// <summary>
        /// Working directory inside the container
        /// </summary>
        public string Workdir { get; set; }
    }
}
