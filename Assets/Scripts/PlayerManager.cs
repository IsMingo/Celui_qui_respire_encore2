using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] private Transform height;
    [SerializeField] private Transform rightWing;
    [SerializeField] private Transform leftWing;
    [SerializeField] private Transform upperButton;
    [SerializeField] private Transform lowerButton;
    private float rightHeightToWing;
    private float leftHeightToWing;
    private float movementSpeed = 3f;
    private float heightSpeed = 7f;
    private bool lockRotation = false;
    public static bool playerGoesDown;
    public static bool playerGoesUp;
    public float lowoffset = 0.3f;
    public float highoffset = 0.4f;
    
    private void Start()
    {
        Debug.Log("croissant");
        
        
    }


    // Update is called once per frame
    void Update()
    {   
        leftHeightToWing = height.transform.position.y - leftWing.transform.position.y ;
        rightHeightToWing = height.transform.position.y - rightWing.transform.position.y;
        Debug.Log(leftHeightToWing.ToString());
        Debug.Log(rightHeightToWing.ToString());
        Flight();
        Direction_Manager();
        HeightManager();
        
    }
    

    void Flight()
    {
        transform.Translate(0, 0, Time.deltaTime*movementSpeed);
    }

    void Direction_Manager()
    {
        
        if (rightHeightToWing >= highoffset && (lockRotation == false))
        {
            this.transform.Rotate(0, +3, 0);
        }
        
        if (rightHeightToWing >= lowoffset && (lockRotation == false)) 
        {
            this.transform.Rotate(0, +1, 0);
        }
        
        if (leftHeightToWing >= highoffset && (lockRotation == false)) 
        {
            this.transform.Rotate(0, -3, 0);
        }
        
        if (leftHeightToWing >= lowoffset && (lockRotation == false)) 
        {
            this.transform.Rotate(0, -1, 0);
        }
        
    }

   
    void HeightManager()
    {
        if (leftHeightToWing <= lowoffset && rightHeightToWing <= lowoffset)
        {
            Debug.Log("haut");
            lockRotation = true ;
            this.transform.Translate(0, -Time.deltaTime*heightSpeed, 0);
        }

        else
        {
            lockRotation = false;
        }
        
        
        if (leftHeightToWing >= highoffset && rightHeightToWing >= highoffset)
        {
            Debug.Log("bas");
            lockRotation = true ;
            this.transform.Translate(0, Time.deltaTime*heightSpeed, 0);
            
        }

        else
        {
            lockRotation = false;
        }
        
        
    }

    
}   
    
