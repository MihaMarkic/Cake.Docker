using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with ps command.
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
        public static string DockerPs(this ICakeContext context, DockerContainerPsSettings? settings)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerContainerPsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            var result = runner.RunWithResult("ps", settings ?? new DockerContainerPsSettings(), r => r.ToArray());
            return string.Join("\n", result);
        }
    }
}
