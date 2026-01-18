using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with rm command.
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
            DockerRm(context, new DockerContainerRmSettings(), containers);
        }


        /// <summary>
        /// Removes an array of <paramref name="containers"/> using the given <param name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerRm(this ICakeContext context, DockerContainerRmSettings? settings, params string[] containers)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException(nameof(containers));
            }
            var runner = new GenericDockerRunner<DockerContainerRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("rm", settings ?? new DockerContainerRmSettings(), containers);
        }
    }
}
