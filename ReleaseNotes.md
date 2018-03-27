#Cake.Docker 0.9.1

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