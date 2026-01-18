using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker container ls command.
    partial class DockerAliases
    {

        /// <summary>
        /// List containers given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerContainerLs(this ICakeContext context, DockerContainerLsSettings? settings)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerContainerLsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("container ls", settings ?? new DockerContainerLsSettings(), r => r.ToArray());
        }
    }
}
