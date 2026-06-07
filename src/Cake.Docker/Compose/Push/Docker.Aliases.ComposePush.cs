using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose push command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose push with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposePush(this ICakeContext context, params string[] services)
        {
            DockerComposePush(context, new DockerComposePushSettings(), null, services);
        }

        /// <summary>
        /// Runs docker-compose push given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposePush(this ICakeContext context, DockerComposePushSettings? settings,
            DockerComposeSettings? composeSettings = null, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposePushSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "push", settings ?? new(), services);
        }

    }
}
