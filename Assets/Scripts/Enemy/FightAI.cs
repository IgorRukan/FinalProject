using UnityEngine;

public class FightAI : MonoBehaviour
{
    public DamageableObject target;
    private MovementComponent mc;

    private Animations animations;

    public Vector3 startPos;


    private void Start()
    {
        mc = GetComponent<MovementComponent>();
        animations = GetComponent<Animations>();
        startPos = GetComponent<Transform>().position;
    }

    private void Update()
    {
        target = GetComponent<PerceptionComponent>().GetTarget();
        if (target == null)
        {
            var direction = new Vector3(0, 0, 0);
            animations.SetMovement(direction);
            return;
        }

        Fight();
    }

    private void Fight()
    {
        Attack(target);
        var pc = GetComponent<PerceptionComponent>();
        if (pc.nearestEnemy != null)
        {
            foreach (var enemy in pc.nearestEnemy)
            {
                if (enemy.GetComponent<PerceptionComponent>().GetTarget() == null)
                {
                    enemy.GetComponent<PerceptionComponent>().SetTarget(target);
                }
            }
        }
    }

    private void Attack(DamageableObject opponent)
    {
        Vector3 direction;
        if (!GetComponent<Shoot>().inRange)
        {
            direction = opponent.transform.position - transform.position;

            direction.Normalize();

            mc.Move(direction);
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