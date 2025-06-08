using UnityEngine;
using UnityEngine.Tilemaps;

public class OutdoorMapGenerator3D : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Prefab for 3D tiles
    
    public int minMapWidth = 5;
    public int maxMapWidth = 20;
    public int minMapHeight = 5;
    public int maxMapHeight = 20;

    System.Random random;

    

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        random = new System.Random();
        int mapWidth = random.Next(minMapWidth, maxMapWidth);
        int mapHeight = random.Next(minMapHeight, maxMapHeight);

        for (int x = -mapWidth; x < mapWidth; x++)
        {
            for (int z = -mapHeight; z < mapHeight; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                GameObject randomTile = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
                Instantiate(randomTile, position, Quaternion.identity);
            }
        }
    }
}
