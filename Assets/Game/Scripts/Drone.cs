using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        MoveDrone();
    }

    private void MoveDrone()
    {
        transform.position += Vector3.down * _speed * Time.deltaTime;
    }

    public void DestroyDrone()
    {
        // Destroy Vfx, Sfx
        Destroy(gameObject);
    }
}
