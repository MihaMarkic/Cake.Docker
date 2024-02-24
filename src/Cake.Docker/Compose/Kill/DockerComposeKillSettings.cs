namespace Cake.Docker;
/// <summary>
/// Settings for docker compose kill.
/// </summary>
public sealed class DockerComposeKillSettings : AutoToolSettings
{
	/// <summary>
	/// Remove containers for services not defined in
	/// the Compose file.
	/// </summary>
	public bool? RemoveOrphans { get; set; }
	/// <summary>
	/// SIGNAL to send to the container. (default "SIGKILL")
	/// </summary>
	public string? Signal { get; set; }
}
