using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose unpause command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose unpause with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeUnpause(this ICakeContext context, params string[] services)
        {
            DockerComposeUnpause(context, new DockerComposeSettings(), services);
        }
        /// <summary>
        /// Runs docker-compose unpause.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeUnpause(this ICakeContext context, DockerComposeSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("compose unpause", settings ?? new DockerComposeSettings(), services);
        }
    }
}