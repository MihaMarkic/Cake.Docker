using System;
using Cake.Core;
using Cake.Core.Annotations;

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
            DockerComposePush(context, new DockerComposePushSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose push given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposePush(this ICakeContext context, DockerComposePushSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerComposeRunner<DockerComposePushSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("push", settings ?? new DockerComposePushSettings(), services);
        }

    }
}
