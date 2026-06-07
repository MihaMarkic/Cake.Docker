using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker compose cp command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker compose cp with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="source">Source path.</param>
        /// <param name="destination">Destination path.</param>
        [CakeMethodAlias]
        public static void DockerComposeCp(this ICakeContext context, string source, string destination)
        {
            DockerComposeCp(context, source, destination, new DockerComposeCpSettings());
        }
        /// <summary>
        /// Copy files from/to container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="source">Source path.</param>
        /// <param name="destination">Destination path.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeCp(this ICakeContext context, string source, string destination, DockerComposeCpSettings? settings,
            DockerComposeSettings? composeSettings = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException(nameof(destination));
            }
            var runner = new GenericDockerRunner<DockerComposeCpSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new DockerComposeSettings(),
                "cp", settings ?? new DockerComposeCpSettings(), new[] { source, destination });
        }
    }
}
