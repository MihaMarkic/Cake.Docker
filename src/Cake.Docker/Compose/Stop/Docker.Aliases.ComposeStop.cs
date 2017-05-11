using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose stop command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose stop with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeStop(this ICakeContext context, params string[] services)
        {
            DockerComposeStop(context, new DockerComposeBuildSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose stop given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeStop(this ICakeContext context, DockerComposeBuildSettings settings, params string[] services)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("stop", settings ?? new DockerComposeBuildSettings(), services);
        }

    }
}
