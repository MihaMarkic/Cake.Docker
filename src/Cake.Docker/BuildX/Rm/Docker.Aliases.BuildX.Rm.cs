using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx rm command.
    partial class DockerAliases
    {
        /// <summary>
        /// Remove a builder instance using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name"></param>
        [CakeMethodAlias]
        public static void DockerBuildXRm(this ICakeContext context, string name = null)
        {
            context.DockerBuildXRm(name);
        }
        /// <summary>
        /// Remove a builder instance given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="name"></param>
        [CakeMethodAlias]
        public static void DockerBuildXRm(this ICakeContext context, DockerBuildXRmSettings settings = null, string name = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var runner = new GenericDockerRunner<DockerBuildXRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx rm", new DockerBuildXRmSettings(), new string[] { name });
        }
    }
}
