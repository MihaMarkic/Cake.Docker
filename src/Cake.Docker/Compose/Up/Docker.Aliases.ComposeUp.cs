using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose up command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose up with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeUp(this ICakeContext context, params string[] services)
        {
            DockerComposeUp(context, new DockerComposeUpSettings(), null, services);
        }

        /// <summary>
        /// Runs docker-compose up given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeUp(this ICakeContext context, DockerComposeUpSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeUpSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "up", settings ?? new(), services);
        }

    }
}
