using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose pull command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose pull with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerComposePull(this ICakeContext context, string path)
        {
            DockerComposePull(context, new DockerComposePullSettings(), path);
        }

        /// <summary>
        /// Runs docker-compose pull given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposePull(this ICakeContext context, DockerComposePullSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerRunner<DockerComposePullSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("docker-compose pull", settings ?? new DockerComposePullSettings(), new string[] { path });
        }

    }
}
