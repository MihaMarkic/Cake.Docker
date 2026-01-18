using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose kill command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose kill with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerComposeKill(this ICakeContext context)
        {
            DockerComposeKill(context, new DockerComposeKillSettings());
        }

        /// <summary>
        /// Runs docker-compose kill given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeKill(this ICakeContext context, DockerComposeKillSettings? settings,
            DockerComposeSettings? composeSettings = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeKillSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new DockerComposeSettings(),
                "kill", settings ?? new DockerComposeKillSettings(),
                Array.Empty<string>());
        }

    }
}
