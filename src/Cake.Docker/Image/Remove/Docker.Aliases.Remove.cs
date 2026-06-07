using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with rmi command.
    partial class DockerAliases
    {
        /// <summary>
        /// Removes an array of <paramref name="images"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="images">The list of images.</param>
        [CakeMethodAlias]
        public static void DockerRmi(this ICakeContext context, params string[] images)
        {
            DockerRemove(context, new DockerImageRemoveSettings(), images);
        }

        /// <summary>
        /// Removes an array of <paramref name="images"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="images">The list of images.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerRemove(this ICakeContext context, DockerImageRemoveSettings? settings, params string[] images)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (images == null || images.Length == 0)
            {
                throw new ArgumentNullException(nameof(images));
            }
            var runner = new GenericDockerRunner<DockerImageRemoveSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("rmi", settings ?? new DockerImageRemoveSettings(), images);
        }
    }
}
