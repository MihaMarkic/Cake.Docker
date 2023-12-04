using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose ps command.
    public partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose ps with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposePs(this ICakeContext context, params string[] services) =>
            DockerComposePs(context, new DockerComposePsSettings(), services);

        /// <summary>
        /// Runs docker-compose ps.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerComposePs(this ICakeContext context, DockerComposePsSettings settings, params string[] services)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerComposeRunner<DockerComposePsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            var result = runner.RunWithResult("ps", settings ?? new DockerComposePsSettings(), r => r.ToArray(), services);
            return result;
        }
    }
}