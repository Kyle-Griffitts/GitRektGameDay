using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;


// In Unity. Edit -> Project Settings -> Graphics -> Camera -> Custom Axis -> x: 0; y: 1; z: -0.26 needs to be set to get the tiles to properly display

public class OutdoorMapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;

    [SerializeField] public int minMapWidth = 5;
    [SerializeField] public int maxMapWidth = 20;
    [SerializeField] public int minMapHeight = 5;
    [SerializeField] public int maxMapHeight = 20;
    

    System.Random random;

    void Start()
    {
        GenerateMap();
    }

    //Generate Map method
    void GenerateMap()
    {
        tilemap.RefreshAllTiles();
        tilemap.ClearAllTiles();
        random = new System.Random();
        
        int mapWidth = random.Next(minMapWidth, maxMapWidth);
        int mapHeight = random.Next(minMapHeight, maxMapHeight);

        // instantiate the Object or Sprite inside the method
        for (int x = 0; x < mapWidth ; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int randomIndex = random.Next(tiles.Length);
                TileBase randomTile = tiles[randomIndex];
                tilemap.SetTile(new Vector3Int(x, y, 0), randomTile);
            }
        }
    }

}
