using System;
using Cake.Core;
using Cake.Core.Annotations;

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
            DockerComposeUp(context, new DockerComposeUpSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose up given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeUp(this ICakeContext context, DockerComposeUpSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerComposeRunner<DockerComposeUpSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("up", settings ?? new DockerComposeUpSettings(), services);
        }

    }
}
