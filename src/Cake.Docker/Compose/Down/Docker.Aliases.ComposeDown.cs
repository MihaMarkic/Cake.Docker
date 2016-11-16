using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose down command.
    /// </summary>
    [CakeAliasCategory("Docker")]
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
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeDownSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("down", settings ?? new DockerComposeDownSettings(), new string[0]);
        }

    }
}
