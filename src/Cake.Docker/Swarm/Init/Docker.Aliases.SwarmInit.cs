using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    // Contains functionality for working with swarm init command.
    partial class DockerAliases
    {

        /// <summary>
        /// Initializes a swarm using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerSwarmInit(this ICakeContext context, params string[] args)
        {
            DockerSwarmInit(context, new DockerSwarmInitSettings(), args);
        }

        /// <summary>
        /// Initializes a swarm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerSwarmInit(this ICakeContext context, DockerSwarmInitSettings? settings, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerSwarmInitSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string>();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("swarm init", settings ?? new DockerSwarmInitSettings(), arguments.ToArray());
        }
    }
}
