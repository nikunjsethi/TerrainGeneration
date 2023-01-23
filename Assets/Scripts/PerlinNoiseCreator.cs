using UnityEngine;

public class PerlinNoiseCreator : MonoBehaviour
{

    public float HillTilling = 10.0f;
    public int MinimumHeight;
    public int MaximumHeight;
    private Terrain terrain;
    public TerrainLayer[] terrainLayer1;
    public TerrainLayer[] terrainLayer2;
    public TerrainLayer[] terrainLayer3;
    private TerrainData terrainData;
    private int mapResolutionOuter = 0;
    private int mapResolutionInner = 0;
    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        terrainData = GetComponent<Terrain>().terrainData;
    }

    public void GenerateHeights()
    {
        switch (Random.Range(0, 2))
        {
            case 0:

                terrainData.terrainLayers = terrainLayer1;
                break;

            case 1:
                terrainData.terrainLayers = terrainLayer2;
                break;

            case 2:
                terrainData.terrainLayers = terrainLayer3;
                break;

        }
        HillTilling = Random.Range(10, 30);
        MinimumHeight = Random.Range(10, 100);
        MaximumHeight = Random.Range(MinimumHeight + 10, 150);

        float hillHeight = (float)((float)MaximumHeight - (float)MinimumHeight) / ((float)terrainData.heightmapResolution / 2);
        float baseHeight = (float)MinimumHeight / ((float)terrainData.heightmapResolution / 2);
        float[,] Length = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        mapResolutionOuter = 0;
        while (mapResolutionOuter < terrainData.heightmapResolution)
        {
            mapResolutionInner = 0;
            while (mapResolutionInner < terrainData.heightmapResolution)
            {
                Length[mapResolutionOuter, mapResolutionInner] = baseHeight + (Mathf.PerlinNoise(((float)mapResolutionOuter / (float)terrainData.heightmapResolution) * HillTilling, ((float)mapResolutionInner / (float)terrainData.heightmapResolution) * HillTilling) * (float)hillHeight);
                mapResolutionInner++;
            }
            mapResolutionOuter++;
        }
        terrain.terrainData.SetHeights(0, 0, Length);
    }
}
