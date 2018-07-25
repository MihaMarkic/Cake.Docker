var Project = Directory("./Cake.Docker/");
var TestProject = Directory("./Cake.Docker.Tests/");
var CakeDockerProj = Project + File("Cake.Docker.csproj");
var CakeTestDockerProj = TestProject + File("Cake.Docker.Tests.csproj");
var CakeTestDockerAssembly = TestProject + Directory("bin/Release/netcoreapp2.0") + File("Cake.Docker.Tests.dll");
var AssemblyInfo = Project + File("Properties/AssemblyInfo.cs");
var CakeDockerSln = File("./Cake.Docker.sln");
var CakeDockerNuspec = File("./Cake.Docker.nuspec");
var Nupkg = Directory("./nupkg");

var target = Argument("target", "Default");

Task("Default")
	.Does (() =>
	{
		NuGetRestore (CakeDockerSln);
		DotNetCoreBuild (CakeDockerSln, new DotNetCoreBuildSettings {
			Configuration = "Release"
		});
});

Task("UnitTest")
	.IsDependentOn("Default")
	.Does(() =>
	{
		var settings = new DotNetCoreTestSettings
		 {
			 Configuration = "Release"
		 };
		DotNetCoreTest(CakeTestDockerProj, settings);
	});

Task("NuGetPack")
	.IsDependentOn("Default")
	.IsDependentOn("UnitTest")
	.Does (() =>
{
	CreateDirectory(Nupkg);
	DotNetCorePack (CakeDockerProj, new DotNetCorePackSettings
     {
         Configuration = "Release",
         OutputDirectory = "./nupkg/"
     });
});

RunTarget (target);
