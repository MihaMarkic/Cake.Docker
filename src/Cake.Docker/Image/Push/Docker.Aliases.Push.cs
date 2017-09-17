using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with push command.
    partial class DockerAliases
    {
        /// <summary>
        /// Push an image or a repository to the registry.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="imageReference">The image reference.</param>
        [CakeMethodAlias]
        public static void DockerPush(this ICakeContext context, string imageReference)
        {
            DockerPush(context, new DockerImagePushSettings(), imageReference);
        }

        /// <summary>
        /// Push an image or a repository to the registry with given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="imageReference">The image reference.</param>
        [CakeMethodAlias]
        public static void DockerPush(this ICakeContext context, DockerImagePushSettings settings, string imageReference)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(imageReference))
            {
                throw new ArgumentNullException("imageReference");
            }

            var runner = new GenericDockerRunner<DockerImagePushSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("push", settings ?? new DockerImagePushSettings(), new [] { imageReference });
        }
    }
}
