using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with logs command.
    partial class DockerAliases
    {
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerLogs(this ICakeContext context, params string[] containers)
        {
            DockerLogs(context, new DockerLogsSettings(), containers);
        }
        
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
		public static void DockerLogs(this ICakeContext context, DockerLogsSettings settings, params string[] containers)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }

            var runner = new GenericDockerRunner<DockerLogsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("logs", settings ?? new DockerLogsSettings(), containers);
        }
    }
}
