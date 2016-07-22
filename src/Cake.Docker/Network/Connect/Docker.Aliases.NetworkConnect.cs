using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// DockerNetworkConnect alias.
    /// </summary>
    partial class DockerAliases
    {

        /// <summary>
        /// Connects a container to a network using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerNetworkConnect(this ICakeContext context, string network, string container, params string[] args)
        {
            DockerNetworkConnect(context, new DockerNetworkConnectSettings(), network, container, args);
        }

        /// <summary>
        /// Connects a container to a network given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="args"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerNetworkConnect(this ICakeContext context, DockerNetworkConnectSettings settings, string network, string container, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(network))
            {
                throw new ArgumentNullException("network");
            }
            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentNullException("container");
            }
            var runner = new GenericDockerRunner<DockerNetworkConnectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> { network, container };
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network connect", settings ?? new DockerNetworkConnectSettings(), arguments.ToArray());
        }
    }
}
