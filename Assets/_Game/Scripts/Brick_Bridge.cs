using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class Brick_Bridge : MonoBehaviour
{
    //keo tha color data vao
    [SerializeField] Renderer brickRenderer;
    [SerializeField] ColorData colorData;
    public ColorType colorBrick;

    [SerializeField] private GameObject unBrick;
    [SerializeField] private Collider col;
    public bool isActive = false;
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
        isActive = false;
        unBrick.SetActive(false);
        //ChangeColor((ColorType) (int) Mathf.Round(Random.Range(0.6f,4.5f)));
        //Debug.Log(color);
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if ((character.charListBricks.Count) > 0)
            {
                if (unBrick != isActive )
                {
                    isActive = true;
                    unBrick.SetActive(true);
                    SetColor(character.colortype);
                    character.RemoveBrick(); 
                }
                else if (character.colortype != colorBrick)
                {
                    SetColor(character.colortype);
                    character.RemoveBrick();
                }
                else
                {

                }
            }
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    Character character = other.GetComponent<Character>();
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    //    {
    //        if(unBrick == isActive && (character.charListBricks.Count) > 0)
    //        {
    //            character.RemoveBrick();
    //        }
    //    }
    //}

    public void SetColor(ColorType colortype)
    {
        colorBrick = colortype;
        brickRenderer.material = colorData.GetMat(colortype);
    }
}
