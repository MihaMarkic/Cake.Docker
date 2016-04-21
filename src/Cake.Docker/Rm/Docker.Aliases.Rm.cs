using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Removes an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="containers"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerRm(this ICakeContext context, params string[] containers)
        {
            DockerRm(context, new DockerRmSettings(), containers);
        }
        
        
        /// <summary>
        /// Removes an array of <paramref name="containers"/> using the given <param name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="containers"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
		public static void DockerRm(this ICakeContext context, DockerRmSettings settings, params string[] containers)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }
            var runner = new GenericDockerRunner<DockerRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("rm", settings ?? new DockerRmSettings(), containers);
        }
    }
}
