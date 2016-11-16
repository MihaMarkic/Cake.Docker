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
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerComposeStart(this ICakeContext context, string path)
        {
            DockerComposeStart(context, new DockerComposeSettings(), path);
        }
        /// <summary>
        /// Runs docker-compose start.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerComposeStart(this ICakeContext context, DockerComposeSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("start", settings ?? new DockerComposeSettings(), new string[] { path });
        }
    }
}