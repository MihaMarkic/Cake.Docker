using Cake.Core;
using Cake.Core.Annotations;
using Cake.Docker.Rm;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        
        /// <summary>
        /// Builds an image using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerBuild(this ICakeContext context, string path)
        {
            DockerStop(context, path);
        }

        /// <summary>
        /// Builds an image given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerBuild(this ICakeContext context, string path, DockerBuildSettings settings)
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
