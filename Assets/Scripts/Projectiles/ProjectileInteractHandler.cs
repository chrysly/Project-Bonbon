using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInteractHandler : MonoBehaviour
{
    [SerializeField] private GameObject tankObject;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Material material;

    private bool active = false;

    private string primaryProjectildId;
    private string secondaryProjectileId;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitializeScriptableObjects() {
        TankShooter shooterScript = tankObject.GetComponent<TankShooter>();
        primaryProjectildId = shooterScript.PrimaryProjectileData.ProjectileId;
        secondaryProjectileId = shooterScript.SecondaryProjectileData.ProjectileId;

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Shell" && active == false) {
            Destroy(collision.gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
            gameObject.GetComponent<MeshRenderer>().material = material;
            active = true;
        }
    }
}
