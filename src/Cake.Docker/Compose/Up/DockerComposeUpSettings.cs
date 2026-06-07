namespace Cake.Docker;
/// <summary>
/// Settings for docker compose up.
/// </summary>
public sealed class DockerComposeUpSettings : AutoToolSettings
{
	/// <summary>
	/// Stops all containers if any container
	/// was stopped. Incompatible with -d
	/// </summary>
	public bool? AbortOnContainerExit { get; set; }
	/// <summary>
	/// Recreate dependent containers.
	/// Incompatible with --no-recreate.
	/// </summary>
	public bool? AlwaysRecreateDeps { get; set; }
	/// <summary>
	/// Restrict attaching to the specified
	/// services. Incompatible with
	/// --attach-dependencies.
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Attach { get; set; }
	/// <summary>
	/// Automatically attach to log output of
	/// dependent services.
	/// </summary>
	public bool? AttachDependencies { get; set; }
	/// <summary>
	/// Build images before starting containers.
	/// </summary>
	public bool? Build { get; set; }
	/// <summary>
	/// Detached mode: Run containers in the
	/// background
	/// </summary>
	public bool? Detach { get; set; }
	/// <summary>
	/// Return the exit code of the selected
	/// service container. Implies
	/// --abort-on-container-exit
	/// </summary>
	public string? ExitCodeFrom { get; set; }
	/// <summary>
	/// Recreate containers even if their
	/// configuration and image haven't changed.
	/// </summary>
	public bool? ForceRecreate { get; set; }
	/// <summary>
	/// Do not attach (stream logs) to the
	/// specified services.
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? NoAttach { get; set; }
	/// <summary>
	/// Don't build an image, even if it's policy.
	/// </summary>
	public bool? NoBuild { get; set; }
	/// <summary>
	/// Produce monochrome output.
	/// </summary>
	public bool? NoColor { get; set; }
	/// <summary>
	/// Don't start linked services.
	/// </summary>
	public bool? NoDeps { get; set; }
	/// <summary>
	/// Don't print prefix in logs.
	/// </summary>
	public bool? NoLogPrefix { get; set; }
	/// <summary>
	/// If containers already exist, don't
	/// recreate them. Incompatible with
	/// --force-recreate.
	/// </summary>
	public bool? NoRecreate { get; set; }
	/// <summary>
	/// Don't start the services after creating
	/// them.
	/// </summary>
	public bool? NoStart { get; set; }
	/// <summary>
	/// Pull image before running
	/// ("always"|"missing"|"never") (default
	/// "policy")
	/// </summary>
	public string? Pull { get; set; }
	/// <summary>
	/// Pull without printing progress information.
	/// </summary>
	public bool? QuietPull { get; set; }
	/// <summary>
	/// Remove containers for services not
	/// defined in the Compose file.
	/// </summary>
	public bool? RemoveOrphans { get; set; }
	/// <summary>
	/// Recreate anonymous volumes instead of
	/// retrieving data from the previous
	/// containers.
	/// </summary>
	public bool? RenewAnonVolumes { get; set; }
	/// <summary>
	/// Scale SERVICE to NUM instances.
	/// Overrides the scale setting in the
	/// Compose file if present.
	/// </summary>
	public bool? Scale { get; set; }
	/// <summary>
	/// Use this timeout in seconds for
	/// container shutdown when attached or
	/// when containers are already running.
	/// </summary>
	public int? Timeout { get; set; }
	/// <summary>
	/// Show timestamps.
	/// </summary>
	public bool? Timestamps { get; set; }
	/// <summary>
	/// Wait for services to be
	/// running|healthy. Implies detached mode.
	/// </summary>
	public bool? Wait { get; set; }
	/// <summary>
	/// Maximum duration to wait for the
	/// project to be running|healthy.
	/// </summary>
	public int? WaitTimeout { get; set; }
}
