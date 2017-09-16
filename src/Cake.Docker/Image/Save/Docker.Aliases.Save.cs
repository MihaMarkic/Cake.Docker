using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with save command.
    partial class DockerAliases
    {
        /// <summary>
        /// Save one or more images to a tar archive (streamed to STDOUT by default).
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="images">The list of images.</param>
        [CakeMethodAlias]
		public static void DockerSave(this ICakeContext context, DockerSaveSettings settings, params string[] images)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (images == null || images.Length == 0)
            {
                throw new ArgumentNullException("images");
            }
            var runner = new GenericDockerRunner<DockerSaveSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("save", settings ?? new DockerSaveSettings(), images);
        }
    }
}
