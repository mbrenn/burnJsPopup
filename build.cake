#addin nuget:?package=Cake.Npm&version=5.0.0

var jsInputSrc = new DirectoryPath("src/js");
var jsOutputSrc = new DirectoryPath("build/js");
var webInputSrc = new DirectoryPath("src/web");
var cssInputSrc = new DirectoryPath("src/css");
var webCssSrc = new DirectoryPath("src/web/wwwroot/css");
var dist = new DirectoryPath("dist");

var configuration = Argument("configuration", "Debug");
var target = Argument("target", "Build");

Task ("Build TS").Does(() =>
{
    NpmRunScript("build");
    CopyFiles(jsInputSrc + "/*.ts", jsOutputSrc);
});

Task ("Build Web")
    .Does(() =>
{    
    CopyFiles(cssInputSrc + "/*.css", webCssSrc);

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
    // Copy now the stuff together
    CopyFiles(jsOutputSrc + "/*.*", webInputSrc + "/wwwroot/js/");
});

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetRun("./src/web/web.csproj", new DotNetRunSettings
    {
        Configuration = configuration,
    });
});


Task("Package")
    .IsDependentOn("Build")
    .Does(() =>
    {
        CopyFiles(jsInputSrc + "/*.*", dist + "/js/");
        CopyFiles(cssInputSrc + "/*.*", dist + "/css/");
        NpmPack();
    });

Task("Publish")
    .IsDependentOn("Package")
    .Does(() =>
    {
        NpmPublish(
            new NpmPublishSettings
            {
                Access = NpmPublishAccess.Public
            }
        );
    });

RunTarget(target);