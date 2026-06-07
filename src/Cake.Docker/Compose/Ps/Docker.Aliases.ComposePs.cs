using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

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
            DockerComposePs(context, new DockerComposePsSettings(), null, services);

        /// <summary>
        /// Runs docker-compose ps.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="composeSettings">The compose settings.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerComposePs(this ICakeContext context, DockerComposePsSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposePsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            var result = runner.RunWithResult(
                "compose", composeSettings ?? new(),
                "ps", settings ?? new(),
                r => r.ToArray(), services);
            return result;
        }
    }
}