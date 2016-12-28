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