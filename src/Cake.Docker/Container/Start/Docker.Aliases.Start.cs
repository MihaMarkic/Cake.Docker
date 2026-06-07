using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Starts an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerStart(this ICakeContext context, params string[] containers)
        {
            DockerStart(context, new DockerContainerStartSettings(), containers);
        }

        /// <summary>
        /// Starts an array of <paramref name="containers"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerStart(this ICakeContext context, DockerContainerStartSettings? settings, params string[] containers)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException(nameof(containers));
            }
            var runner = new GenericDockerRunner<DockerContainerStartSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("start", settings ?? new DockerContainerStartSettings(), containers);
        }
    }
}
