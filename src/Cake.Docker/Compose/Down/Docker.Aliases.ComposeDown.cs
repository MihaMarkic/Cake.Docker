using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose down command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose down with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerComposeDown(this ICakeContext context)
        {
            DockerComposeDown(context, new DockerComposeDownSettings());
        }

        /// <summary>
        /// Runs docker-compose down given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeDown(this ICakeContext context, DockerComposeDownSettings settings)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerComposeRunner<DockerComposeDownSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("down", settings ?? new DockerComposeDownSettings(), []);
        }

    }
}
