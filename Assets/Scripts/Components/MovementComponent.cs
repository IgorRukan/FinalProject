using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public CharacterController characterController;
    public float gravity = -9.81f;

    private Stats stats;

    private CharacterController Controller
    {
        get { return characterController = characterController ? characterController : GetComponent<CharacterController>(); }
    }

    private void Start()
    {
        stats = GetComponent<Stats>();
    }


    public void Move(Vector3 movement)
    {

        movement.y = gravity;
        Vector3 displacement = movement * stats.speed * Time.deltaTime;
        Controller.Move(displacement);
    }
}
