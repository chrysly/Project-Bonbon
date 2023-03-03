using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankInputManager))]

public class PlayerMovementController : MonoBehaviour {

    [Header("Tank Properties")]
    public float tankSpeed = 15f;
    public float rotationSpeed = 20f;
    [SerializeField] private Transform actorToTranslate;

    [Header("Turret Properties")]
    public Transform turret;
    public float turretLag = 0.5f;
    
    private Rigidbody rb;
    private TankInputManager input;
    private Vector3 finalTurretDir;



    void Start() {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<TankInputManager>();
    }

    private void FixedUpdate() {
        if (rb && input) {
            SetPosition();
            SetRotation();
            HandleTurret();
        }
    }

    protected void SetPosition() {
        //Translation
        Vector3 forwardPosition = transform.position + (transform.forward * input.ForwardInput * tankSpeed * Time.deltaTime);
        actorToTranslate.position = forwardPosition;
    }
    protected void SetRotation() {
        //Rotation
        Quaternion forwardRotation;
        if ((input.ForwardInput < 0) && (input.RotationInput != 0)) { //if the tank is going backwards, flip the rotation (or else the rotation controls would be inverted when going backwards)
            forwardRotation = transform.rotation * Quaternion.Euler(Vector3.up * (-input.RotationInput * rotationSpeed * Time.deltaTime));
        } else {
            forwardRotation = transform.rotation * Quaternion.Euler(Vector3.up * (input.RotationInput * rotationSpeed * Time.deltaTime));
        }
        rb.MoveRotation(forwardRotation);
    }

    /// <summary>
    /// Helper method for rotating the actual turret mesh on the tank in
    /// in the direction the mouse is positioned
    /// </summary>
    protected virtual void HandleTurret() {
        if (turret) {
            Vector3 lookDirection = input.ReticlePosition - turret.position;    //direction vector is determined by subtracting the position of the reticle to the actual position of the turret (lin alg moment)

            finalTurretDir = Vector3.Lerp(finalTurretDir, lookDirection, Time.deltaTime * turretLag);   //see Lerp() on unity docs, essentially delays rotation for smoother movement
            finalTurretDir.y = 0f;  //lock turret rotation on the y-axis (we only want to rotate it on the z-axis)
            turret.rotation = Quaternion.LookRotation(finalTurretDir);  //applies the rotation to the turret mesh
        }
    }
}
