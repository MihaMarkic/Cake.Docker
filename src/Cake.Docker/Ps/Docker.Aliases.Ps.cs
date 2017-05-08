using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with ps command.
    partial class DockerAliases
    {
        /// <summary>
        /// Lists containers using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Results")]
        public static DockerPsResult[] DockerPs(this ICakeContext context)
        {
            return DockerPs(context, new DockerPsSettings());
        }
        /// <summary>
        /// Lists containers using the given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Results")]
        public static DockerPsResult[] DockerPs(this ICakeContext context, DockerPsSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerPsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("ps", settings ?? new DockerPsSettings(), Processor);
        }

        /// <summary>
        /// Processed the output.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>An array of <see cref="DockerPsResult"/> results.</returns>
        public static DockerPsResult[] Processor(IEnumerable<string> input)
        {
            string[] lines = input.ToArray();
            if (lines.Length > 1)
            {
                var indexes = DockerPsParser.Indexes.CreateFromFirstLine(lines[0]);
                return lines.Skip(1).Select(l => DockerPsParser.ParseLine(indexes, l)).ToArray();
            }
            return new DockerPsResult[0];
        } 
    }
}
