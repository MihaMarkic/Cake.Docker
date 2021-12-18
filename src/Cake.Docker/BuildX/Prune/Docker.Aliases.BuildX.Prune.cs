using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx prune command.
    partial class DockerAliases
    {
        /// <summary>
        /// Remove build cache.
        /// </summary>
        /// <param name="context">The context.</param>
        /// /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuildXPrune(this ICakeContext context, DockerBuildXPruneSettings settings = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            var runner = new GenericDockerRunner<DockerBuildXPruneSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx prune", new DockerBuildXPruneSettings(), Array.Empty<string>());
        }
    }
}
