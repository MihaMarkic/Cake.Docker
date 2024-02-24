namespace Cake.Docker;
/// <summary>
/// Settings for docker compose run.
/// </summary>
public sealed class DockerComposeRunSettings : AutoToolSettings
{
	/// <summary>
	/// Build image before starting container.
	/// </summary>
	public bool? Build { get; set; }
	/// <summary>
	/// Add Linux capabilities
	/// </summary>
	public bool? CapAdd { get; set; }
	/// <summary>
	/// Drop Linux capabilities
	/// </summary>
	public bool? CapDrop { get; set; }
	/// <summary>
	/// Run container in background and print
	/// container ID
	/// </summary>
	public bool? Detach { get; set; }
	/// <summary>
	/// Override the entrypoint of the image
	/// </summary>
	public string? Entrypoint { get; set; }
	/// <summary>
	/// Set environment variables
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Env { get; set; }
	/// <summary>
	/// Keep STDIN open even if not attached.
	/// (default true)
	/// </summary>
	public bool? Interactive { get; set; }
	/// <summary>
	/// Add or override a label
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Label { get; set; }
	/// <summary>
	/// Assign a name to the container
	/// </summary>
	public string? Name { get; set; }
	/// <summary>
	/// Disable pseudo-TTY allocation (default:
	/// auto-detected).
	/// </summary>
	public bool? NoTTY { get; set; }
	/// <summary>
	/// Don't start linked services.
	/// </summary>
	public bool? NoDeps { get; set; }
	/// <summary>
	/// Publish a container's port(s) to the host.
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Publish { get; set; }
	/// <summary>
	/// Pull without printing progress information.
	/// </summary>
	public bool? QuietPull { get; set; }
	/// <summary>
	/// Remove containers for services not defined
	/// in the Compose file.
	/// </summary>
	public bool? RemoveOrphans { get; set; }
	/// <summary>
	/// Automatically remove the container when it exits
	/// </summary>
	public bool? Rm { get; set; }
	/// <summary>
	/// Run command with all service's ports
	/// enabled and mapped to the host.
	/// </summary>
	public bool? ServicePorts { get; set; }
	/// <summary>
	/// Use the service's network useAliases in the
	/// network(s) the container connects to.
	/// </summary>
	public bool? UseAliases { get; set; }
	/// <summary>
	/// Run as specified username or uid
	/// </summary>
	public string? User { get; set; }
	/// <summary>
	/// Bind mount a volume.
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Volume { get; set; }
	/// <summary>
	/// Working directory inside the container
	/// </summary>
	public string? Workdir { get; set; }
}
