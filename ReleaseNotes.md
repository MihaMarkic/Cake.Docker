# Cake.Docker 0.4.0
- Added support for using the package on Linux machines.
- Added [DockerLogin](https://docs.docker.com/engine/reference/commandline/login/)
- Added [DockerPush](https://docs.docker.com/engine/reference/commandline/push/)
- Added [DockerTag](https://docs.docker.com/engine/reference/commandline/tag/)

# Cake.Docker 0.3.0
- Added [DockerPs](https://docs.docker.com/engine/reference/commandline/ps/)
    - ports aren't included, size is approximate, created date is in text format, exited data is not included
- Bug fixes

# Cake.Docker 0.2.0
- Added [DockerCp](https://docs.docker.com/engine/reference/commandline/cp/) and [DockerCreate](https://docs.docker.com/engine/reference/commandline/create/)
- Implemented all DockerBuild arguments
- **[Breaking]** Rearranged arguments for DockerRm, DockerRmi and DockerStop.
Settings are first, and one or more container|images are last.
This is to avoid using of new string[]{} when passing more than one item.
- Bug fixes

# Cake.Docker 0.1.1
- Fixed NuGet package

# Cake.Docker 0.1.0
Cake AddIn that extends Cake with Docker command tools.