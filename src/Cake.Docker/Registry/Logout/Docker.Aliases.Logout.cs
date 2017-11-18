using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with logout command.
    partial class DockerAliases
    {
        /// <summary>
        /// Logout from a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The server.</param>
        [CakeMethodAlias]
        public static void DockerLogout(this ICakeContext context, string server = null)
        {
            var runner = new GenericDockerRunner<DockerRegistryLoginSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("logout", null, server != null ? new[] { server } : null);
        }
    }
}
