using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour {
    #region Primary Bonboneer
    [SerializeField] private ProjectileData primaryProjectileData;
    [SerializeField] private ProjectileData secondaryProjectileData;

    public Transform fireTransform; //object from where shot is fired
    private float primaryLastShootTime;
    private float secondaryLastShootTime;
    #endregion

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            ShootPrimary();
        } else if (Input.GetMouseButton(1)) {
            ShootSecondary();
        }
    }

    void ShootPrimary() {
        if (PrimaryReadyToFire()) {
            FirePrimaryBullet();
        }
    }

    private bool PrimaryReadyToFire() {
        return Time.time > primaryLastShootTime + primaryProjectileData.FireRate; //checks if the time elapsed is greater than the last shoot time + firerate
    }

    private void FirePrimaryBullet() {
        primaryLastShootTime = Time.time;  //updates the last shoot time to the current time elapsed
        Rigidbody shellInstance = Instantiate(primaryProjectileData.Shell, fireTransform.position, fireTransform.rotation) as Rigidbody;  //spawns a new Shell projectile from the prefab
        shellInstance.velocity = primaryProjectileData.LaunchForce * fireTransform.forward;   //assigns the shell a velocity in the direction the player is pointing
    }

    void ShootSecondary() {
        if (SecondaryReadyToFire()) {
            FireSecondaryBullet();
        }
    }

    private bool SecondaryReadyToFire() {
        return Time.time > secondaryLastShootTime + secondaryProjectileData.FireRate; //checks if the time elapsed is greater than the last shoot time + firerate
    }

    private void FireSecondaryBullet() {
        secondaryLastShootTime = Time.time;  //updates the last shoot time to the current time elapsed
        Rigidbody shellInstance = Instantiate(secondaryProjectileData.Shell, fireTransform.position, fireTransform.rotation) as Rigidbody;  //spawns a new Shell projectile from the prefab
        shellInstance.velocity = secondaryProjectileData.LaunchForce * fireTransform.forward;   //assigns the shell a velocity in the direction the player is pointing
    }

    public ProjectileData PrimaryProjectileData { get { return primaryProjectileData; } }
    public ProjectileData SecondaryProjectileData { get { return secondaryProjectileData; } }

}
