using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //keo tha color data vao
    [SerializeField] Renderer brickRenderer;
    [SerializeField] ColorData colorData;
    [SerializeField] Platform_manager mapManager;
    public ColorType color;

    [SerializeField] private GameObject brick;

    public bool isActive = true;
    private Renderer render;
    public Renderer Renderer
    {
        get
        {
            if (render == null)
            {
                render = GetComponent<Renderer>();
            }
            return render;
        }
    }

    void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        isActive = true;
        brick.SetActive(true);
        
    }
    
    private void ActiveBrick()
    {
        if (!isActive)
        {
            brick.SetActive(true);
            isActive = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null && character.colortype == color && brick != null)
        {
            isActive = false;
            brick.SetActive(false);
            character.AddBrick();
            //Platform_manager.Ins.mapListBricks.Remove(this);
            // BrickManager.instance.AddBrick();
            Invoke(nameof(ActiveBrick), 10f);

        }
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        brickRenderer.material = colorData.GetMat(colorType);
    }
}
