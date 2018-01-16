using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Linq;
using System.Collections.Generic;

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
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

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
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
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

            return runner.RunWithResult(commandName, settings, r => r.ToArray(), new[] { commandArguments });
        }
    }
}
