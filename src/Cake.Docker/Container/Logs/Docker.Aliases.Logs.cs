using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Logs <paramref name="container"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="container">The list of containers.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerLogs(this ICakeContext context, string container)
        {
            return DockerLogs(context, new DockerContainerLogsSettings(), container);
        }

        /// <summary>
        /// Logs <paramref name="container"/> using the given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="container">The list of containers.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerLogs(this ICakeContext context, DockerContainerLogsSettings? settings, string container)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(container);
            var runner = new GenericDockerRunner<DockerContainerLogsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("logs", settings ?? new DockerContainerLogsSettings(), r => r.ToArray(), container);
        }
    }
}
