using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Rigidbody rBody;
    private Transform target;

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rBody.velocity = direction * force;
        }
    }
    public void Shoot(Vector3 dir)
    {
        rBody.AddForce(Vector3.forward * force, ForceMode.Impulse);
        rBody.velocity = new Vector3(0f,0f,0f);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
