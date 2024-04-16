using UnityEngine;
using UnityEngine.AI; 
using NguyenSpace;
using System.Linq;
using Unity.VisualScripting.ReorderableList;
using Unity.VisualScripting;

public class Enemy : Character
{
    //Brick targetBrick = null;
    //private float minDistance = 100f;
    private Vector3 brickPosition;
    public bool isMoving = false;

    public void OnInit()
    {
        ChangeColor(colortype);
    }

    
    public void GetDestination(ColorType color)
    {
        brickPosition = MapManager.Ins.DetectBrick(color);
    }
    public void MoveToBrick()
    {
        if (brickPosition != null)
        {
            agent.SetDestination(brickPosition);
            if (Vector3.Distance(transform.position, brickPosition + (transform.position.y - brickPosition.y) * Vector3.up) < 0.1f)
            {
                Debug.Log("stoppppp");
                isMoving = false;
            }
        }
    }

    public void CheckMoving()
    {
        if (Vector3.Distance(transform.position, brickPosition + (transform.position.y - brickPosition.y) * Vector3.up) > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}