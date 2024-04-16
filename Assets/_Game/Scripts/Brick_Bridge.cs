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
    public ColorType color;

    [SerializeField] private GameObject brick_bridge;
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
        brick_bridge.SetActive(false);
        //ChangeColor((ColorType) (int) Mathf.Round(Random.Range(0.6f,4.5f)));
        //Debug.Log(color);
    }
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (brick_bridge != isActive && (character.bricks.Count) > 0)
            {
                isActive = true;
                brick_bridge.SetActive(true);
                // BrickManager.instance.AddBrick();
                SetColor(character.colortype);

                character.RemoveBrick();

            }
        }
    }

    public void SetColor(ColorType color)
    {
        brickRenderer.material = colorData.GetMat(color);

    }
}
