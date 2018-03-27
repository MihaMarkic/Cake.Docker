using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker tag SOURCE_IMAGE[:TAG] TARGET_IMAGE[:TAG].
	/// Create a tag TARGET_IMAGE that refers to SOURCE_IMAGE
	/// </summary>
	public sealed partial class DockerImageTagSettings : AutoToolSettings
	{
	}
}