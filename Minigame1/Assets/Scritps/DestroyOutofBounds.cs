using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    //bounds
    private float xRange = 40f;
    private float yRange = 90f;

    private void Update()
    {
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xRange)
        {
            Destroy(gameObject); ;
        }
        if (transform.position.y < -yRange)
        {
            Destroy(gameObject); ;
        }
        if (transform.position.y > yRange)
        {
            Destroy(gameObject); ;
        }
    }
}
