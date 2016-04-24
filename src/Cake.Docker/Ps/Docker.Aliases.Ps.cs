using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Lists containers using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static DockerPsResult[] DockerPs(this ICakeContext context)
        {
            return DockerPs(context, new DockerPsSettings());
        }
        /// <summary>
        /// Lists containers using the given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static DockerPsResult[] DockerPs(this ICakeContext context, DockerPsSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerPsSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            return runner.RunWithResult("ps", settings ?? new DockerPsSettings(), Processor);
        }

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
