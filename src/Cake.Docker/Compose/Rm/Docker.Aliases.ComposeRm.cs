using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose rm command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose rm with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeRm(this ICakeContext context, params string[] services)
        {
            DockerComposeRm(context, new DockerComposeRmSettings(), null, services);
        }

        /// <summary>
        /// Runs docker-compose rm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRm(this ICakeContext context, DockerComposeRmSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "rm", settings ?? new(),
                services);
        }

    }
}
