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
        /// Runs docker-compose kill with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerComposeKill(this ICakeContext context)
        {
            DockerComposeKill(context, new DockerComposeKillSettings());
        }

        /// <summary>
        /// Runs docker-compose kill given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeKill(this ICakeContext context, DockerComposeKillSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerComposeKillSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("docker-compose kill", settings ?? new DockerComposeKillSettings(), new string[0]);
        }

    }
}
