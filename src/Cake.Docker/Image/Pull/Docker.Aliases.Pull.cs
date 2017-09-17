using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with push command.
    partial class DockerAliases
    {
        /// <summary>
        /// Pull an image or a repository from the registry.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="imageReference">The image reference.</param>
        [CakeMethodAlias]
        public static void DockerPull(this ICakeContext context, string imageReference)
        {
            DockerPull(context, new DockerImagePullSettings(), imageReference);
        }

        /// <summary>
        /// Pull an image or a repository from the registry with given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="imageReference">The image reference.</param>
        [CakeMethodAlias]
        public static void DockerPull(this ICakeContext context, DockerImagePullSettings settings, string imageReference)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(imageReference))
            {
                throw new ArgumentNullException("imageReference");
            }

            var runner = new GenericDockerRunner<DockerImagePullSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("pull", settings ?? new DockerImagePullSettings(), new [] { imageReference });
        }
    }
}
