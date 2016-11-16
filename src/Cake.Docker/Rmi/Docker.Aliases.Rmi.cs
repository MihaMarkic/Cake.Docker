using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with rmi command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Removes an array of <paramref name="images"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="images">The list of images.</param>
        [CakeMethodAlias]
        public static void DockerRmi(this ICakeContext context, params string[] images)
        {
            DockerRmi(context, new DockerRmiSettings(), images);
        }
        
        /// <summary>
        /// Removes an array of <paramref name="images"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="images">The list of images.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerRmi(this ICakeContext context, DockerRmiSettings settings, params string[] images)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (images == null || images.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }
            var runner = new GenericDockerRunner<DockerRmiSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("rmi", settings ?? new DockerRmiSettings(), images);
        }
    }
}
