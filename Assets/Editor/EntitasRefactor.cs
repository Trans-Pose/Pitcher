using UnityEngine;
using UnityEditor;

public class EntitasRefactor : EditorWindow
{
    private static readonly string GENERATED_PATH = Application.dataPath + "/Sources/Generated";
    private static readonly string NOCOMP_PATH = Application.dataPath + "/.NoCompile";
    private static readonly string SCRIPTS_PATH = Application.dataPath + "/Scripts";
    private static readonly string ENTITAS_SCRIPTS_PATH = SCRIPTS_PATH + "/Entitas";

    private const string COMPONENTS_FILE = "/Components.cs";
    private static readonly string NOCOMP_COMPONENTS_PATH = NOCOMP_PATH + COMPONENTS_FILE;
    private static readonly string SCRIPTS_COMPONENTS_PATH = SCRIPTS_PATH + COMPONENTS_FILE;
    private static readonly string ENTITAS_COMPONENTS_PATH = ENTITAS_SCRIPTS_PATH + COMPONENTS_FILE;

    [MenuItem("Tools/Jenny/(1) Move Code To NoCompile And DeleteGeneratedCode")]
    private static void MoveToNoCompileZone()
    {
        FileUtil.MoveFileOrDirectory(ENTITAS_SCRIPTS_PATH, NOCOMP_PATH);
        DeleteGeneratedCode();
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Moved Entitas code to " + NOCOMP_PATH + ".");
    }

    [MenuItem("Tools/Jenny/(1.5) DeleteGeneratedCode")]
    private static void DeleteGeneratedCode()
    {
        FileUtil.DeleteFileOrDirectory(GENERATED_PATH);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Deleted generated code.");
    }

    [MenuItem("Tools/Jenny/(3) Move Components To Scripts")]
    private static void MoveComponentsToScripts()
    {
        FileUtil.MoveFileOrDirectory(NOCOMP_COMPONENTS_PATH, SCRIPTS_COMPONENTS_PATH);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Moved Entitas Components to " + SCRIPTS_COMPONENTS_PATH + ".");
    }

    [MenuItem("Tools/Jenny/(5) Move Code To Scripts")]
    private static void MoveToScripts()
    {
        FileUtil.MoveFileOrDirectory(NOCOMP_PATH, ENTITAS_SCRIPTS_PATH);
        FileUtil.MoveFileOrDirectory(SCRIPTS_COMPONENTS_PATH, ENTITAS_COMPONENTS_PATH);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

        Debug.Log("Moved Entitas code to " + ENTITAS_SCRIPTS_PATH + ".");
    }


}
