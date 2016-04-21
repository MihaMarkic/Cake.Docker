using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Copy files from/to using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerCp(this ICakeContext context, string from, string to)
        {
            DockerCp(context, from, to, new DockerCpSettings());
        }
        /// <summary>
        /// Copy files from/to container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerCp(this ICakeContext context, string from, string to, DockerCpSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException("path");
            }
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException("to");
            }
            var runner = new GenericDockerRunner<DockerCpSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("cp", settings ?? new DockerCpSettings(), new string[] { from, to });
        }

    }
}
