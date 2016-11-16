using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose run command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose run with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerComposeRun(this ICakeContext context, string path, string command, params string[] args)
        {
            DockerComposeRun(context, new DockerComposeRunSettings(), path, command, args);
        }

        /// <summary>
        /// Runs docker-compose run given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// /// <param name="command">The command.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRun(this ICakeContext context, DockerComposeRunSettings settings, string path, string command, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerComposeRunner<DockerComposeRunSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string>();
            arguments.Add(path);
            if (command != null)
            {
                arguments.Add(command);
            }
            if (args != null)
            {
                arguments.AddRange(args);
            }
            runner.Run("run", settings ?? new DockerComposeRunSettings(), arguments.ToArray());
        }

    }
}
