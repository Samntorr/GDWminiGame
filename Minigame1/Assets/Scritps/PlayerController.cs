using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement speeds
    private float moveSpeed = 8f;
    private float roadSpeed = 5f;
    private float curbSpeed = 3.5f;

    public GameObject projectilePrefab;

    //range for bounds
    private float xRange = 40f;
    private float yRange = 90f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //create bounds for the player
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        //Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch projectile from player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //change speed to be fast on the road
        if (collision.CompareTag("Road"))
        {
            moveSpeed = moveSpeed + roadSpeed;
        }

        //change speed to be slower on the curb
        if (collision.CompareTag("Curb"))
        {
            moveSpeed = moveSpeed - curbSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //bringing back to normal
        if (collision.CompareTag("Road"))
        {
            moveSpeed = moveSpeed - roadSpeed;
        }

        //bringing speed back to normal
        if (collision.CompareTag("Curb"))
        {
            moveSpeed = moveSpeed + curbSpeed;
        }
    }
}
