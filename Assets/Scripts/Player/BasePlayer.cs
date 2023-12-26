using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayer : DamageableObject 
{
    private PlayerInput input;
    public MovementComponent movementComponent;
    private Vector3 movement;
    public Animator animator;
    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }
    private void Start()
    {
        input = new PlayerInput();
        input.Enable();
        input.Player.Move.performed += Move_performed;
        input.Player.Move.canceled += Move_canceled;
    }

    private void Move_canceled(InputAction.CallbackContext context)
    {
        movement = Vector3.zero;
        
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
       
        Vector2 inputValue = context.ReadValue<Vector2>();
        movement = new Vector3(inputValue.x, 0, inputValue.y);
    }

    private void Update()
    {
        movementComponent.Move(movement);


        if(movement !=  Vector3.zero ) 
        {
            CharacterAnimator.SetTrigger("Run");
        }
        if (movement == Vector3.zero)
        {
            CharacterAnimator.SetTrigger("Idle");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CharacterAnimator.SetTrigger("Hit");
        }
    }

    public override HealthSystem GetHealthSystem()
    {
        return gameObject.GetComponent<HealthSystem>();
    }
}
