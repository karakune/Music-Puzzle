using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.Linq;

public class VRControllerInput : MonoBehaviour
{

    //Should only ever be one, but just in case
    // protected List<VRInteractableObject> heldObjects;

    //Should only ever be one, but just in case one gets stuck
    protected Dictionary<EVRButtonId, List<VRInteractableObject>> pressDownObjects;
    protected List<EVRButtonId> buttonsTracked;

    //Controller References
    protected SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    void Awake()
    {
        //Instantiate lists
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        // heldObjects = new List<VRInteractableObject>();
        //Instantiate lists
        pressDownObjects = new Dictionary<EVRButtonId, List<VRInteractableObject>>();

        //List the buttons you send inputs to the controller for
        buttonsTracked = new List<EVRButtonId>()
        {
            EVRButtonId.k_EButton_SteamVR_Trigger,
            EVRButtonId.k_EButton_Grip
        };
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (heldObjects.Count > 0)
        // {
        //     //If trigger is releasee
        //     if (device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
        //     {
        //         //Release any held objects
        //         for (int i = 0; i < heldObjects.Count; i++)
        //         {
        //             heldObjects[i].Release(this);
        //         }
        //         heldObjects = new List<VRInteractableObject>();
        //     }
        // }
        //Check through all desired buttons to see if any have been released
        EVRButtonId[] pressKeys = pressDownObjects.Keys.ToArray();
        for (int i = 0; i < pressKeys.Length; i++)
        {
            //If tracked button is released
            if (device.GetPressUp(pressKeys[i]))
            {
                //Get all tracked objects in that button's "pressed" list
                List<VRInteractableObject> releaseObjects = pressDownObjects[pressKeys[i]];
                for (int j = 0; j < releaseObjects.Count; j++)
                {
                    //Send button release through to interactable script
                    releaseObjects[j].ButtonPressUp(pressKeys[i], this);
                }

                //Clear 
                pressDownObjects[pressKeys[i]].Clear();
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        //If collider has a rigid body to report to
        if (collider.attachedRigidbody != null)
        {
            //If rigidbody's object has interactable item scripts, iterate through them
            VRInteractableObject[] interactables = collider.attachedRigidbody.GetComponents<VRInteractableObject>();
            for (int i = 0; i < interactables.Length; i++)
            {
                VRInteractableObject interactable = interactables[i];
                for (int b = 0; b < buttonsTracked.Count; b++)
                {
                    //If a tracked button is pressed
                    EVRButtonId button = buttonsTracked[b];
                    if (device.GetPressDown(button))
                    {
                        //If we haven't already sent the button press message to this interactable
                        //Safeguard against objects that have multiple colliders for one interactable script
                        if (!pressDownObjects.ContainsKey(button) || !pressDownObjects[button].Contains(interactable))
                        {
                            //Send button press through to interactable script
                            interactable.ButtonPressDown(button, this);

                            //Add interactable script to a dictionary flagging it to recieve notice
                            //when that same button is released
                            if (!pressDownObjects.ContainsKey(button))
                                pressDownObjects.Add(button, new List<VRInteractableObject>());

                            pressDownObjects[button].Add(interactable);
                        }
                    }
                }
            }
        }
    }
}
