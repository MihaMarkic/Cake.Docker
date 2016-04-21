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
        public static void DockerRmi(this ICakeContext context, params string[] images)
        {
            DockerRmi(context, new DockerRmiSettings(), images);
        }
        
        /// <summary>
        /// Removes an array of <paramref name="images"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="images"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
		public static void DockerRmi(this ICakeContext context, DockerRmiSettings settings, params string[] images)
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
