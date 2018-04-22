using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var drone = other.GetComponent<Drone>();
        if(drone != null) drone.DestroyDrone();
    }
}
