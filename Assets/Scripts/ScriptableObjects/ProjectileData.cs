using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ProjectileData", menuName = "Projectile Data", order = 51)]
public class ProjectileData : ScriptableObject
{
    //Identity
    [SerializeField] private string projectileName;
    [SerializeField] private string projectileId;

    //Model
    [SerializeField] private Rigidbody shell;

    //Projectile Data
    [SerializeField] private float launchForce;
    [SerializeField] private int ammo;
    [SerializeField] private float fireRate;
    [SerializeField] private float damage;

    #region Getters
    public string ProjectileName { get { return projectileName; } }
    public string ProjectileId { get { return projectileId; } }
    public Rigidbody Shell { get { return shell; } }
    public float LaunchForce { get { return launchForce; } }
    public int Ammo { get { return ammo; } }
    public float FireRate { get { return fireRate; } }
    public float Damage { get { return damage; } }

    #endregion

}
