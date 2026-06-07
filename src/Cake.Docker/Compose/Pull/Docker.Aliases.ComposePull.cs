using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose pull command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose pull with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposePull(this ICakeContext context, params string[] services)
        {
            DockerComposePull(context, new DockerComposePullSettings(), null, services);
        }

        /// <summary>
        /// Runs docker-compose pull given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposePull(this ICakeContext context, DockerComposePullSettings? settings,
            DockerComposeSettings? composeSettings = null, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposePullSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("compose", composeSettings ?? new(),
                "pull", settings ?? new(),
                services);
        }

    }
}
