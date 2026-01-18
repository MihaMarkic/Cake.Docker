using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    // Contains functionality for working with swarm update command.
    partial class DockerAliases
    {
        /// <summary>
        /// Updates a swarm using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerSwarmUpdate(this ICakeContext context, params string[] args)
        {
            DockerSwarmUpdate(context, new DockerSwarmUpdateSettings(), args);
        }

        /// <summary>
        /// Updates a swarm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerSwarmUpdate(this ICakeContext context, DockerSwarmUpdateSettings? settings, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerSwarmUpdateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string>();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("swarm update", settings ?? new DockerSwarmUpdateSettings(), arguments.ToArray());
        }

    }
}
