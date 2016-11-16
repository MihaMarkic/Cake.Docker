using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose build command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose create with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerComposeCreate(this ICakeContext context, string path)
        {
            DockerComposeCreate(context, new DockerComposeCreateSettings(), path);
        }

        /// <summary>
        /// Runs docker-compose create given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeCreate(this ICakeContext context, DockerComposeCreateSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerRunner<DockerComposeCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("docker-compose create", settings ?? new DockerComposeCreateSettings(), new string[] { path });
        }

    }
}
