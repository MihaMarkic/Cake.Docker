using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker image prune command.
    partial class DockerAliases
    {
        /// <summary>
        /// Remove unused images.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerImagePrune(this ICakeContext context)
        {
            return DockerImagePrune(context, new DockerImagePruneSettings());
        }

        /// <summary>
        /// Remove unused images given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerImagePrune(this ICakeContext context, DockerImagePruneSettings? settings)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerImagePruneSettings>(context.FileSystem,
                context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("image prune", settings ?? new DockerImagePruneSettings(), r => r.ToArray());
        }
    }
}
