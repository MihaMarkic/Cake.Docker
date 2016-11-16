using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with build command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Builds an image using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerBuild(this ICakeContext context, string path)
        {
            DockerBuild(context, new DockerBuildSettings(), path);
        }

        /// <summary>
        /// Builds an image given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuild(this ICakeContext context, DockerBuildSettings settings, string path)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerRunner<DockerBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("build", settings ?? new DockerBuildSettings(), new string[] { path });
        }

    }
}
