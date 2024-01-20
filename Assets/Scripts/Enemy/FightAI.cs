using UnityEngine;

public class FightAI : MonoBehaviour
{
    
    public DamageableObject target;
    private MovementComponent mc;

    private Animations animations;

    private void Start()
    {
        mc = GetComponent<MovementComponent>();
        animations = GetComponent<Animations>();
    }

    private void Update()
    {
        target = GetComponent<PerceptionComponent>().GetTarget();
        if (target == null)
        {
            return;
        }
        Fight();
    }

    private void Fight()
    {
        Attack(target);
    }

    private void Attack(DamageableObject opponent)
    {
        Vector3 direction;
        if (!GetComponent<Shoot>().inRange)
        {
            direction = opponent.transform.position - transform.position;

            direction.Normalize();
            
            mc.Move(direction);
            Debug.Log("move "+direction);
            animations.SetMovement(direction);
        }
        else
        {
            direction = new Vector3(0, 0, 0);
            animations.SetMovement(direction);
        }

        transform.LookAt(opponent.transform);
    }
}