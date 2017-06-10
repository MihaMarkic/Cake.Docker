using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with start command.
    partial class DockerAliases
    {
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerStart(this ICakeContext context, params string[] containers)
        {
            DockerStart(context, new DockerStartSettings(), containers);
        }
        
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
		public static void DockerStart(this ICakeContext context, DockerStartSettings settings, params string[] containers)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }

            var runner = new GenericDockerRunner<DockerStartSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("start", settings ?? new DockerStartSettings(), containers);
        }
    }
}
