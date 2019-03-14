﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRInteractableObject : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected bool originalKinematicState;
    protected Transform originalParent;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        //Capture object's original parent and kinematic state
        originalParent = transform.parent;
        originalKinematicState = rigidBody.isKinematic;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pickup(VRControllerInput controller)
    {
        //Make object kinematic
        //(Not effected by physics, but still able to effect other objects with physics)
        rigidBody.isKinematic = true;

        //Parent object to hand
        transform.SetParent(controller.gameObject.transform);
    }

    public void Release(VRControllerInput controller)
    {
        //Make sure the hand is still the parent. 
        //Could have been transferred to anothr hand.
        if (transform.parent == controller.gameObject.transform)
        {//Return previous kinematic state
            rigidBody.isKinematic = originalKinematicState;

            //Set object's parent to its original parent
            if (originalParent != controller.gameObject.transform)
            {
                //Ensure original parent recorded wasn't somehow the controller (failsafe)
                transform.SetParent(originalParent);
            }
            else
            {
                transform.SetParent(null);
            }

            //Throw object
            rigidBody.velocity = controller.device.velocity;
            rigidBody.angularVelocity = controller.device.angularVelocity;
        }

    }

    /// <summary>
    /// Called when button is pressed down while controller is inside object
    /// </summary>
    /// <param name="controller"></param>
    public virtual void ButtonPressDown(EVRButtonId button, VRControllerInput controller)
    {
        //Empty. Overriden meothod only.
    }

    /// <summary>
    /// Called when button is released after an object has been "grabbed".
    /// </summary>
    /// <param name="controller"></param>
    public virtual void ButtonPressUp(EVRButtonId button, VRControllerInput controller)
    {
        //Empty. Overriden meothod only.
    }
}
