using UnityEditor;

public class BuildProject
{
    public static void Win64Server()
    {
        string[] scenes = new string[] { "Assets/Scenes/SampleScene.unity" };

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.subtarget = (int)StandaloneBuildSubtarget.Server;

        BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            locationPathName = "Builds/Win64Server",
            target = BuildTarget.StandaloneWindows64,
            subtarget = (int)StandaloneBuildSubtarget.Server
        });
    }

    public static void LinuxServer()
    {
        string[] scenes = new string[] { "Assets/Scenes/SampleScene.unity" };

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.subtarget = (int)StandaloneBuildSubtarget.Server;

        BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            locationPathName = "Builds/LinuxServer",
            target = BuildTarget.StandaloneLinux64,
            subtarget = (int)StandaloneBuildSubtarget.Server
        });
    }

    public static void Win64Client()
    {
        string[] scenes = new string[] { "Assets/Scenes/SampleScene.unity" };

        BuildPlayerOptions options = new BuildPlayerOptions();
        options.subtarget = (int)StandaloneBuildSubtarget.Server;

        BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            locationPathName = "Builds/Win64Client",
            target = BuildTarget.StandaloneWindows64
        });
    }

    
}
