using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    /// <summary>
    /// DockerNetworkRemove alias.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Removes a network.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="network"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerNetworkRemove(this ICakeContext context, string network, params string[] args)
        {
            context.DockerNetworkRemove(new string[] { network }, args);
        }
        /// <summary>
        /// Removes networks.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="network"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerNetworkRemove(this ICakeContext context, string[] network, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (network == null || network.Any(n => string.IsNullOrEmpty(n)))
            {
                throw new ArgumentNullException("network");
            }
            var runner = new GenericDockerRunner<EmptySettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> (network);
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network rm", new EmptySettings(), arguments.ToArray());
        }
    }
}
