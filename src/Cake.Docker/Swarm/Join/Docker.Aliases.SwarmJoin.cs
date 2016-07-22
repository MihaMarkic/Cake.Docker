using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// DockerSwarmJoin alias.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Joins a swarm using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerSwarmJoin(this ICakeContext context, params string[] args)
        {
            DockerSwarmJoin(context, new DockerSwarmJoinSettings(), args);
        }

        /// <summary>
        /// Joins a swarm given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerSwarmJoin(this ICakeContext context, DockerSwarmJoinSettings settings, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerSwarmJoinSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> ();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("swarm join", settings ?? new DockerSwarmJoinSettings(), arguments.ToArray());
        }

    }
}
