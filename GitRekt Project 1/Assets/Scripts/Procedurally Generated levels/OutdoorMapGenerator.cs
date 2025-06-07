using System;
using System.Collections;
using UnityEngine;


// In Unity. Edit -> Project Settings -> Graphics -> Camera -> Custom Axis -> x: 0; y: 1; z: -0.26 needs to be set to get the tiles to properly display

public class OutdoorMapGenerator : MonoBehaviour
{

    public GameObject tilePrefab; // Assign your sprite tile prefab
    [SerializeField] public int mapWidth = 10;
    [SerializeField] public int mapHeight = 10;
    [SerializeField] public float tileWidth = 1f;
    [SerializeField] public float tileHeight = 0.5f;



    void Start()
    {
        GenerateMap();
    }

    //Generate Map method
    void GenerateMap()
    {
        // instantiate the Object or Sprite inside the method
        for (int x = 0; x < mapWidth ; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector2 isoPosition = ConvertToIsometric(x, y);
                Instantiate(tilePrefab, new Vector3(isoPosition.x, isoPosition.y, 0), Quaternion.identity); // Quaternion is the rotation. Identity is default
            }
        }
    }

    Vector2 ConvertToIsometric(int x, int y)
    {
        float isoX = (x - y) * tileWidth / 2;
        float isoY = (x + y) * tileHeight / 2;
        return new Vector2(isoX, isoY);
   
    }

}
