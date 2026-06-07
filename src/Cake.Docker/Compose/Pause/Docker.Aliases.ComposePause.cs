using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose pause command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose pause with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposePause(this ICakeContext context, params string[] services)
        {
            DockerComposePause(context, new DockerComposeSettings(), null, services);
        }
        /// <summary>
        /// Runs docker-compose pause.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposePause(this ICakeContext context, DockerComposeSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "pause", settings ?? new DockerComposeSettings(),
                services);
        }
    }
}