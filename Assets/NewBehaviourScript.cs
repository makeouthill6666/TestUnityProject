using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;

public class CreateInventoryAssets
{
    [MenuItem("Tools/Create Inventory Assets")]
    public static void CreateInventoryAssetsFolder()
    {
        // 폴더 경로 설정
        string inventoryFolderPath = "Assets/4_Simulation/Inventory";
        string scenesFolderPath = Path.Combine(inventoryFolderPath, "Scenes");
        string scriptsFolderPath = Path.Combine(inventoryFolderPath, "Scripts");

        // 폴더가 존재하지 않으면 생성
        if (!Directory.Exists(inventoryFolderPath))
        {
            Directory.CreateDirectory(inventoryFolderPath);
            Debug.Log("Created folder: " + inventoryFolderPath);
        }

        if (!Directory.Exists(scenesFolderPath))
        {
            Directory.CreateDirectory(scenesFolderPath);
            Debug.Log("Created folder: " + scenesFolderPath);
        }

        if (!Directory.Exists(scriptsFolderPath))
        {
            Directory.CreateDirectory(scriptsFolderPath);
            Debug.Log("Created folder: " + scriptsFolderPath);
        }

        // 씬 파일 생성
        string scenePath = Path.Combine(scenesFolderPath, "InventoryScene.unity");
        if (!File.Exists(scenePath))
        {
            var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            EditorSceneManager.SaveScene(newScene, scenePath);
            Debug.Log("New scene created at: " + scenePath);
        }
        else
        {
            Debug.Log("Scene already exists at: " + scenePath);
        }

        // 스크립트 파일 생성
        string scriptPath = Path.Combine(scriptsFolderPath, "InventoryScript.cs");
        if (!File.Exists(scriptPath))
        {
            string scriptContent = "using UnityEngine;\n\npublic class InventoryScript : MonoBehaviour\n{\n    void Start()\n    {\n        // Initialize inventory\n    }\n\n    void Update()\n    {\n        // Update inventory\n    }\n}\n";
            File.WriteAllText(scriptPath, scriptContent);
            AssetDatabase.Refresh();
            Debug.Log("New script created at: " + scriptPath);
        }
        else
        {
            Debug.Log("Script already exists at: " + scriptPath);
        }
    }
}

