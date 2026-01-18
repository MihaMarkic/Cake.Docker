using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose start command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose start with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeStart(this ICakeContext context, params string[] services)
        {
            DockerComposeStart(context, new DockerComposeSettings(), null, services);
        }
        /// <summary>
        /// Runs docker-compose start.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeStart(this ICakeContext context, DockerComposeSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "start", settings ?? new(), services);
        }
    }
}