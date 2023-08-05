# Cake.Docker TBD

* Updated Compose Up settings
* `DockerComposeUpSettings.DetachedMode` is renamed to `Detached`.

# Cake.Docker 1.2.0

* Drops support for .NET Core. Only .NET 6.0+ is supported (thanks [Toni Wenzel](https://github.com/twenzel))
* Bumps Cake reference to 3.0.0 (thanks [Toni Wenzel](https://github.com/twenzel))
* Add --progress arguement to DockerImageBuildSettings (thanks [Chris Blyth](https://github.com/BlythMeister))
# Cake.Docker 1.1.0

* Adds docker image prune
* Adds version to assemblies
* Updates icon
* Adds buildx commands
* Adds .NET5, .NET6 and .NETCore 3.1 targets, drops .netstandard2
* DockerComposeLogs is not returning any value bug 
* Adds --all-tags argument to DockerPush

# Cake.Docker 1.0.0

* Bumps Cake reference to 1.0.0 #85 (thanks [Sean Fausett](https://github.com/gitfool))
* Adds docker-compuse push commands PR#81 (thanks [eoehen](https://github.com/eoehen))
* Uses docker-compose on unix systems and docker-compose.exe binary on Windows #83 (thanks [Thomas Harold](https://github.com/tgharold))

# Cake.Docker 0.11.1

- Adds 'image ls' command
- Adds 'container ls' command
- Uses docker on unix systems and docker.exe binary on Windows (fixes problem when running on Windows with WSL enabled)

# Cake.Docker 0.11.0

- Adds support for experimental docker commands
- Adds `docker manifest` commands
- Fixes XML documentation

# Cake.Docker 0.10.1

- Adds docker-compose port and ps commands #68
- docker-compose run - unable to provide volumes #70

# Cake.Docker 0.10.0

* Bumps Cake reference to 0.33
* (POTENTIAL) BREAKING CHANGE: Image Build path is now quoted if not quoted originally
* Adds docker volume support

# Cake.Docker 0.9.9

* Reintroduces DockerPs again
* Corrects DockerComposeRunSettings.Entrypoint type from bool to string
# Cake.Docker 0.9.8

* Adds --quiet, --no-parallel and --include-deps to docker-compose pull
* Adds --parallel to docker-compose build

# Cake.Docker 0.9.7

* DockerComposeBuildSettings BuildArg should be string array instead of bool
* Implements docker-compose logs
* DockerRun doesn't return internal commandline output after upgrading to 0.9.5
* DockerComposeUpSettings does not support --scale option properly
* 'Rm' and 'ForceRM' settings in DockerImageBuildSettings are not applied correctly

# Cake.Docker 0.9.6

* Bugfix #45 DockerComposeDownSettings doesn't support Rmi flag properly

# Cake.Docker 0.9.5

* Fixes/enhancements for:
  *  [Return container id on DockerRun #42](https://github.com/MihaMarkic/Cake.Docker/issues/42)
  *  [Lack of support of -T flag for DockerComposeExec #43](https://github.com/MihaMarkic/Cake.Docker/issues/43) 
  *  [Pre-command arguments are also inserted as post-command arguments #44](https://github.com/MihaMarkic/Cake.Docker/issues/44) 

# Cake.Docker 0.9.4

* DockerCreate returns container id
* References Cake 0.28

# Cake.Docker 0.9.3

* Changes memory arguments from UInt64 to string

# Cake.Docker 0.9.2

* Adds docker-compose exec command
* Fixes docker-compose --exit-code-from argument

# Cake.Docker 0.9.1

A refresh against current Docker Cli sources.

Adds these arguments:

- Container: Create, Run (Platform)
- Container: Exec (Workdir)
- Container: Logs (Until)
- Image: Build, Pull (Platform)

# Cake.Docker 0.9.0

* BREAKING: References Cake 0.26 (and goes .NET Standard 2.0 only)

# Cake.Docker 0.8.5

* Fixes Log command, now it is returning log
* Log command was using wrong verb
* Fixes Logout and Login arguments passing

# Cake.Docker 0.8.4

* Addes DockerCustomCommand

# Cake.Docker 0.8.3

* Added DockerLogout
* Refactors arguments handling to support hiding password values

# Cake.Docker 0.8.2

- References Cake 0.22 (**breaking**)
- Added [DockerStart](https://docs.docker.com/engine/reference/commandline/start/)
- Added [DockerLogs](https://docs.docker.com/engine/reference/commandline/logs/)

# Cake.Docker 0.8.0

- Docker 17.* is supported since v0.8 and background compatibility is dropped (most notably, array arguments are converter to strings). If you wish to match older docker versions, user an older Cake.Docker version.
- Added DockerExec command
- Added [DockerExec](https://docs.docker.com/engine/reference/commandline/exec/) 
- **BREAKING** Starting with 0.8.0 command's setting types that haven't been composed of all words have changed to full name. i.e. DockerBuildSettings to DockerImageBuildSettings). 

# Cake.Docker 0.7.7

- .NET Core support
# Cake.Docker 0.7.6
- Documentation improvements
# Cake.Docker 0.7.5
- Fixed Nuget package (cake.core was set as 0.10.1)
# Cake.Docker 0.7.4
- Fixed very minor consistency bug in DockerPs (thanks to WrathZA)
# Cake.Docker 0.7.3
- Fixed DockerComposeSettings.ProjectName to string (thanks to Symbianx)
# Cake.Docker 0.7.2
- Added [DockerRun](https://docs.docker.com/engine/reference/commandline/run/)
# Cake.Docker 0.7.1
- Added [DockerPull](https://docs.docker.com/engine/reference/commandline/pull/)
# Cake.Docker 0.7.0
- This release is about adding docker-compose commands
- Added [DockerComposeBuild](https://docs.docker.com/compose/reference/build/)
- Added [DockerComposeCreate](https://docs.docker.com/compose/reference/create/)
- Added [DockerComposeDown](https://docs.docker.com/compose/reference/down/)
- Added [DockerComposeKill](https://docs.docker.com/compose/reference/kill/)
- Added [DockerComposePause](https://docs.docker.com/compose/reference/pause/)
- Added [DockerComposePull](https://docs.docker.com/compose/reference/pull/)
- Added [DockerComposeRestart](https://docs.docker.com/compose/reference/restart/)
- Added [DockerComposeRm](https://docs.docker.com/compose/reference/rm/)
- Added [DockerComposeRun](https://docs.docker.com/compose/reference/run/)
- Added [DockerComposeScale](https://docs.docker.com/compose/reference/scale/)
- Added [DockerComposeStart](https://docs.docker.com/compose/reference/start/)
- Added [DockerComposeStop](https://docs.docker.com/compose/reference/stop/)
- Added [DockerComposeUnpause](https://docs.docker.com/compose/reference/unpause/)
- Added [DockerComposeUp](https://docs.docker.com/compose/reference/up/)
- Updated documentation

# Cake.Docker 0.6.0
- Fixed a bug in DockerStop (it'd accept DockerBuildSettings)
- Added [DockerLoad](https://docs.docker.com/engine/reference/commandline/load/)
- Added [DockerSave](https://docs.docker.com/engine/reference/commandline/save/)

# Cake.Docker 0.5.0
- WARNING: Updated passing parameter values. Equality '=' is replaced with a space ' '.
- Added [DockerNetworkCreate](https://docs.docker.com/engine/reference/commandline/network_create/) v0.5.0
- Added [DockerNetworkConnect](https://docs.docker.com/engine/reference/commandline/network_connect/) v0.5.0
- Added [DockerNetworkDisconnect](https://docs.docker.com/engine/reference/commandline/network_disconnect/) v0.5.0
- Added [DockerNetworkRm](https://docs.docker.com/engine/reference/commandline/network_rm/) v0.5.0
- Added [DockerSwarmInit](https://docs.docker.com/engine/reference/commandline/swarm_init/) v0.5.0
- Added [DockerSwarmJoin](https://docs.docker.com/engine/reference/commandline/swarm_join/) v0.5.0
- Added [DockerSwarmLeave](https://docs.docker.com/engine/reference/commandline/swarm_leave/) v0.5.0
- Added [DockerSwarmUpdate](https://docs.docker.com/engine/reference/commandline/swarm_update/) v0.5.0

# Cake.Docker 0.4.0
- Added support for using the package on Linux machines (thanks to pvwichen).
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
