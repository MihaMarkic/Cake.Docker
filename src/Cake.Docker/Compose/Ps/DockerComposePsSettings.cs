namespace Cake.Docker;
/// <summary>
/// Settings for docker compose ps.
/// </summary>
public sealed class DockerComposePsSettings : AutoToolSettings
{
	/// <summary>
	/// Show all stopped containers (including those
	/// created by the run command)
	/// </summary>
	public bool? All { get; set; }
    /// <summary>
    /// Filter services by a property (supported
    /// filters: status).
    /// </summary>
    [AutoProperty(Format = "--filter {1}")]
    public string[]? Filter { get; set; }
    /// <summary>
    /// Format output using a custom template:
    /// 'table':            Print output in table
    /// format with column headers (default)
    /// 'table TEMPLATE':   Print output in table
    /// format using the given Go template
    /// 'json':             Print in JSON format
    /// 'TEMPLATE':         Print output using the
    /// given Go template.
    /// Refer to
    /// https://docs.docker.com/go/formatting/ for
    /// more information about formatting output
    /// with templates (default "table")
    /// </summary>
    public string? Format { get; set; }
	/// <summary>
	/// Don't truncate output
	/// </summary>
	public bool? NoTrunc { get; set; }
	/// <summary>
	/// Include orphaned services (not declared by
	/// project) (default true)
	/// </summary>
	public bool? Orphans { get; set; }
	/// <summary>
	/// Only display IDs
	/// </summary>
	public bool? Quiet { get; set; }
	/// <summary>
	/// Display services
	/// </summary>
	public bool? Services { get; set; }
	/// <summary>
	/// Filter services by status. Values: [paused |
	/// restarting | removing | running | dead |
	/// created | exited]
	/// </summary>
	[AutoProperty(AutoArrayType=AutoArrayType.List)]
	public string[]? Status { get; set; }
}
