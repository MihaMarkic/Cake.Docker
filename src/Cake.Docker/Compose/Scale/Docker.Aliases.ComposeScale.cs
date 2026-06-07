using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker-compose scale command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose scale with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="services">The list of services.</param>
        [CakeMethodAlias]
        public static void DockerComposeScale(this ICakeContext context, params string[] services)
        {
            DockerComposeScale(context, new DockerComposeScaleSettings(), null, services);
        }
        /// <summary>
        /// Runs docker-compose scale.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="services">The list of services.</param>
        /// <param name="composeSettings">The compose settings.</param>
        [CakeMethodAlias]
        public static void DockerComposeScale(this ICakeContext context, DockerComposeScaleSettings? settings,
            DockerComposeSettings? composeSettings = null,
            params string[] services)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerComposeScaleSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(
                "compose", composeSettings ?? new(),
                "scale", settings ?? new(), services);
        }
    }
}