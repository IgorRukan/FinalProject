using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] MovementComponent movementComponent;
    
    Animator animator;
    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }


    private void Update()
    {
        float inputHorizontal = joystick.Horizontal;
        float inputVertical = joystick.Vertical;

        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical);
        movementComponent.Move(movement);

        // if (movement != Vector3.zero)
        // {
        //     CharacterAnimator.SetTrigger("Run");
        // }
        // if (movement == Vector3.zero)
        // {
        //     CharacterAnimator.SetTrigger("Idle");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     CharacterAnimator.SetTrigger("Hit");
        // }
    }
}
