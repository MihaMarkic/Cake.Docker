using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose logs command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose logs with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerComposeLogs(this ICakeContext context)
        {
            return DockerComposeLogs(context, new DockerComposeLogsSettings());
        }

        /// <summary>
        /// Runs docker-compose logs given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerComposeLogs(this ICakeContext context, DockerComposeLogsSettings settings)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerComposeRunner<DockerComposeLogsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("logs", settings ?? new DockerComposeLogsSettings(), r => r.ToArray());
        }

    }
}
