using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose build command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose build with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeBuild(this ICakeContext context, params string[] services)
        {
            DockerComposeBuild(context, new DockerComposeBuildSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose build given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeBuild(this ICakeContext context, DockerComposeBuildSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("compose build", settings ?? new DockerComposeBuildSettings(), services);
        }

    }
}
