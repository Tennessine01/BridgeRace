using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;


public class MapManager : Singleton<MapManager>
{
    //[SerializeField] ColorData colorData;
    //[SerializeField] Renderer brickRenderer;
    public List<Brick> listbrick = new List<Brick>();

    public NavMeshSurface navMesh;
    public Brick brickPrefab;
    //public GameObject character;
    public int width = 5;
    public int height = 5;
    public float brickSpacing = 1f;
    [SerializeField] public Transform platformPos;

    Brick targetBrick;
    private float minDistance = 1000f;
    private Vector3 currentBrickPosition;
    //private Dictionary<ColorType, int> colorCounts = new Dictionary<ColorType, int>();

    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        //calculate center of grid
        Vector3 center = new Vector3((width - 1) * 0.5f * (1 + brickSpacing), 0f, (height - 1) * 0.5f * (1 + brickSpacing));

        List<Vector3> allPositions = new List<Vector3>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * (1 + brickSpacing), 0.625f, y * (1 + brickSpacing)) - center;
                allPositions.Add(position);
            }
        }
        // shuffle vi tri cac vien gach sinh ra
        Shuffle(allPositions);

        // sau khi co vi tri random, set mau cho cac vien gach random day
        for (int i = 0; i < 12; i++)
        {
            Vector3 position = allPositions[i];
            CreateBrick(position, ColorType.Red);
        }
        for (int i = 12; i < 24; i++)
        {
            Vector3 position = allPositions[i];
            CreateBrick(position, ColorType.Green);
        }
        for (int i = 24; i < 36; i++)
        {
            Vector3 position = allPositions[i];
            CreateBrick(position, ColorType.Orange);
        }
    }

    public void CreateBrick(Vector3 position, ColorType color)
    {
        Brick newBrick = Instantiate(brickPrefab, position, Quaternion.identity);

        newBrick.ChangeColor(color);
        newBrick.transform.SetParent(platformPos);
        listbrick.Add(newBrick);
    }

    public void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public Vector3 DetectBrick(ColorType colortype)
    {
        targetBrick = null;
        minDistance = 1000f;

        for (int i = 0; i < listbrick.Count; i++)
        {
            if (listbrick[i].color == colortype && listbrick[i].isActive)
            {
                float currentDistance = Vector3.Distance(transform.position, listbrick[i].transform.position);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    targetBrick = listbrick[i];
                }
            }
        }

        //Debug.Log(targetBrick.transform.position + "----------------");
        if (targetBrick != null)
        {
            if (currentBrickPosition != targetBrick.transform.position)
            {
                currentBrickPosition = targetBrick.transform.position;
            }
            return targetBrick.transform.position;

        }
        return currentBrickPosition;
    }
}