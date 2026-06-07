using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    // Contains functionality for working with exec command.
    partial class DockerAliases
    {
        /// <summary>
        /// Execs a command using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="container">The container</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerExec(this ICakeContext context, string container, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            DockerExec(context, new DockerContainerExecSettings(), container, command, args);
        }
        /// <summary>
        /// Execs a command using given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="container">The container</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerExec(this ICakeContext context, DockerContainerExecSettings? settings, string container, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentNullException(nameof(container));
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            var runner = new GenericDockerRunner<DockerContainerExecSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { container, command };
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("exec", settings ?? new DockerContainerExecSettings(), arguments.ToArray());
        }
    }
}
