using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoesUp : PlayerManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Left") && other.CompareTag("Right"))
        {
            PlayerManager.playerGoesUp = false;
            Debug.Log("haut");
        }
        else
        {
            playerGoesUp= true;
        }
    }
}
