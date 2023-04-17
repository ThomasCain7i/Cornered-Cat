using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectControlMethod : MonoBehaviour
{
    public PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detect if the mouse is clicked
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            //The player is using a mouse
            thePlayer.useController = false;
        }

        //Detect if the mouse is clicked
        if (Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f)
        {
            thePlayer.useController = true;
        }
    }
}
