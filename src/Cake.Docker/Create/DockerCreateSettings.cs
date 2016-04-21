using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker build.
    /// </summary>
    public sealed class DockerCreateSettings: AutoToolSettings
    {
        /// <summary>
        /// Attach to STDIN, STDOUT or STDERR
        /// </summary>
        public string[] Attach { get; set; }
        /// <summary>
        /// Add a custom host-to-IP mapping (host:ip)
        /// </summary>
        public string[] AddHost { get; set; }
        /// <summary>
        /// Block IO weight (relative weight)
        /// </summary>
        public int? BlkioWeight { get; set; }
        /// <summary>
        /// Block IO weight (relative device weight, format: `DEVICE_NAME:WEIGHT`)
        /// </summary>
        public string[] BlkioWeightDevice { get; set; }
        /// <summary>
        /// CPU shares (relative weight)
        /// </summary>
        public int? CpuShares { get; set; }
        /// <summary>
        /// Add Linux capabilities
        /// </summary>
        public string[] CapAdd { get; set; }
        /// <summary>
        /// Drop Linux capabilities
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
        /// Limit CPU CFS (Completely Fair Scheduler) period
        /// </summary>
        public int? CpuPeriod { get; set; }
        /// <summary>
        /// Limit CPU CFS (Completely Fair Scheduler) quota
        /// </summary>
        public int? CpuQuota { get; set; }
        /// <summary>
        /// CPUs in which to allow execution (0-3, 0,1)
        /// </summary>
        public string CpusetCpus { get; set; }
        /// <summary>
        /// Memory nodes (MEMs) in which to allow execution (0-3, 0,1)
        /// </summary>
        public string CpusetMems { get; set; }
        /// <summary>
        /// Add a host device to the container
        /// </summary>
        public string[] Device { get; set; }
        /// <summary>
        /// Limit read rate (bytes per second) from a device (e.g., --device-read-bps=/dev/sda:1mb)
        /// </summary>
        public string[] DeviceReadBps { get; set; }
        /// <summary>
        /// Limit read rate (IO per second) from a device (e.g., --device-read-iops=/dev/sda:1000)
        /// </summary>
        public string[] DeviceReadIops { get; set; }
        /// <summary>
        /// Limit write rate (bytes per second) to a device (e.g., --device-write-bps=/dev/sda:1mb)
        /// </summary>
        public string[] DeviceWriteBps { get; set; }
        /// <summary>
        /// Limit write rate (IO per second) to a device (e.g., --device-write-iops=/dev/sda:1000)
        /// </summary>
        public string[] DeviceWriteIops { get; set; }
        /// <summary>
        /// Skip image verification
        /// </summary>
        public string DisableContentTrust { get; set; }
        /// <summary>
        /// Set custom DNS servers
        /// </summary>
        public string[] Dns { get; set; }
        /// <summary>
        /// Set custom DNS options
        /// </summary>
        public string[] DnsOpt { get; set; }
        /// <summary>
        /// Set custom DNS search domains
        /// </summary>
        public string[] DnsSearch { get; set; }
        /// <summary>
        /// Set environment variables
        /// </summary>
        public Dictionary<string, string> Env { get; set; }
        /// <summary>
        /// Overwrite the default ENTRYPOINT of the image
        /// </summary>
        public string Entrypoint { get; set; }
        /// <summary>
        /// Read in a file of environment variables
        /// </summary>
        public string[] EnvFile { get; set; }
        /// <summary>
        /// Expose a port or a range of ports
        /// </summary>
        public string[] Expose { get; set; }
        /// <summary>
        /// Add additional groups to join
        /// </summary>
        public string[] GroupAdd { get; set; }
        /// <summary>
        /// Container host name
        /// </summary>
        public string Hostname { get; set; }
        /// <summary>
        /// Print usage
        /// </summary>
        public bool? Help { get; set; }
        /// <summary>
        /// Keep STDIN open even if not attached
        /// </summary>
        public bool? Interactive { get; set; }
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
        /// Set metadata on the container (e.g., --label=com.example.key=value)
        /// </summary>
        public string[] Label { get; set; }
        /// <summary>
        /// Read in a line delimited file of labels
        /// </summary>
        public string[] LabelFile { get; set; }
        /// <summary>
        /// Add link to another container
        /// </summary>
        public string[] Link { get; set; }
        /// <summary>
        /// Logging driver for container
        /// </summary>
        public string LogDriver { get; set; }
        /// <summary>
        /// Log driver specific options
        /// </summary>
        public string[] LogOpt { get; set; }
        /// <summary>
        /// Memory limit
        /// </summary>
        public string Memory { get; set; }
        /// <summary>
        /// Container MAC address (e.g. 92:d0:c6:0a:29:33)
        /// </summary>
        public string MacAddress { get; set; }
        /// <summary>
        /// Memory soft limit
        /// </summary>
        public string MemoryReservation { get; set; }
        /// <summary>
        /// A positive integer equal to memory plus swap. Specify -1 to enable unlimited swap.
        /// </summary>
        public string MemorySwap { get; set; }
        /// <summary>
        /// Tune a container's memory swappiness behavior. Accepts an integer between 0 and 100.
        /// </summary>
        public string MemorySwappiness { get; set; }
        /// <summary>
        /// Assign a name to the container
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Connect a container to a network
        /// </summary>
        public string Net { get; set; }
        /// <summary>
        /// Add network-scoped alias for the container
        /// </summary>
        public string[] NetAlias { get; set; }
        /// <summary>
        /// Whether to disable OOM Killer for the container or not
        /// </summary>
        public bool? OomKillDisable { get; set; }
        /// <summary>
        /// Tune the host's OOM preferences for containers (accepts -1000 to 1000)
        /// </summary>
        public int? OomScoreAdj { get; set; }
        /// <summary>
        /// Publish all exposed ports to random ports
        /// </summary>
        public bool? PublishAll { get; set; }
        /// <summary>
        /// Publish a container's port(s) to the host
        /// </summary>
        public string[] Publish { get; set; }
        /// <summary>
        /// PID namespace to use
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// Tune container pids limit (set -1 for unlimited), kernel >= 4.3
        /// </summary>
        public int? PidsLimit { get; set; }
        /// <summary>
        /// Give extended privileges to this container
        /// </summary>
        public bool? Privileged { get; set; }
        /// <summary>
        /// Mount the container's root filesystem as read only
        /// </summary>
        public bool? ReadOnly { get; set; }
        /// <summary>
        /// Restart policy (no, on-failure[:max-retry], always, unless-stopped)
        /// </summary>
        public string Restart { get; set; }
        /// <summary>
        /// Security options
        /// </summary>
        public string[] SecurityOpt { get; set; }
        /// <summary>
        /// Signal to stop a container
        /// </summary>
        public string StopSignal { get; set; }
        /// <summary>
        /// Size of `/dev/shm`. The format is `<number><unit>`. `number` must be greater than `0`.  Unit is optional and can be `b` (bytes), `k` (kilobytes), `m` (megabytes), or `g` (gigabytes). If you omit the unit, the system uses bytes. If you omit the size entirely, the system uses `64m`.
        /// </summary>
        public string[] ShmSize { get; set; }
        /// <summary>
        /// Allocate a pseudo-TTY
        /// </summary>
        public bool? Tty { get; set; }
        /// <summary>
        /// Username or UID
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Container user namespace
        /// </summary>
        public string Userns { get; set; }
        /// <summary>
        /// Ulimit options
        /// </summary>
        public string[] Ulimit { get; set; }
        /// <summary>
        /// UTS namespace to use
        /// </summary>
        public string Uts { get; set; }
        /// <summary>
        /// iner-dest[:<options>]
        /// </summary>
        public string Volume { get; set; }
        /// <summary>
        /// Container's volume driver
        /// </summary>
        public string VolumeDriver { get; set; }
        /// <summary>
        /// Mount volumes from the specified container(s)
        /// </summary>
        public string[] VolumesFrom { get; set; }
        /// <summary>
        /// Working directory inside the container
        /// </summary>
        public string Workdir { get; set; }


    }
}
