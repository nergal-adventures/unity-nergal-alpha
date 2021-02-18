using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    private Joystick _joystick;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var joystickLeft = _joystick.Horizontal < 0 ? true : false;
        var joystickRight = _joystick.Horizontal > 0 ? true : false;
        var joystickIdle = _joystick.Horizontal == 0 ? true : false;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || joystickLeft)
        {
            _animator.SetBool("Turn_Left", true);
            _animator.SetBool("Turn_Right", false);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || joystickIdle)
        {
            _animator.SetBool("Turn_Left", false);
            _animator.SetBool("Turn_Right", false);
        }


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || joystickRight)
        {
            _animator.SetBool("Turn_Right", true);
            _animator.SetBool("Turn_Left", false);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || joystickIdle)
        {
            _animator.SetBool("Turn_Left", false);
            _animator.SetBool("Turn_Right", false);
        }
    }
}