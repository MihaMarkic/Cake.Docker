﻿using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose run command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose run with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The path.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerComposeRun(this ICakeContext context, string service, params string[] args)
        {
            DockerComposeRun(context, new DockerComposeRunSettings(), service, null, args);
        }
        /// <summary>
        /// Runs docker-compose run with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The path.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerComposeRun(this ICakeContext context, string service, string command, params string[] args)
        {
            DockerComposeRun(context, new DockerComposeRunSettings(), service, command, args);
        }

        /// <summary>
        /// Runs docker-compose run given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The path.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRun(this ICakeContext context, DockerComposeRunSettings settings, string service, params string[] args)
        {
            DockerComposeRun(context, settings, service, command: null, args: args);
        }

        /// <summary>
        /// Runs docker-compose run given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The path.</param>
        /// /// <param name="command">The command.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeRun(this ICakeContext context, DockerComposeRunSettings settings, string service, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(service))
            {
                throw new ArgumentNullException(nameof(service));
            }
            var runner = new GenericDockerComposeRunner<DockerComposeRunSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string>();
            arguments.Add(service);
            if (command != null)
            {
                arguments.Add(command);
            }
            arguments.AddRange(args);
            runner.Run("run", settings ?? new DockerComposeRunSettings(), arguments.ToArray());
        }

    }
}
