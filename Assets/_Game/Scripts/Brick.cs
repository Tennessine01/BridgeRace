using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //keo tha color data vao
    [SerializeField] Renderer brickRenderer;
    [SerializeField] ColorData colorData;
    public ColorType color;

    [SerializeField] private GameObject brick;

    public bool isActive = true;
    private Renderer render;
    public Renderer Renderer
    {
        get
        {
            //tf = tf ?? gameObject.transform;
            if (render == null)
            {
                render = Renderer;
            }
            return render;
        }
    }
    
    void Start()
    {
        OnInit();
    }

    //public int GetTypeColor()
    //{
    //    s
    //}

    private void OnInit()
    {
        isActive = true;
        brick.SetActive(true);
        ChangeColor((ColorType) (int) Mathf.Round(Random.Range(0.6f,4.5f)));
        Debug.Log(color);
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character.color == color) 
        {
            if (brick != null)
            {
                isActive = false;
                brick.SetActive(false);
                //BrickManager.instance.AddBrick();
            }
        }
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        brickRenderer.material = colorData.GetMat(colorType);
    }
}
