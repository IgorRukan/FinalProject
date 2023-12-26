using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed = 3f;
    public CharacterController characterController;
    public float gravity = -9.81f;

    private CharacterController Controller
    {
        get { return characterController = characterController ? characterController : GetComponent<CharacterController>(); }
    }


    public void Move(Vector3 movement)
    {

        movement.y = gravity;
        Vector3 displacement = movement * speed * Time.deltaTime;
        Controller.Move(displacement);
    }
}
