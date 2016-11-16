using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with stop command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerStop(this ICakeContext context, params string[] containers)
        {
            DockerStop(context, new DockerStopSettings(), containers);
        }
        
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
		public static void DockerStop(this ICakeContext context, DockerStopSettings settings, params string[] containers)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }
            var runner = new GenericDockerRunner<DockerStopSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("stop", settings ?? new DockerStopSettings(), containers);
        }
    }
}
