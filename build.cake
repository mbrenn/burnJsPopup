#addin nuget:?package=Cake.Npm&version=4.0.0

var jsInputSrc = new DirectoryPath("src/js");
var jsOutputSrc = new DirectoryPath("build/js");
var webInputSrc = new DirectoryPath("src/web");

var configuration = Argument("configuration", "Release");

Task ("Build TS").Does(() =>
{
    NpmRunScript("build");
    CopyFiles(jsInputSrc + "/*.ts", jsOutputSrc);
});

Task ("Build Web")
    .Does(() =>
{
    var projectFile = "./src/web/web.csproj";

    DotNetBuild(projectFile, new DotNetBuildSettings
    {
        Configuration = configuration,
    });
});


Task("Build")
    .IsDependentOn("Build TS")
    .IsDependentOn("Build Web")
    .Does(() =>
{
    CopyFiles(jsOutputSrc + "/*.*", webInputSrc + "/wwwroot/js/");
});

Task("Package")
    .IsDependentOn("Build")
    .Does(() =>
    {

    });

RunTarget("Build");