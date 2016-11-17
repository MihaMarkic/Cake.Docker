using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose pull command.
    /// </summary>
    [CakeAliasCategory("Docker")]
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
            DockerComposePull(context, new DockerComposePullSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose pull given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposePull(this ICakeContext context, DockerComposePullSettings settings, params string[] services)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposePullSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("pull", settings ?? new DockerComposePullSettings(), services);
        }

    }
}
