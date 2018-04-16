using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with login command.
    partial class DockerAliases
    {
        /// <summary>
        /// Register or log in to a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="server">The server.</param>
        [CakeMethodAlias]
        public static void DockerLogin(this ICakeContext context, string username, string password, string server = null)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            DockerLogin(context, new DockerRegistryLoginSettings { Username = username, Password = password }, server);
        }

        /// <summary>
        /// Register or log in to a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="server">The server.</param>
        [CakeMethodAlias]
        public static void DockerLogin(this ICakeContext context, DockerRegistryLoginSettings settings, string server = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var runner = new GenericDockerRunner<DockerRegistryLoginSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("login", settings, server != null ? new[] { server } : new string[] { });
        }
    }
}
