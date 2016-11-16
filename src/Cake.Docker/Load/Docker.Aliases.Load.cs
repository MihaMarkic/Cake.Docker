using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with load command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Load an image from a tar archive or STDIN.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
		public static void DockerLoad(this ICakeContext context, DockerLoadSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerLoadSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("load", settings ?? new DockerLoadSettings(), new string[0]);
        }
    }
}
