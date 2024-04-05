using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NguyenSpace;

public class Player : Character
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private GameObject playerSkin;

    [SerializeField] private Renderer _renderer;
    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        ChangeColor(ColorType.Red);
        //InitializeRandomColor();
    }


    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            ChangeAnim("Running");
        }
        else
        {
            ChangeAnim("Idle");

        }
    }

    //private void InitializeRandomColor()
    //{
    //    System.Array colors = System.Enum.GetValues(typeof(ColorType));
    //    ColorType randomColor = (ColorType)colors.GetValue(Random.Range(1, colors.Length));
    //    MaterialManager.Ins.SetMaterialByColor(gameObject, randomColor);
    //    MaterialManager.Ins.SetMaterialByColor(playerSkin, randomColor);

    //}

}