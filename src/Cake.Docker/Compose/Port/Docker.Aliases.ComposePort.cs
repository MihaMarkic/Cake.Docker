using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose port command.
    public partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose port with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="service">The service.</param>
        /// <param name="port">The private port of the container.</param>
        [CakeMethodAlias]
        public static void DockerComposePort(this ICakeContext context, string service, int port) => 
            DockerComposePort(context, new DockerComposePortSettings(), service, port);

        /// <summary>
        /// Runs docker-compose port.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="service">The service.</param>
        /// <param name="port">The private port of the container.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerComposePort(this ICakeContext context, DockerComposePortSettings settings, string service, int port)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }
            var runner = new GenericDockerComposeRunner<DockerComposePortSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            var arguments = new List<string> { service, port.ToString() };
            return runner.RunWithResult("port", settings ?? new DockerComposePortSettings(), r => r.ToArray(), arguments.ToArray());
        }
    }
}