using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Removes an array of <paramref name="images"/> using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="images"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerRmi(this ICakeContext context, string[] images)
        {
            DockerRmi(context, images, new DockerRmiSettings());
        }
        /// <summary>
        /// Removes an <paramref name="image"/> using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="image"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerRmi(this ICakeContext context, string image)
        {
            DockerRmi(context, new string[] { image });
        }
        /// <summary>
        /// Removes an <paramref name="image"/> using the given <paramref name="settings" />.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="image"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerRmi(this ICakeContext context, string image, DockerRmiSettings settings)
        {
            DockerRmi(context, new string[] { image }, settings);
        }
        /// <summary>
        /// Removes an array of <paramref name="images"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="images"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
		public static void DockerRmi(this ICakeContext context, string[] images, DockerRmiSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (images == null || images.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }
            var runner = new GenericDockerRunner<DockerRmiSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("rmi", settings ?? new DockerRmiSettings(), images);
        }
    }
}
