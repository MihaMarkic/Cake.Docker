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
        /// Runs docker-compose build with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerComposeBuild(this ICakeContext context, string path)
        {
            DockerComposeBuild(context, new DockerComposeBuildSettings(), path);
        }

        /// <summary>
        /// Runs docker-compose build given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeBuild(this ICakeContext context, DockerComposeBuildSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerRunner<DockerComposeBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("docker-compose build", settings ?? new DockerComposeBuildSettings(), new string[] { path });
        }

    }
}
