using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with load command.
    partial class DockerAliases
    {
        /// <summary>
        /// Load an image from a tar archive or STDIN.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerLoad(this ICakeContext context, DockerImageLoadSettings? settings)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerImageLoadSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("load", settings ?? new DockerImageLoadSettings(), Array.Empty<string>());
        }
    }
}
