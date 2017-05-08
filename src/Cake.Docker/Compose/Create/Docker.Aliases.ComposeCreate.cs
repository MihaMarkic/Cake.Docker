using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose build command.
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
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("create", settings ?? new DockerComposeCreateSettings(), services);
        }

    }
}
