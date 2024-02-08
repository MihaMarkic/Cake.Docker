using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose create command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose create with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeCreate(this ICakeContext context, params string[] services)
        {
            DockerComposeCreate(context, new DockerComposeCreateSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose create given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeCreate(this ICakeContext context, DockerComposeCreateSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("compose create", settings ?? new DockerComposeCreateSettings(), services);
        }

    }
}
