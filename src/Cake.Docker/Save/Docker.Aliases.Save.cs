using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Stops an array of <paramref name="images"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="images"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
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
            var runner = new GenericDockerRunner<DockerSaveSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("save", settings ?? new DockerSaveSettings(), images);
        }
    }
}
