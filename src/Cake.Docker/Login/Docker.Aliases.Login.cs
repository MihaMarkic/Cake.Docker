using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Register or log in to a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
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

            DockerLogin(context, new DockerLoginSettings {Username = username, Password = password, Email = "none"}, server);
        }

        /// <summary>
        /// Register or log in to a Docker registry.
        /// If no server is specified, the docker engine default is used.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        /// <param name="server"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerLogin(this ICakeContext context, DockerLoginSettings settings, string server = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            var runner = new GenericDockerRunner<DockerLoginSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("login", settings, server != null ? new[] { server } : null);
        }
    }
}
