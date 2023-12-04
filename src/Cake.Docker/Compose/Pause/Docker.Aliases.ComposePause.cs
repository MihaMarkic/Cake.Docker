using System;
using Cake.Core;
using Cake.Core.Annotations;

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
            DockerComposePause(context, new DockerComposeSettings(), services);
        }
        /// <summary>
        /// Runs docker-compose pause.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposePause(this ICakeContext context, DockerComposeSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerComposeRunner<DockerComposeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("pause", settings ?? new DockerComposeSettings(), services);
        }
    }
}