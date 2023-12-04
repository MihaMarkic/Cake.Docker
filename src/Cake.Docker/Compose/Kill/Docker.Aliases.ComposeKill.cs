using System;
using Cake.Core;
using Cake.Core.Annotations;

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
        [CakeMethodAlias]
        public static void DockerComposeKill(this ICakeContext context, DockerComposeKillSettings settings)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerComposeRunner<DockerComposeKillSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("kill", settings ?? new DockerComposeKillSettings(), []);
        }

    }
}
