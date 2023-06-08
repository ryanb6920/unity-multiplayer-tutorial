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
            scenes = scenes,
            locationPathName = "Builds/Win64Server/multiplayer-tutorial.exe",
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
            scenes = scenes,
            locationPathName = "Builds/LinuxServer/multiplayer-tutorial",
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
            scenes = scenes,
            locationPathName = "Builds/Win64Client/multiplayer-tutorial.exe",
            target = BuildTarget.StandaloneWindows64
        });
    }

    
}
