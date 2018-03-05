var Project = Directory("./Cake.Docker/");
var TestProject = Directory("./Cake.Docker.Tests/");
var CakeDockerProj = Project + File("Cake.Docker.csproj");
var CakeTestDockerProj = TestProject + File("Cake.Docker.Test.csproj");
var CakeTestDockerAssembly = TestProject + Directory("bin/Release") + File("Cake.Docker.Tests.dll");
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
		NUnit3(CakeTestDockerAssembly);
	});

Task("NuGetPack")
	.IsDependentOn("Default")
	.IsDependentOn("UnitTest")
	.Does (() =>
{
	CreateDirectory(Nupkg);
	// DotNetCorePublish (CakeDockerSln, new DotNetCorePublishSettings { 
	// 	Configuration = "Release",
	// 	Framework = "net45;net46;netstandard1.6"
	// 	// BuildBasePath = "./",
	// });	
	DotNetCorePack (CakeDockerProj, new DotNetCorePackSettings
     {
         Configuration = "Release",
         OutputDirectory = "./nupkg/"
     });
});

RunTarget (target);
