using NguyenSpace;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    //keo tha color data vao
    [SerializeField] ColorData colorData;
    public ColorType colortype;

    //keo mesh renderer vao
    [SerializeField] Renderer meshRenderer;
    //Anim
    [SerializeField] private Animator animm;
    private string currentAnimNumber;
    //Rigidbidy
    [SerializeField] public Rigidbody rb;
    //Addbrick
    [SerializeField] public Transform brickParent;
    public List<Brick> charListBricks = new List<Brick>();
    [SerializeField] private Brick brickPrefab;
    public int count;
    //CheckMove tren cau
    public NavMeshAgent agent;
    public int currentMap = 1;

    private IState<Character> currentState;

    //public void Start()
    //{
    //    OnInit();
    //}

    public void OnInit()
    {    

        ChangeColor(colortype);
        count = 0;
        charListBricks.Clear();
        ClearBrick();
        ChangeState(new IdleState());
    }
    // Update is called once per frame
    public virtual void Update()
    {

        //Debug.Log(currentState != null);

        if (currentState != null)
        {
            //Debug.Log("------" + currentState != null + gameObject.name + "-----");

            currentState.OnExecute(this);
        }
    }
    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        //Debug.LogError(currentState);
        //Debug.LogError(currentState != null);

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }


    //-----------------------------------------------------------

    //thay doi mau object
    public void ChangeColor(ColorType clt)
    {
        colortype = clt;
        meshRenderer.material = colorData.GetMat(clt);
    }
    public void ChangeAnim(string animName)
    {
        if (currentAnimNumber != animName)
        {
            animm.SetTrigger(animName);
            currentAnimNumber = animName;
        }
    }

    public virtual void AddBrick()
    {
        count++;
        Vector3 brickPosition = brickParent.position + new Vector3(0f,0.3f * count, 0f);
        Vector3 brickRotation = brickParent.rotation.eulerAngles;
        Brick newBrick = Instantiate(brickPrefab, brickPosition, Quaternion.Euler(brickRotation), brickParent);

        //newbrick thua ke gameunit cua pool, gameunit changecolor cua brick
        //brick chi dung de tuong tac va respawn
        newBrick.ChangeColor(colortype);
        charListBricks.Add(newBrick);
    }

    public virtual void RemoveBrick()
    {
        if (charListBricks.Count > 0 && count > 0)
        {
            count--;
            Brick lastBrick = charListBricks[charListBricks.Count - 1];
            //
            Destroy(lastBrick.gameObject);
            charListBricks.RemoveAt(charListBricks.Count - 1);

            //brickParent.position += -Vector3.up * 0.3f;
            //Debug.Log(charListBricks.Count);
        }
        //else
        //{
        //    LevelManager.instance.RestartLevel();
        //    OnInit();
        //    MovementManager.instance.OnInit();
        //}
    }

    public void ClearBrick()
    {
        foreach (var brick in charListBricks)
        {
            Destroy(brick);
        }
        charListBricks.Clear();

        count = 0;

        //character.position = transform.position;
        //character.position = MovementManager.Instance.EndPosition() - new Vector3(0,0,-2.5f);
    }
}
