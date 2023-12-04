using System;
using Cake.Core;
using Cake.Core.Annotations;

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
            DockerComposeRm(context, new DockerComposeRmSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose rm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRm(this ICakeContext context, DockerComposeRmSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerComposeRunner<DockerComposeRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("rm", settings ?? new DockerComposeRmSettings(), services);
        }

    }
}
