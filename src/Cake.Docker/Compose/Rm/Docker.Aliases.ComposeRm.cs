using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose rm command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose rm with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerComposeRm(this ICakeContext context, string path)
        {
            DockerComposeRm(context, new DockerComposeRmSettings(), path);
        }

        /// <summary>
        /// Runs docker-compose rm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRm(this ICakeContext context, DockerComposeRmSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("rm", settings ?? new DockerComposeRmSettings(), new string[] { path });
        }

    }
}
