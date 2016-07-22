using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// DockerCreate alias.
    /// </summary>
    partial class DockerAliases
    {

        /// <summary>
        /// Creates a new container using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerSwarmInit(this ICakeContext context, params string[] args)
        {
            DockerSwarmInit(context, new DockerSwarmInitSettings(), args);
        }

        /// <summary>
        /// Creates a new container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerSwarmInit(this ICakeContext context, DockerSwarmInitSettings settings, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerSwarmInitSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> ();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("create", settings ?? new DockerSwarmInitSettings(), arguments.ToArray());
        }

    }
}
