using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    /// <summary>
    /// Base class for all Docker related tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class DockerComposeTool<TSettings>: Tool<TSettings>
        where TSettings: ToolSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DockerTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        protected DockerComposeTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
            _environment = environment;
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "DockerCompose";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            // In WSL (Windows Subsystem for Linux), both 'docker-compose' and
            // 'docker-compose.exe' are available. The Linux version of docker-compose 
            // must have precedence over the windows version so that the native
            // (i.e. Linux) version of docker-compose is used under WSL.
            if (_environment.Platform.IsUnix())
            {
                return new[] { "docker-compose", "docker-compose.exe" };
            }
            else
            {
                return new[] { "docker-compose.exe", "docker-compose" };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = DockerResolver.GetDockerPath(_fileSystem, _environment);
            return path != null
                ? new[] { path }
                : Enumerable.Empty<FilePath>();
        }
    }
}
