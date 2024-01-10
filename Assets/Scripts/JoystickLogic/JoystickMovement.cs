using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] MovementComponent movementComponent;

    Animator animator;
    private Animations animations;

    public float rotateSpeed = 10f;

    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }

    private void Start()
    {
        animations = GetComponent<Animations>();
    }

    private void Update()
    {
        float inputHorizontal = joystick.Horizontal;
        float inputVertical = joystick.Vertical;
        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical);
        movementComponent.Move(movement);
        animations.SetMovement(movement);
        if (Mathf.Abs(movement.magnitude) > 0.05f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),
                Time.deltaTime * rotateSpeed);
        }
    }
}