using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Copy files from/to container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerCp(this ICakeContext context, string path, DockerCpSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            var runner = new GenericDockerRunner<DockerCpSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("cp", settings ?? new DockerCpSettings(), new string[] { path });
        }

    }
}
