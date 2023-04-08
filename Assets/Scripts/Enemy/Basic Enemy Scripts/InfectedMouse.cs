using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedMouse : MonoBehaviour
{
    public PlayerController playerController;
    public void Start()
    {
        //Find object that has 
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.infectedCooldown += 2f;
        }
    }
}