using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsController : MonoBehaviour
{
    public GameObject player;
    public GameObject correctText;

    //I want it to follow the player but it moves it into the house instead.
    private Vector3 offset = new Vector3(-7, -63, 0);

    public bool isCorrect = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = player.transform.position + offset;
            if (isCorrect)
            {
                //text is still not working
                correctText.SetActive(true);
            }
        }
    }
}
