using UnityEngine;
using UnityEditor;

public class EntitasRefactor : EditorWindow
{
    private static readonly string GENERATED_PATH = Application.dataPath + "/Sources/Generated";
    private static readonly string STREAMING_PATH = Application.dataPath + "/StreamingAssets/Entitas";
    private static readonly string SCRIPTS_PATH = Application.dataPath + "/Scripts";
    private static readonly string ENTITAS_SCRIPTS_PATH = SCRIPTS_PATH + "/Entitas";

    private const string COMPONENTS_FILE = "/Components.cs";
    private static readonly string STREAMING_COMPONENTS_PATH = STREAMING_PATH + COMPONENTS_FILE;
    private static readonly string SCRIPTS_COMPONENTS_PATH = SCRIPTS_PATH + COMPONENTS_FILE;
    private static readonly string ENTITAS_COMPONENTS_PATH = ENTITAS_SCRIPTS_PATH + COMPONENTS_FILE;

    [MenuItem("Tools/Jenny/(1) Move Code To Streaming And DeleteGeneratedCode")]
    private static void MoveToStreaming()
    {
        FileUtil.MoveFileOrDirectory(ENTITAS_SCRIPTS_PATH, STREAMING_PATH);
        DeleteGeneratedCode();
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Moved Entitas code to StreamingAssets.");
    }

    [MenuItem("Tools/Jenny/(1.5) DeleteGeneratedCode")]
    private static void DeleteGeneratedCode()
    {
        FileUtil.DeleteFileOrDirectory(GENERATED_PATH);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Deleted generated code.");
    }

    [MenuItem("Tools/Jenny/(4) Move Code To Scripts")]
    private static void MoveToScripts()
    {
        FileUtil.MoveFileOrDirectory(STREAMING_PATH, ENTITAS_SCRIPTS_PATH);
        FileUtil.MoveFileOrDirectory(SCRIPTS_COMPONENTS_PATH, ENTITAS_COMPONENTS_PATH);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Moved Entitas code to Scripts/Entitas.");
    }

    [MenuItem("Tools/Jenny/(3) Move Components To Scripts")]
    private static void MoveComponentsToScripts()
    {
        FileUtil.MoveFileOrDirectory(STREAMING_COMPONENTS_PATH, SCRIPTS_PATH);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Moved Entitas Components to Scripts.");
    }
}
