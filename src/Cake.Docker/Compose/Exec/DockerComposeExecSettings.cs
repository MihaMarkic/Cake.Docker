namespace Cake.Docker;
/// <summary>
/// Settings for docker compose exec.
/// </summary>
public sealed class DockerComposeExecSettings : AutoToolSettings
{
	/// <summary>
	/// Detached mode: Run command in the
	/// background.
	/// </summary>
	public bool? Detach { get; set; }
	/// <summary>
	/// Set environment variables
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Env { get; set; }
	/// <summary>
	/// index of the container if service
	/// has multiple replicas
	/// </summary>
	public int? Index { get; set; }
	/// <summary>
	/// compose exec   Disable pseudo-TTY allocation. By
	/// default docker compose exec
	/// allocates a TTY.
	/// </summary>
	public bool? NoTTY { get; set; }
	/// <summary>
	/// Give extended privileges to the process.
	/// </summary>
	public bool? Privileged { get; set; }
	/// <summary>
	/// Run the command as this user.
	/// </summary>
	public string? User { get; set; }
	/// <summary>
	/// Path to workdir directory for this
	/// command.
	/// </summary>
	public string? Workdir { get; set; }
}
