using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with tag command.
    partial class DockerAliases
    {
        /// <summary>
        /// Tag an image into a repository.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="imageReference">The image reference.</param>
        /// <param name="registryReference">The registry reference.</param>
        [CakeMethodAlias]
        public static void DockerTag(this ICakeContext context, string imageReference, string registryReference)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            if (string.IsNullOrEmpty(imageReference))
            {
                throw new ArgumentNullException(nameof(imageReference));
            }
            if (string.IsNullOrEmpty(registryReference))
            {
                throw new ArgumentNullException(nameof(registryReference));
            }

            var runner = new GenericDockerRunner<DockerImageTagSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("tag", new DockerImageTagSettings(), [imageReference, registryReference]);
        }
    }
}
