#addin "Cake.FileHelpers"

var TARGET = Argument ("target", "d);

var version = EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? Argument("version", "0.0.9999");

Task ("Default").Does (() =>
{
	NuGetRestore ("./Cake.AppVeyor.sln");

	DotNetBuild ("./Cake.AppVeyor.sln", c => c.Configuration = "Release");
});

Task ("NuGetPack")
	.IsDependentOn ("Default")
	.Does (() =>
{
	NuGetPack ("./Cake.AppVeyor.nuspec", new NuGetPackSettings { 
		Version = version,
		Verbosity = NuGetVerbosity.Detailed,
		OutputDirectory = "./",
		BasePath = "./",
	});	
});

Task ("InjectKeys").Does (() =>
{
	// Get the API Key from the Environment variable
	var breweryDbApiKey = EnvironmentVariable ("APPVEYOR_APITOKEN") ?? "";

	// Replace the placeholder in our Keys.cs files
	ReplaceTextInFiles ("./**/Keys.cs", "{APPVEYOR_APITOKEN}", breweryDbApiKey);
});

RunTarget (TARGET);
