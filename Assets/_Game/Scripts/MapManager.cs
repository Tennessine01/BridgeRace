using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer brickRenderer;

    public GameObject brickPrefab;
    public int width = 5;
    public int height = 5;
    public float brickSpacing = 1f;
    void Start()
    {
        GenerateGrid();
    }

    
    public void GenerateGrid()
    {
        float offsetX = (width - 1 + (width - 1) * brickSpacing) / 2.0f; 
        float offsetY = (height - 1 + (height - 1) * brickSpacing) / 2.0f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3((x * (1 + brickSpacing)) - offsetX,0.625f, (y * (1 + brickSpacing)) - offsetY);

                GameObject newBrick = Instantiate(brickPrefab, position, Quaternion.identity);

                newBrick.transform.SetParent(this.transform);
            }
        }
    }
}