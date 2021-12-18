namespace Cake.Docker
{
    /// <summary>
    /// Settings for docker prune [OPTIONS].
    /// Remove unused images
    /// </summary>
    public sealed partial class DockerImagePruneSettings : AutoToolSettings
	{
		/// <summary>
		/// --all, -a
		/// default: false
		/// Remove all unused images, not just dangling ones
		/// </summary>
		public bool? All { get; set; }
		/// <summary>
		/// --filter
		/// Provide filter values (e.g. &#39;until=&lt;timestamp&gt;&#39;)
		/// </summary>
		public string Filter { get; set; }
		/// <summary>
		/// --force, -f
		/// default: false
		/// Do not prompt for confirmation
		/// </summary>
		public bool? Force { get; set; }
	}
}