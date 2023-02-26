using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Rigidbody shell;
    public int bounces = 3;
    public float lifetime = 3;

    private float shellSpeed;
    private Vector3 lastVelocity;
    private Vector3 direction;
    private int bouncesUsed = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        lastVelocity = shell.velocity;  //stores the velocity of the shell every frame (for bullet bouncing)
        lifetime -= Time.deltaTime; //lifetime countdown for bullet

        if (lifetime <= 0)
        {
            Destroy(this.gameObject);   //when lifetime reaches 0, delete bullet
        }
    }

    /*
    /// <summary>
    /// Detects when a shell touches a collider
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (bouncesUsed >= bounces) Destroy(this.gameObject);   ///if a bullet has exhausted its max number of bounces, delete it

        shellSpeed = lastVelocity.magnitude;    //determines magnitude of velocity of shell before bounce
        direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal); //reflects the original velocity of shell for "bounce" effect

        shell.velocity = direction * Mathf.Max(shellSpeed, 0);  //prevents the speed from being a negative value (sometimes the physics engine bugs out and generates a negative speed)
        bouncesUsed++;  //increments number of bounces exhausted
    }
    */
}
