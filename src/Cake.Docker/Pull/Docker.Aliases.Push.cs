using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with push command.
    /// </summary>
    [CakeAliasCategory("Docker")]
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
            DockerPush(context, new DockerPushSettings(), imageReference);
        }

        /// <summary>
        /// Push an image or a repository to the registry with given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="imageReference">The image reference.</param>
        [CakeMethodAlias]
        public static void DockerPush(this ICakeContext context, DockerPushSettings settings, string imageReference)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(imageReference))
            {
                throw new ArgumentNullException("imageReference");
            }

            var runner = new GenericDockerRunner<DockerPushSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("push", settings ?? new DockerPushSettings(), new [] { imageReference });
        }
    }
}
