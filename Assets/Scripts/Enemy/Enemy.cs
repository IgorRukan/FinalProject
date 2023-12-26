using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DamageableObject
{
    private MovementComponent mc;
    private HealthSystem healthSystem;
    
    [Header("Сколько идет")] public float movementTime = 3f;
    [Header("Сколько стоит")] public float stopTime = 2f;

    private Vector3 moveVector;
    
    [Header("Принимают значения от 0 и 1, где 0 - стоит, 1 - идет ")]
    public int randMoveDirectionX;
    public int randMoveDirectionZ;
    
    [Header("Задают направление, принимает значения 0,-1,1")]
    public int randXMin = -1;
    public int randXMax = 1;
    public int randZMin = -1;
    public int randZMax = 1;

    private bool pause = false;

    void Awake()
    {
        mc = GetComponent<MovementComponent>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.Death += OnEnemyDeath;
    }

    private void OnEnemyDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        StartCoroutine(Moving());
    }

    protected void Update()
    {
        if (!pause)
        {
            RandomMovement();
        }
    }

    protected virtual void RandomMovement()
    {
        mc.Move(moveVector);
    }

    IEnumerator Moving()
    {
        var sign = Random.Range(-1, 2);
        var sign2 = Random.Range(-1, 2);
        sign = Mathf.Clamp(sign, randXMin, randXMax);
        sign2 = Mathf.Clamp(sign2, randZMin, randZMax);
        moveVector = new Vector3(randMoveDirectionX * sign, 0, randMoveDirectionZ * sign2);
        yield return new WaitForSeconds(movementTime);
        pause = true;
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(stopTime);
        pause = false;
        StartCoroutine(Moving());
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
    }

    public override HealthSystem GetHealthSystem()
    {

        return gameObject.GetComponent<HealthSystem>();
    }
}
