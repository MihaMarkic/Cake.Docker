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
        public static void DockerRm(this ICakeContext context, string[] containers)
        {
            DockerRm(context, containers, new DockerRmSettings());
        }
        /// <summary>
        /// Removes a <paramref name="container"/> using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="container"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerRm(this ICakeContext context, string container)
        {
            DockerRm(context, new string[] { container });
        }
        /// <summary>
        /// Removes a <paramref name="container"/> using the given <param name="settings" />.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="container"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerRm(this ICakeContext context, string container, DockerRmSettings settings)
        {
            DockerRm(context, new string[] { container }, settings);
        }
        /// <summary>
        /// Removes an array of <paramref name="containers"/> using the given <param name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="containers"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
		public static void DockerRm(this ICakeContext context, string[] containers, DockerRmSettings settings)
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
