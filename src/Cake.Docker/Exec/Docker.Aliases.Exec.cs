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
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            DockerExec(context, new DockerExecSettings(), container, command, args);
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
		public static void DockerExec(this ICakeContext context, DockerExecSettings settings, string container, string command, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentNullException("container");
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            var runner = new GenericDockerRunner<DockerExecSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { container, command };
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("exec", settings ?? new DockerExecSettings(), arguments.ToArray());
        }
    }
}
