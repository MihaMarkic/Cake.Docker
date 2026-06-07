using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose restart command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose restart with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeRestart(this ICakeContext context, params string[] services)
        {
            DockerComposeRestart(context, new DockerComposeRestartSettings(), null, services);
        }

        /// <summary>
        /// Runs docker-compose restart given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRestart(this ICakeContext context, DockerComposeRestartSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeRestartSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "restart", settings ?? new(), services);
        }

    }
}
