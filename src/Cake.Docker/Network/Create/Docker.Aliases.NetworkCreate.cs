using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// DockerNetworkCreate alias.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Crates a network using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerNetworkCreate(this ICakeContext context, params string[] args)
        {
            DockerNetworkCreate(context, new DockerNetworkCreateSettings(), args);
        }

        /// <summary>
        /// Crates a network given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerNetworkCreate(this ICakeContext context, DockerNetworkCreateSettings settings, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerNetworkCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> ();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network create", settings ?? new DockerNetworkCreateSettings(), arguments.ToArray());
        }
    }
}
