using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JsonExample : MonoBehaviour
{
    public const string KEY = "KEY";

    [ContextMenu("Save")]
    public void Save()
    {
        PlayerPrefs.SetString( KEY, "string" );
        PlayerPrefs.Save();
    }

    [ContextMenu( "Load" )]
    public void LoadFromDisk()
    {
        var savedJson = PlayerPrefs.GetString( KEY );
        //JsonUtility.FromJsonOverwrite(savedJson, _object)
    }

    [ContextMenu( "Load and save as asset" )]
    public void LoadFromDiskAndSaveAsset()
    {
        var savedJson = PlayerPrefs.GetString( KEY );
        var newObject = JsonUtility.FromJson<Object>( savedJson );
        AssetDatabase.CreateAsset( newObject, "_Game/" );
    }
}
