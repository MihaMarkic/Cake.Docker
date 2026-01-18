using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose down command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose down with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerComposeDown(this ICakeContext context)
        {
            DockerComposeDown(context, new DockerComposeDownSettings());
        }

        /// <summary>
        /// Runs docker-compose down given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeDown(this ICakeContext context, DockerComposeDownSettings? settings,
            DockerComposeSettings? composeSettings = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeDownSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new DockerComposeSettings(),
                "down", settings ?? new DockerComposeDownSettings(),
                Array.Empty<string>());
        }

    }
}
