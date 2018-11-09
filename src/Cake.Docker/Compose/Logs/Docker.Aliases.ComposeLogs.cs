using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose down command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose kill with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerComposeLogs(this ICakeContext context)
        {
            DockerComposeLogs(context, new DockerComposeLogsSettings());
        }

        /// <summary>
        /// Runs docker-compose kill given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeLogs(this ICakeContext context, DockerComposeLogsSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeLogsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("logs", settings ?? new DockerComposeLogsSettings(), new string[0]);
        }

    }
}
