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
        /// Copy files from/to using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command"></param>
        /// <param name="container">exec a command inside the container</param>
        /// <param name="env">Set environment variables</param>
        /// <param name="interactive">Keep STDIN open even if not attached</param>
        /// <param name="privileged">Give extended privileges to the command</param>
        /// <param name="tty">Allocate a pseudo-TTY</param>
        /// <param name="user">Username or UID (format: name or uid : group or gid ])</param>
        [CakeMethodAlias]
        public static void DockerExec(this ICakeContext context,
                                      string command,
                                      string container,
                                      string env = "",
                                      bool interactive = false,
                                      bool privileged = false,
                                      bool tty = false,
                                      string user = "")
        {
            DockerExec(context, command, container, new DockerExecSettings(), env, interactive, privileged, tty, user);
        }
        /// <summary>
        /// Copy files from/to container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command"></param>
        /// <param name="container"></param>
        /// <param name="env">Set environment variables</param>
        /// <param name="interactive">Keep STDIN open even if not attached</param>
        /// <param name="privileged">Give extended privileges to the command</param>
        /// <param name="tty">Allocate a pseudo-TTY</param>
        /// <param name="user">Username or UID (format: name or uid : group or gid ])</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerExec(this ICakeContext context,
                                      string command,
                                      string container,
                                      DockerExecSettings settings,
                                      string env = "",
                                      bool interactive = false,
                                      bool privileged = false,
                                      bool tty = false,
                                      string user = "")
        {
            string exec = "exec";

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            if (string.IsNullOrWhiteSpace(container))
            {
                throw new ArgumentNullException("container");
            }

            if (interactive)
            {
                exec = "exec -i";
            }
            if (privileged)
            {
                exec += " --privileged";
            }
            if (tty)
            {
                exec += " -t";
            }
            if (string.IsNullOrWhiteSpace(env))
            {
                exec += " -e " + env;
            }
            if (string.IsNullOrWhiteSpace(user))
            {
                exec += " -u " + user;
            }

            var runner = new GenericDockerRunner<DockerExecSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(exec, settings ?? new DockerExecSettings(), new string[] { container, command });
        }

    }
}
