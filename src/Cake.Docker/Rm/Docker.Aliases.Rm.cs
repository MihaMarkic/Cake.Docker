using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with rm command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Removes an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerRm(this ICakeContext context, params string[] containers)
        {
            DockerRm(context, new DockerRmSettings(), containers);
        }
        
        
        /// <summary>
        /// Removes an array of <paramref name="containers"/> using the given <param name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
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
