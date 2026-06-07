using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with cp command.
    partial class DockerAliases
    {
        /// <summary>
        /// Copy files from/to using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="from">Source path.</param>
        /// <param name="to">Destination path.</param>
        [CakeMethodAlias]
        public static void DockerCp(this ICakeContext context, string from, string to)
        {
            DockerCp(context, from, to, new DockerContainerCpSettings());
        }
        /// <summary>
        /// Copy files from/to container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="from">Source path.</param>
        /// <param name="to">Destination path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerCp(this ICakeContext context, string from, string to, DockerContainerCpSettings? settings)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(from))
            {
                throw new ArgumentNullException(nameof(from));
            }
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentNullException(nameof(to));
            }
            var runner = new GenericDockerRunner<DockerContainerCpSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("cp", settings ?? new DockerContainerCpSettings(), new[] { from, to });
        }

    }
}
