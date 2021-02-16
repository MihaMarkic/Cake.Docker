using System;

namespace Cake.Docker
{
	/// <summary>
	/// Settings for docker push [OPTIONS] NAME[:TAG].
	/// Push an image or a repository to a registry
	/// </summary>
	public sealed partial class DockerImagePushSettings : AutoToolSettings
	{
        /// <summary>
        /// --disable-content-trust
        /// default: true
        /// Skip image signing
        /// </summary>
        [AutoProperty(Format = Constants.BoolWithTrueDefaultFormat)]
        public bool? DisableContentTrust { get; set; }
        /// <summary>
        /// Push all tagged images in the repository
        /// </summary>
        public bool AllTags { get; set; }
    }
}