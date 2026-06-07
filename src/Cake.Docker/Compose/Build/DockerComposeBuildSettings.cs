namespace Cake.Docker;
/// <summary>
/// Settings for docker compose build.
/// </summary>
public sealed class DockerComposeBuildSettings : AutoToolSettings
{
	/// <summary>
	/// Set build-time variables for services.
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? BuildArg { get; set; }
	/// <summary>
	/// Set builder to use.
	/// </summary>
	public string? Builder { get; set; }
	/// <summary>
	/// Set memory limit for the build container.
	/// Not supported by BuildKit.
	/// </summary>
	public int? Memory { get; set; }
	/// <summary>
	/// Do not use cache when building the image
	/// </summary>
	public bool? NoCache { get; set; }
	/// <summary>
	/// Always attempt to pull a newer version of
	/// the image.
	/// </summary>
	public bool? Pull { get; set; }
	/// <summary>
	/// Push service images.
	/// </summary>
	public bool? Push { get; set; }
	/// <summary>
	/// Don't print anything to STDOUT
	/// </summary>
	public bool? Quiet { get; set; }
	/// <summary>
	/// Set SSH authentications used when
	/// building service images. (use 'default'
	/// for using your default SSH Agent)
	/// </summary>
	public string? Ssh { get; set; }
	/// <summary>
	/// Also build dependencies (transitively).
	/// </summary>
	public bool? WithDependencies { get; set; }
}
