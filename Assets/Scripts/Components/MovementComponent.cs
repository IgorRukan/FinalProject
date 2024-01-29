using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public CharacterController characterController;
    public float gravity = -9.81f;
    
    private CharacterController Controller
    {
        get { return characterController = characterController ? characterController : GetComponent<CharacterController>(); }
    }


    public void Move(Vector3 movement)
    {
        var speed = GetComponent<StatImpact>().GetSpeed();
        movement.y = gravity;
        Vector3 displacement = movement * speed * Time.deltaTime;
        Controller.Move(displacement);
    }
}
