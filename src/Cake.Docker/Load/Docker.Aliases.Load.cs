using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Load an image from a tar archive or STDIN.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
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
