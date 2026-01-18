using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx version command.
    partial class DockerAliases
    {
        /// <summary>
        /// List images given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerBuildXVersion(this ICakeContext context, DockerBuildXVersionSettings? settings = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXVersionSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("buildx version", settings ?? new DockerBuildXVersionSettings(), r => r.ToArray());
        }
    }
}
