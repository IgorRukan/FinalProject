using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Rigidbody rBody;

    public void Shoot(Vector3 dir)
    {
        rBody.velocity = new Vector3(0f,0f,0f);
        rBody.AddForce(dir * force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
