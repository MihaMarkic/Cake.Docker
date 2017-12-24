using System;

namespace Cake.Docker
{
	partial class DockerRegistryLoginSettings
    {
        /// <summary>
        /// Adds <see cref="Password"/> to secret properties.
        /// </summary>
        /// <returns></returns>
        protected override string[] CollectSecretProperties() => new string[] { nameof(Password) };
    }
}