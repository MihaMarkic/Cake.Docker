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
        public static void DockerRun(this ICakeContext context, string path)
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
            runner.Run("run", new DockerBuildSettings(), new string[] { path });
        }

    }
}
