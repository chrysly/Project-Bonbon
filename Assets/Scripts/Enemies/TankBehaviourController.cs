using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankInputManager))]

public class TankBehaviourController : MonoBehaviour
{
    [Header("Tank Stats")]
    public float tankSpeed = 15f;
    public float rotationSpeed = 20f;

    [Header("AI Properties")]
    public Transform target;
    public float fireRate = 1f;
    public float spread = 0.5f;
    public float strafeRate = 3;


    [Header("Turret")]
    public Transform turret;
    public float turretLag;

    private float lastFireTime;

    private Rigidbody rbEnemyTank;
    private float posX;
    private float posY;
    private float posZ;

    private float posMin = -5f;
    private float posMax = 5f;

    Vector3 targetPos;

    void Awake()
    {
        rbEnemyTank = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetNewPosition();
    }

    void GetNewPosition()
    {
        posX = Random.Range(posMin, posMax);
        posZ = Random.Range(posMin, posMax);

        Vector3 newPosition = new Vector3(posX, transform.position.y, posZ);
        targetPos = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetPos) < 10f)
        {
            GetNewPosition();
        }
        Rotate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Rotate()
    {
        Vector3 tankDir = targetPos - transform.position;
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, tankDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void Move()
    {
        Vector3 moveForward = transform.forward * tankSpeed;
        rbEnemyTank.MovePosition(rbEnemyTank.position + moveForward);
    }

    protected virtual void HandleMovement()
    {

    }

    protected virtual void HandleDirection()
    {

    }

    protected virtual void Shoot()
    {

    }
}
