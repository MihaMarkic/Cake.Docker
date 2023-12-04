using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for running any custom command which are not yet implemented.
    partial class DockerAliases
    {
        /// <summary>
        /// Run a custom docker command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command">The custom command.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerCustomCommand(this ICakeContext context, string command)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));

            return DockerCustomCommand(context, new DockerCustomCommandSettings(), command);
        }

        /// <summary>
        /// Run a custom docker command
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="command">The custom command.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerCustomCommand(this ICakeContext context, DockerCustomCommandSettings settings, string command)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            ArgumentNullException.ThrowIfNull(nameof(settings));
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }


            var runner = new GenericDockerRunner<DockerCustomCommandSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);

            string commandName = command;
            string commandArguments = "";

            var space = command.IndexOf(" ");
            if (space > -1)
            {
                commandName = command.Substring(0, space);
                commandArguments = command.Substring(space);
            }

            return runner.RunWithResult(commandName, settings, r => r.ToArray(), [commandArguments]);
        }
    }
}
