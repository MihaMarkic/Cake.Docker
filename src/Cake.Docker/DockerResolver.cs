using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core.Tooling;

namespace Cake.Docker
{
    internal static class DockerResolver
    {
        public static FilePath GetDockerPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException("fileSystem");
            }

            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            // Cake already searches the PATH for the executable tool names.
            // Check for other known locations.
            return !environment.Platform.IsUnix() 
                ? CheckCommonWindowsPaths(fileSystem)
                : null;
        }

        /// <summary>
        /// Check common docker client locations.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <returns></returns>
        private static FilePath CheckCommonWindowsPaths(IFileSystem fileSystem)
        {
            // The docker client is included as part of the Docker Toolbox installer 
            // or can be installed using a Chocolatey package (name: docker).
            // The Chocolatey install does not have a fixed location, but Docker Toolbox does.
            return GetDefaultWindowsPaths(fileSystem)
                .Select(path => path.CombineWithFilePath("docker.exe"))
                .FirstOrDefault(dockerExecutable => fileSystem.GetFile(dockerExecutable).Exists);
        }

        /// <summary>
        /// Get default paths for common docker client installations.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <returns></returns>
        private static DirectoryPath[] GetDefaultWindowsPaths(IFileSystem fileSystem)
        {
            var paths = new List<DirectoryPath>();

            var programFiles = new DirectoryPath(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            var defaultDockerToolboxPath = programFiles.Combine("Docker Toolbox");
            if (fileSystem.GetDirectory(defaultDockerToolboxPath).Exists)
            {
                paths.Add(defaultDockerToolboxPath);
            }

            return paths.ToArray();
        }
    }
}
