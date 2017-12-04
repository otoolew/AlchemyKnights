using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Billboard : MonoBehaviour {
    //The purpose of this script is to have an object (normally a sprite or canvas) always face another object. 
    //This script will track/face the x, y, and z positions of the object by default but can be edited to 
    //not track certain axis by changing the booleans.
    //Meaning this script does NOT rotate on the axises that are FALSE

    public Transform objectToTrack;
    //axises that this object will rotate upon
    [Header("Axis to rotate on:")]
    public bool trackX = true;
    public bool trackY = true;
    public bool trackZ = true;
    //additional rotation added at the end if needed
    [Header("Offset rotation by:")]
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float offsetZ = 0.0f;
    // might be needed to consider the world up as something besides up
    public enum WorldUp {up, down, left, right, forward, back};
    [Header("World Up Direction:")]
    public WorldUp worldUp;

    private void Start()
    {
        objectToTrack = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {


        //create a temporary vector3 that contains the x, y, and z position where this object should be looking at
        Vector3 tempV = SetPointToLookAt();

        //set a world up
        Vector3 upwardDirection = SetUpwardsDirection();

        //make this object look at the object that needs to be tracked
        transform.LookAt(tempV, upwardDirection);
        //rotate by the amount specified by the designer
        transform.Rotate(offsetX, offsetY, offsetZ);
        
        
        //uncomment for debug
        //print(tempV);
    }


    //designer can choose if this object tracks certain axis of the other object.  This function takes
    //those choices into account (trackX, trackY, trackZ) and returns a vector3 point for this object to look at
    private Vector3 SetPointToLookAt()
    {
        float xPosition;
        float yPosition;
        float zPosition;

        //if trackX is true, then rotate on the x-axis to follow objectToTrack
        if (trackX == true)
        {
            xPosition = objectToTrack.position.x;
        }
        //if trackX is false, then do not rotate on the x-axis
        else
        {
            xPosition = transform.position.x;
        }
        //if trackY is true, then rotate on the y-axis to follow objectToTrack
        if (trackY == true)
        {
            yPosition = objectToTrack.position.y;
        }
        //if trackY is false, then do not rotate on the y-axis
        else
        {
            yPosition = transform.position.y;
        }
        //if trackZ is true, then rotate on the z-axis to follow objectToTrack
        if (trackZ == true)
        {
            zPosition = objectToTrack.position.z;
        }
        //if trackZ is false, then do not rotate on the z-axis
        else
        {
            zPosition = transform.position.z;
        }

        Vector3 pointToLookAt = new Vector3(xPosition, yPosition, zPosition);

        return pointToLookAt;
    }

    //This function looks at the public enumerated variable worldUp and 
    //returns a unit vector based off of the value of worldUp
    private Vector3 SetUpwardsDirection()
    {
        //just in case, set upwardsDirection to be the standard up
        Vector3 upwardsDirection = Vector3.up;

        //if up, return up unit vector
        if(worldUp == WorldUp.up)
        {
            upwardsDirection = Vector3.up;
        }
        //if down, return down unit vector
        else if(worldUp == WorldUp.down)
        {
            upwardsDirection = Vector3.down;
        }
        //if left, return left unit vector
        else if (worldUp == WorldUp.left)
        {
            upwardsDirection = Vector3.left;
        }
        //if right, return right unit vector
        else if(worldUp == WorldUp.right)
        {
            upwardsDirection = Vector3.right;
        }
        //if forward, return forward unit vector
        else if (worldUp == WorldUp.forward)
        {
            upwardsDirection = Vector3.forward;
        }
        //if back, return back unit vector
        else if (worldUp == WorldUp.back)
        {
            upwardsDirection = Vector3.back;
        }

        return upwardsDirection;
    }
}
