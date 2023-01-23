using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public DiamondSquareTerrain diamondSquareTerrain;
    public PerlinNoiseCreator perlinNoiseCreator;
    public GameObject diamondGameObject;
    public GameObject perlinGameObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            perlinGameObject.SetActive(false);
            diamondGameObject.SetActive(true);
            diamondSquareTerrain.CreateTerrain();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            perlinGameObject.SetActive(true);
            diamondGameObject.SetActive(false);
            perlinNoiseCreator.GenerateHeights();

        }
    }
}
