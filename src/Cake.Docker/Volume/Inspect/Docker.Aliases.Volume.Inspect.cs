using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker volume inspect command.
    partial class DockerAliases
    {

        /// <summary>
        /// Display detailed information on one or more volumes given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="volumes">Volumes</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerVolumeInspect(this ICakeContext context, DockerVolumeInspectSettings? settings, string[] volumes)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (volumes == null || volumes.Length < 1)
            {
                throw new ArgumentNullException(nameof(volumes), "At least one volume is required");
            }
            var runner = new GenericDockerRunner<DockerVolumeInspectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("volume inspect", settings ?? new DockerVolumeInspectSettings(), r => r.ToArray(), volumes);
        }
        /// <summary>
        /// Display detailed information on one or more volumes.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="volumes">Volumes</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerVolumeInspect(this ICakeContext context, string[] volumes)
        {
            return context.DockerVolumeInspect(null, volumes);
        }
    }
}
