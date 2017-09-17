using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker logs [OPTIONS] CONTAINER.
	/// Fetch the logs of a container
	/// </summary>
	public sealed class DockerContainerLogsSettings : AutoToolSettings
	{
		/// <summary>
		/// --details
		/// default: false
		/// Show extra details provided to logs
		/// </summary>
		public bool? Details { get; set; }
		/// <summary>
		/// --follow, -f
		/// default: false
		/// Follow log output
		/// </summary>
		public bool? Follow { get; set; }
		/// <summary>
		/// --since
		/// Show logs since timestamp (e.g. 2013-01-02T13:23:37) or relative (e.g. 42m for 42 minutes)
		/// </summary>
		public string Since { get; set; }
		/// <summary>
		/// --tail
		/// default: all
		/// Number of lines to show from the end of the logs
		/// </summary>
		public string Tail { get; set; }
		/// <summary>
		/// --timestamps, -t
		/// default: false
		/// Show timestamps
		/// </summary>
		public bool? Timestamps { get; set; }
	}
}