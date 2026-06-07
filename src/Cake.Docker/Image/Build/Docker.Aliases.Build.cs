using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with build command.
    partial class DockerAliases
    {
        /// <summary>
        /// Builds an image using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        [CakeMethodAlias]
        public static void DockerBuild(this ICakeContext context, string path)
        {
            DockerBuild(context, new DockerImageBuildSettings(), path);
        }

        /// <summary>
        /// Builds an image given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="path">The path.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuild(this ICakeContext context, DockerImageBuildSettings? settings, string path)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            var runner = new GenericDockerRunner<DockerImageBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            // quote path if not already quoted
            string quotedPath;
            if (!string.IsNullOrEmpty(path))
            {
                string trimmed = path.Trim();
                if (trimmed.Length > 1 && trimmed.StartsWith('"') && trimmed.EndsWith('"'))
                {
                    quotedPath = path;
                }
                else
                {
                    quotedPath = $"\"{path}\"";
                }
            }
            else
            {
                quotedPath = path;
            }
            runner.Run("image build", settings ?? new DockerImageBuildSettings(), new[] { quotedPath });
        }

    }
}
