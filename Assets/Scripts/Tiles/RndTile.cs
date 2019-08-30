using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RndTile : Tile
{
    public Sprite[] sprites;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(location,  tilemap, ref tileData);
        if (sprites.Length > 0)
        {
            tileData.sprite = sprites[(int) (sprites.Length * UnityEngine.Random.value)];
        }
    }
    
    #if UNITY_EDITOR
    [MenuItem("Assets/Create/Rnd Tile")]
    public static void NewRndTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Create RndTile", "RndTile", "asset", "Create RndTile");
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<RndTile>(), path);
    }
    #endif
}
