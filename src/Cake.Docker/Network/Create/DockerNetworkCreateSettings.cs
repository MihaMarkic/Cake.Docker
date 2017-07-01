namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker swarm init.
    /// </summary>
    public sealed class DockerNetworkCreateSettings : AutoToolSettings
    {
        /// <summary>
        /// --attachable 
        /// default: false
        /// Enable manual container attachment
        /// </summary>
        public bool? Attachable { get; set; }
        /// <summary>
        /// --aux-address 
        /// default: map[]
        /// Auxiliary IPv4 or IPv6 addresses used by Network driver
        /// </summary>
        public string AuxAddress { get; set; }
        /// <summary>
        /// --config-from 
        /// The network from which copying the configuration
        /// </summary>
        public string ConfigFrom { get; set; }
        /// <summary>
        /// --config-only 
        /// default: false
        /// Create a configuration only network
        /// </summary>
        public bool? ConfigOnly { get; set; }
        /// <summary>
        /// --driver, -d 
        /// default: bridge
        /// Driver to manage the Network
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// --gateway 
        /// IPv4 or IPv6 Gateway for the master subnet
        /// </summary>
        public string Gateway { get; set; }
        /// <summary>
        /// --ingress 
        /// default: false
        /// Create swarm routing-mesh network
        /// </summary>
        public bool? Ingress { get; set; }
        /// <summary>
        /// --internal 
        /// default: false
        /// Restrict external access to the network
        /// </summary>
        public bool? Internal { get; set; }
        /// <summary>
        /// --ip-range 
        /// Allocate container ip from a sub-range
        /// </summary>
        public string IpRange { get; set; }
        /// <summary>
        /// --ipam-driver 
        /// default: default
        /// IP Address Management Driver
        /// </summary>
        public string IpamDriver { get; set; }
        /// <summary>
        /// --ipam-opt 
        /// default: map[]
        /// Set IPAM driver specific options
        /// </summary>
        public string IpamOpt { get; set; }
        /// <summary>
        /// --ipv6 
        /// default: false
        /// Enable IPv6 networking
        /// </summary>
        public bool? Ipv6 { get; set; }
        /// <summary>
        /// --label 
        /// Set metadata on a network
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// --opt, -o 
        /// default: map[]
        /// Set driver specific options
        /// </summary>
        public string Opt { get; set; }
        /// <summary>
        /// --scope 
        /// Control the network’s scope
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// --subnet 
        /// Subnet in CIDR format that represents a network segment
        /// </summary>
        public string Subnet { get; set; }
    }
}
