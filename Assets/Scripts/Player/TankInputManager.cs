using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInputManager : MonoBehaviour {
    #region Variables
    [Header("Input Properties")]
    public Camera camera;

    #region Properties
    private Vector3 reticlePosition;
    public Vector3 ReticlePosition {
        get { return reticlePosition; }
    }

    private Vector3 reticleNormal;
    public Vector3 ReticleNormal {
        get { return reticleNormal; }
    }

    private float forwardInput;
    public float ForwardInput {
        get { return forwardInput; }
    }

    private float rotationInput;
    public float RotationInput {
        get { return rotationInput; }
    }
    #endregion

    void Update() {
        if (camera) {
            HandleInputs();
        }
    }

    /// <summary>
    /// Placeholder cursor marker
    /// </summary>
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(reticlePosition, 0.5f);
    }
    #endregion
    /// <summary>
    /// Generates a raycast to determine the position of the mouse relative to the world
    /// </summary>
    protected virtual void HandleInputs() {
        Ray screenRay = camera.ScreenPointToRay(Input.mousePosition);   //creates ray using screen mouse position
        RaycastHit hit;
        if (Physics.Raycast(screenRay, out hit)) {   //if the ray hits an object with a collider (aka a plane), set the relative mouse position and normal
        
            reticlePosition = hit.point;
            reticleNormal = hit.normal;
        }

        //stores directional input into variables, look up Input.GetAxis() for more details
        forwardInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }
}