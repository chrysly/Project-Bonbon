using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public int hitpoints = 1;
    public GameObject tank;

    /// <summary>
    /// Method for changing health using a trigger collider
    /// Note: "Shell" is a custom tag
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Shell") //checks if the object that has collided with this object has a tag "Shell"
        {
            Destroy(other.gameObject);  //destory bullet and lower hitpoints by 1
            hitpoints--;
            if (hitpoints <= 0) //if hitpoints reaches zero, delete tank
            {
                Destroy(tank);
            }
        }
    }
}
