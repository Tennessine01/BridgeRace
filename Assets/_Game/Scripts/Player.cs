using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NguyenSpace;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    [SerializeField] private FloatingJoystick joystick;

    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject playerSkin;

    [SerializeField] private Renderer render;
    [SerializeField] private Transform skintransform;
    [SerializeField] private GameObject brick_Bridge;

    private bool canMoveUp = true;
    
    public void Update()
    {
        JoystickMove();
    }
    private void JoystickMove()
    {
        Vector3 movementDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (movementDirection.magnitude > 0)
        {
            Debug.Log(canMoveUp + "---");
            if (!canMoveUp && movementDirection.z > 0)
            {
                movementDirection.z = Mathf.Min(0, movementDirection.z);
            }
            //transform.position += movementDirection * Time.deltaTime * moveSpeed;
            rb.velocity = movementDirection * 5 + rb.velocity.y*Vector3.up ;
            //float targetAngle = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg + 90f;
            //Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

            //transform.right = targetRotation * Vector3.forward;
            transform.forward = movementDirection;

            ChangeAnim("Running");
        }
        else
        {
            rb.velocity = Vector3.zero;
            ChangeAnim("Idle");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Brick_Bridge brick_bridge = other.GetComponent<Brick_Bridge>();
        if (other.CompareTag("UnBrick") && charListBricks.Count == 0 )
        {
            if(colortype != brick_bridge.colorBrick)
            {
                canMoveUp = false;
            }
            else
            {
                canMoveUp = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UnBrick"))
        {
            canMoveUp = true; 
        }
    }


    //public void RemoveBrick()
    //{
    //    if (charListBricks.Count > 0 && count > 0)
    //    {
    //        count--;
    //        GameObject lastBrick = charListBricks[charListBricks.Count - 1];
    //        charListBricks.RemoveAt(charListBricks.Count - 1);
    //        Destroy(lastBrick);

    //        character.position += -Vector3.up * 0.35f;
    //        //Debug.Log(charListBricks.Count);
    //    }
    //    else
    //    {
    //        LevelManager.instance.RestartLevel();
    //        OnInit();
    //        MovementManager.instance.OnInit();
    //    }
    //}

    //public void ClearBrick()
    //{
    //    foreach (var brick in charListBricks)
    //    {
    //        Destroy(brick);
    //    }
    //    charListBricks.Clear();

    //    //Debug.Log(charListBricks.Count + "---");

    //    count = 0;

    //    character.position = transform.position;
    //    //character.position = MovementManager.Instance.EndPosition() - new Vector3(0,0,-2.5f);
    //}
}