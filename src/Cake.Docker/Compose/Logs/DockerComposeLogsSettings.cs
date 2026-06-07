namespace Cake.Docker;
/// <summary>
/// Settings for docker compose logs.
/// </summary>
public sealed class DockerComposeLogsSettings : AutoToolSettings
{
	/// <summary>
	/// Follow log output.
	/// </summary>
	public bool? Follow { get; set; }
	/// <summary>
	/// index of the container if service has multiple
	/// replicas
	/// </summary>
	public int? Index { get; set; }
	/// <summary>
	/// Produce monochrome output.
	/// </summary>
	public bool? NoColor { get; set; }
	/// <summary>
	/// Don't print prefix in logs.
	/// </summary>
	public bool? NoLogPrefix { get; set; }
	/// <summary>
	/// Show logs since timestamp (e.g.
	/// 2013-01-02T13:23:37Z) or relative (e.g. 42m for
	/// 42 minutes)
	/// </summary>
	public string? Since { get; set; }
	/// <summary>
	/// Number of lines to show from the end of the logs
	/// for each container. (default "all")
	/// </summary>
	public string? Tail { get; set; }
	/// <summary>
	/// Show timestamps.
	/// </summary>
	public bool? Timestamps { get; set; }
	/// <summary>
	/// Show logs before a timestamp (e.g.
	/// 2013-01-02T13:23:37Z) or relative (e.g. 42m for
	/// 42 minutes)
	/// </summary>
	public string? Until { get; set; }
}
