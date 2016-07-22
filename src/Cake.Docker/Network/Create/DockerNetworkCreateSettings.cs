namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerNetworkCreateSettings : AutoToolSettings
    {
        /// <summary>
        /// auxiliary ipv4 or ipv6 addresses used by Network driver (default map[])
        /// </summary>
        public string[] AuxAddress { get; set; }
        /// <summary>
        /// Driver to manage the Network (default "bridge")
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// ipv4 or ipv6 Gateway for the master subnet (default [])
        /// </summary>
        public string[] Gateway { get; set; }
        /// <summary>
        /// Print usage
        /// </summary>
        public bool Help { get; set; }
        /// <summary>
        /// restricts external access to the network
        /// </summary>
        public bool Internal { get; set; }
        /// <summary>
        /// allocate container ip from a sub-range (default [])
        /// </summary>
        public string[] IpRange { get; set; }
        /// <summary>
        /// IP Address Management Driver (default "default")
        /// </summary>
        public string IpamDriver { get; set; }
        /// <summary>
        /// set IPAM driver specific options (default map[])
        /// </summary>
        public string[] IpamOpt { get; set; }
        /// <summary>
        /// enable IPv6 networking
        /// </summary>
        public bool Ipv6 { get; set; }
        /// <summary>
        /// Set metadata on a network (default [])
        /// </summary>
        public string[] Label { get; set; }
        /// <summary>
        /// Set driver specific options (default map[])
        /// </summary>
        public string[] Opt { get; set; }
        /// <summary>
        /// subnet in CIDR format that represents a network segment (default [])
        /// </summary>
        public string[] Subnet { get; set; }
    }
}
