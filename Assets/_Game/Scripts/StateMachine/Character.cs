using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Singleton<Character> 
{
    //keo tha color data vao
    [SerializeField] ColorData colorData;
    public ColorType color;

    //keo mesh renderer vao
    [SerializeField] Renderer meshRenderer;
    private string currentAnimNumber;

    [SerializeField] private Animator anim;

    private IState<Character> currentState;

    private void Start()
    {
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    //thay doi mau object
    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }

    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void ChangeAnim(string animName)
    {
        if (currentAnimNumber != animName)
        {
            anim.SetTrigger(animName);
            currentAnimNumber = animName;
        }
    }

}
