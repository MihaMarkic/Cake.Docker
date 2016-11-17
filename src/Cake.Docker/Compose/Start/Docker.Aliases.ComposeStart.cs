using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose start command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose start with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeStart(this ICakeContext context, params string[] services)
        {
            DockerComposeStart(context, new DockerComposeSettings(), services);
        }
        /// <summary>
        /// Runs docker-compose start.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeStart(this ICakeContext context, DockerComposeSettings settings, params string[] services)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("start", settings ?? new DockerComposeSettings(), services);
        }
    }
}