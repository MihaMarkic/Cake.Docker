using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose restart command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose restart with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeRestart(this ICakeContext context, params string[] services)
        {
            DockerComposeRestart(context, new DockerComposeRestartSettings(), services);
        }

        /// <summary>
        /// Runs docker-compose restart given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRestart(this ICakeContext context, DockerComposeRestartSettings settings, params string[] services)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeRestartSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("restart", settings ?? new DockerComposeRestartSettings(), services);
        }

    }
}
