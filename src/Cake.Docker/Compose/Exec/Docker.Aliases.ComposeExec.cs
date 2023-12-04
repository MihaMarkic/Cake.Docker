using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose exec command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose exec with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The service.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerComposeExec(this ICakeContext context, string service, string command, params string[] args)
        {
            DockerComposeExec(context, new DockerComposeExecSettings(), service, command, args);
        }

        /// <summary>
        /// Runs docker-compose exec given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The service.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeExec(this ICakeContext context, DockerComposeExecSettings settings, string service, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            if (string.IsNullOrEmpty(service))
            {
                throw new ArgumentNullException(nameof(service));
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }

            var runner = new GenericDockerComposeRunner<DockerComposeExecSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);

            var arguments = new List<string> { service, command };

            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }

            runner.Run("exec", settings ?? new DockerComposeExecSettings(), arguments.ToArray());
        }
    }
}
